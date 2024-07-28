using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
    public class TypesOfExpensesAndIncomeBLL
    {
        //שליפת כל סוגי התנועות
        public static List<TypesOfExpensesAndIncomeDTO> GetAllTypesOfExpensesAndIncome()
        {
            try
            {
                return TypesOfExpensesAndIncomeDTO.toDTO_List(TypesOfExpensesAndIncomeDAL.GetAllTypesOfExpensesAndIncome());
            }
            catch(Exception e)
            {
                return null;
            }
        }

        //שליפת סוג תנועה לפי קוד
        public static TypesOfExpensesAndIncomeDTO GetTypesOfExpensesAndIncomeByID(int ID)
        {
            try
            {
                return TypesOfExpensesAndIncomeDTO.toTypesOfExpensesAndIncomeDTO(TypesOfExpensesAndIncomeDAL.GetTypesOfExpensesAndIncomeByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        
        //לא שימושי בינתיים)אם מקבל אמת מחזיר את כל  הסוגים של ההכנסות אחרת את כל סוגי ההוצאות)
        public static List<TypesOfExpensesAndIncomeDTO> GetAllTypesOfExpenses(bool expense)
        {
            try {
                List<TypesOfExpensesAndIncomeDTO> list1 = new List<TypesOfExpensesAndIncomeDTO>();
                list1 = GetAllTypesOfExpensesAndIncome().Where(p => p.ExpensesOrIncome == expense).ToList();
                return list1;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // מקבל קוד סוג ומחזיר אמת אם הוא הכנסה ושקר אם הוא הוצאה 
        public static bool expensesOrIncome(int type)
        {
            try
            {
                TypesOfExpensesAndIncomeDTO l1 = TypesOfExpensesAndIncomeDTO.toTypesOfExpensesAndIncomeDTO(TypesOfExpensesAndIncomeDAL
                    .GetTypesOfExpensesAndIncomeByID(type));
                return l1.ExpensesOrIncome;

            }
            catch (Exception e)
            {
                return false;
            }
        }
        //הוספת סוג תנועה
        public static bool InsertStatus(bool eoI, string LName)
        {
            try
            {
                TypesOfExpensesAndIncomeDTO newld = new TypesOfExpensesAndIncomeDTO();
                
                newld.ExpensesOrIncome = eoI;
                newld.TypeName = LName;


                return TypesOfExpensesAndIncomeDAL.InsertTypesOfExpensesAndIncome(TypesOfExpensesAndIncomeDTO
                    .toTypesOfExpensesAndIncomeDAL(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
