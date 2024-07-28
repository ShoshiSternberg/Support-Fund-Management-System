using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
using System.Collections;

namespace Bll
{
    public class TransactionsOnCofferBLL
    {
        //שליפת כל התנועות
        public static List<dynamic> GetAllTransactions()
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = TransactionsOnCofferDTO.toDTO_List(TransactionsOnCofferDAL.GetAllTransactionsOnCoffer());
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.TransactionID = item.TransactionID;
                    MyDynamic.TransactionSum = item.TransactionSum;
                    MyDynamic.TransactionDate = item.TransactionDate;
                    MyDynamic.SupportID = item.SupportID;
                    MyDynamic.TypeOfExpensesAndIncome = item.TypeOfExpensesAndIncome;
                    MyDynamic.TypeOfExpensesAndIncomeName = TypesOfExpensesAndIncomeBLL
                        .GetTypesOfExpensesAndIncomeByID(item.TypeOfExpensesAndIncome).TypeName;
                    MyDynamic.ExpensesOrIncome = TypesOfExpensesAndIncomeBLL
                        .GetTypesOfExpensesAndIncomeByID(item.TypeOfExpensesAndIncome).ExpensesOrIncome;
                    MyDynamic.BlackOrWhite = item.BlackOrWhite;

                    list1.Add(MyDynamic);
                }
                return list1;
            }
            catch (Exception e)
            {
                return null;
            }
        }


        //שליפת תנועה לפי קוד
        public static dynamic GetTransactionByID(int ID)
        {
            try
            {
                var item = TransactionsOnCofferDTO.toTransactionsOnCofferDTO(TransactionsOnCofferDAL.GetTransactionsOnCofferByID(ID));
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.TransactionID = item.TransactionID;
                MyDynamic.TransactionSum = item.TransactionSum;
                MyDynamic.TransactionDate = item.TransactionDate;
                MyDynamic.SupportID = item.SupportID;
                MyDynamic.TypeOfExpensesAndIncome = item.TypeOfExpensesAndIncome;
                MyDynamic.TypeOfExpensesAndIncomeName = TypesOfExpensesAndIncomeBLL
                    .GetTypesOfExpensesAndIncomeByID(item.TypeOfExpensesAndIncome).TypeName;
                MyDynamic.ExpensesOrIncome = TypesOfExpensesAndIncomeBLL
                    .GetTypesOfExpensesAndIncomeByID(item.TypeOfExpensesAndIncome).ExpensesOrIncome;
                MyDynamic.BlackOrWhite = item.BlackOrWhite;
                
                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל התנועות לפי שנה מסוימת
        public static List<dynamic> GetAllTransactionByYear(int year)
        {
            try
            {
                var list1 = GetAllTransactions();
                List<dynamic> list2 = new List<dynamic>();
                foreach (var item in list1)
                {
                    if (item.Year == year)
                        list2.Add(item);
                }
                return list2;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת כל התנועות לפי תמיכה מסוימת
        public static List<dynamic> GetAllTransactionsOnCofferBySupport(int supp)
        {
            try
            {
                var list1 = GetAllTransactions();
                List<dynamic> list2 = new List<dynamic>();
                foreach (var item in list1)
                {
                    if (item.SupportID == supp)
                        list2.Add(item);
                }
                return list2;
            }
            catch (Exception e)
            {
                return null;
            }
        }
       
        //הוספת תנועה

        public static bool InsertTransaction(TransactionsOnCofferDTO newld)
        {
            try
            {
                newld.Year = (newld.TransactionDate).Year;
                if (TypesOfExpensesAndIncomeBLL.expensesOrIncome(newld.TypeOfExpensesAndIncome) == false)//סכום הופך לשלילי אם זו הוצאה
                    newld.TransactionSum = newld.TransactionSum * (-1);
                AnnualSummaryBLL.UpdateCurrentBalance(newld.Year, newld.TransactionSum, newld.BlackOrWhite);
                return TransactionsOnCofferDAL.InsertTransactionsOnCoffer(TransactionsOnCofferDTO.toTransactionsOnCofferDAL(newld));

            }
            catch (Exception e)
            {
                return false;
            }
        }

        //עדכון תנועה
        public static bool UpdateTransaction(TransactionsOnCofferDTO newld)
        {
            try
            {
                //מחיקת התנועה הקודמת
                if (RemoveTransaction(newld.TransactionID) == true)
                {
                    //התייחסות לתנועה כתנועה חדשה חוץ מהעדכון ב דאל כדי שישאר הקוד
                    newld.Year = (newld.TransactionDate).Year;
                    if (TypesOfExpensesAndIncomeBLL.expensesOrIncome(newld.TypeOfExpensesAndIncome) == false)//סכום הופך לשלילי אם זו הוצאה
                        newld.TransactionSum = newld.TransactionSum * (-1);
                    AnnualSummaryBLL.UpdateCurrentBalance(newld.Year, newld.TransactionSum, newld.BlackOrWhite);
                    bool ans = TransactionsOnCofferDAL.UpdateTransactionsOnCoffer(TransactionsOnCofferDTO.toTransactionsOnCofferDAL(newld));
                    return ans;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //מחיקת תנועה
        public static bool RemoveTransaction(int id)
        {
            try
            {
                //מחיקת השינויים ביתרה
                TransactionsOnCofferDTO newld=TransactionsOnCofferDTO
                    .toTransactionsOnCofferDTO( TransactionsOnCofferDAL.GetTransactionsOnCofferByID(id));
               
                AnnualSummaryBLL.UpdateCurrentBalance(newld.Year, newld.TransactionSum*(-1), newld.BlackOrWhite);
               
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
