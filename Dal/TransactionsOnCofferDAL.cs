using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class TransactionsOnCofferDAL
    {
       

        //פונקציות שליפה
        //שליפת כל התנועות בקופה
        public static List<TransactionsOnCoffer> GetAllTransactionsOnCoffer()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.TransactionsOnCoffer.ToList();
                    return list1;
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }

        //שליפת תנועה לפי קוד
        public static TransactionsOnCoffer GetTransactionsOnCofferByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.TransactionsOnCoffer.FirstOrDefault(p => p.TransactionID == ID);
                    return list1;
                }
            }
            catch(Exception ex) 
            {
                return null;
            }
        }
        //פונקציות הוספה
        //הוספת תנועה
        public static bool InsertTransactionsOnCoffer(TransactionsOnCoffer an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.TransactionsOnCoffer.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        //מחיקת תנועה
        public static bool RemoveTransaction(int id)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.TransactionsOnCoffer.Remove(db.TransactionsOnCoffer.FirstOrDefault(p=>p.TransactionID==id));
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //עדכון תנועה
        public static bool UpdateTransactionsOnCoffer(TransactionsOnCoffer an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.TransactionsOnCoffer.AddOrUpdate(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
