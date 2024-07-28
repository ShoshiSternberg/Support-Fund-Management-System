using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ReasonsForSupportsDAL
    {

        private int reasonID;

        public int ReasonID
        {
            get { return reasonID; }
            set { reasonID = value; }
        }

        private string reasonForSupport;

        public string ReasonForSupport
        {
            get { return reasonForSupport; }
            set { reasonForSupport = value; }
        }


        //פונקציות שליפה
        //שליפת כל הסיבות תמיכה
        public static List<ReasonsForSupports> GetAllReasonsForSupports()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ReasonsForSupports.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת סיבת תמיכה לפי קוד
        public static ReasonsForSupports GetReasonsForSupportsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ReasonsForSupports.FirstOrDefault(p => p.ReasonID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת סיבת תמיכה
        public static bool InsertReasonsForSupports(ReasonsForSupports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ReasonsForSupports.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //עדכון סיבת תמיכה
        public static bool UpdateReasonsForSupports(ReasonsForSupports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ReasonsForSupports.AddOrUpdate(an);
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
