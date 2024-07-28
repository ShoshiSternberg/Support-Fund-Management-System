using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class TypesOfExpensesAndIncomeDTO
    {
        private int typeID;

        public int TypeID
        {
            get { return typeID; }
            set { typeID = value; }
        }

        private bool expensesOrIncome;

        public bool ExpensesOrIncome
        {
            get { return expensesOrIncome; }
            set { expensesOrIncome = value; }
        }

        private String typeName;

        public String TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }



        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static TypesOfExpensesAndIncome toTypesOfExpensesAndIncomeDAL(TypesOfExpensesAndIncomeDTO AS)
        {
            try
            {
                TypesOfExpensesAndIncome newLD = new TypesOfExpensesAndIncome();
                newLD.TypeID = AS.TypeID;
                newLD.ExpensesOrIncome = AS.ExpensesOrIncome;
                newLD.TypeName = AS.TypeName;

                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static TypesOfExpensesAndIncomeDTO toTypesOfExpensesAndIncomeDTO(TypesOfExpensesAndIncome AS)
        {
            TypesOfExpensesAndIncomeDTO newLD = new TypesOfExpensesAndIncomeDTO();
            newLD.TypeID = AS.TypeID;
            newLD.ExpensesOrIncome = (bool)AS.ExpensesOrIncome;
            newLD.TypeName = AS.TypeName;
            return newLD;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<TypesOfExpensesAndIncomeDTO> toDTO_List(List<TypesOfExpensesAndIncome> AS)
        {
            List<TypesOfExpensesAndIncomeDTO> AList = new List<TypesOfExpensesAndIncomeDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toTypesOfExpensesAndIncomeDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<TypesOfExpensesAndIncome> toTBL_List(List<TypesOfExpensesAndIncomeDTO> AS)
        {
            List<TypesOfExpensesAndIncome> AList = new List<TypesOfExpensesAndIncome>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toTypesOfExpensesAndIncomeDAL(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }
}
