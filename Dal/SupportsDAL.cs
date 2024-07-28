using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class SupportsDAL
    {
        //פונקציות שליפה
        //שליפת כל התמיכות
        public static List<Supports> GetAllSupports()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Supports.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת תמיכה לפי קוד
        public static Supports GetSupportsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Supports.FirstOrDefault(p => p.SupportID == ID);
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }
        //שליפת קוד התמיכה לפי פרטיה
        public static int GetSupportIDByDetails(Supports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    int ans = db.Supports.FirstOrDefault(p => (p.SupportedID == an.SupportedID) && (p.SuppDate == an.SuppDate) &&
                    (p.SumOfSupport == an.SumOfSupport) && (p.Details == an.Details) && (p.ResponsibleID == an.ResponsibleID) && (p.Referrer == an.Referrer)).SupportID;
                    return ans;
                }
            }
            catch
            {
                return 0;
            }
        }
        //פונקציות הוספה
        //הוספת תמיכה
        public static bool InsertSupports(Supports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Supports.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //עדכון תמיכה
        public static bool UpdateSupports(int id, Supports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    Supports support = db.Supports.FirstOrDefault(p => p.SupportID == id);
                    if (support != null)
                    {
                        support.SupportedID = an.SupportedID;
                        support.SuppDate = an.SuppDate;
                        support.ReasonID = an.ReasonID;
                        support.SumOfSupport = an.SumOfSupport;
                        support.Details = an.Details;
                        support.ResponsibleID = an.ResponsibleID;
                        support.Referrer = an.Referrer;
                    }
                    else
                        InsertSupports(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
