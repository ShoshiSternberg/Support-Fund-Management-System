using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class StatusesDAL
    {
        //פונקציות שליפה
        //שליפת כל הסיכומים השנתיים
        public static List<Statuses> GetAllStatuses()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Statuses.ToList();
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }

        //שליפת סטטוס לפי קוד
        public static Statuses GetStatusesByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Statuses.FirstOrDefault(p => p.StatusID == ID);
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }

        //הוספת סטטוס
        public static bool InsertStatuses(Statuses an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Statuses.Add(an);
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
