using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TypesOfExpensesAndIncomeDAL
    {



        //פונקציות שליפה
        //שליפת כל סוגי ההוצאות וההכנסות
        public static List<TypesOfExpensesAndIncome> GetAllTypesOfExpensesAndIncome()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.TypesOfExpensesAndIncome.ToList();
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }

        //שליפת סוג הוצאה או הכנסה לפי קוד
        public static TypesOfExpensesAndIncome GetTypesOfExpensesAndIncomeByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.TypesOfExpensesAndIncome.FirstOrDefault(p => p.TypeID == ID);
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }
        //פונקציות הוספה
        //הוספת סוג הוצאה או הכנסה
        public static bool InsertTypesOfExpensesAndIncome(TypesOfExpensesAndIncome an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.TypesOfExpensesAndIncome.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }
    }
}
