using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SupportWayDAL
    {
       

        //פונקציות שליפה
        //שליפת כל צורות התמיכה
        public static List<SupportWay> GetAllSupportWay()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.SupportWay.ToList();
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }

        //שליפת צורת תמיכה לפי קוד
        public static SupportWay GetSupportWayByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.SupportWay.FirstOrDefault(p => p.SupportWayID == ID);
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }
        //שליפת צורת תמיכה לפי קוד
        public static int GetSupportWayIDByName(string pwa)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    int ans = db.SupportWay.FirstOrDefault(p => p.PaymentWay == pwa).SupportWayID;
                    return ans;
                }
            }
            catch
            {
                return 0;
            }
        }
        //פונקציות הוספה
        //הוספת צורת תמיכה
        public static bool InsertSupportWay(SupportWay an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.SupportWay.Add(an);
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
