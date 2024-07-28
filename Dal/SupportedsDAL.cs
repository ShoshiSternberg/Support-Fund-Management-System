using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ComponentModel;
using System.Data;
using System.Drawing;



namespace Dal
{
    public class SupportedsDAL
    {
       

        //פונקציות שליפה
        //שליפת כל הנתמכים
        public static List<Supporteds> GetAllSupporteds()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Supporteds.ToList();
                    return list1;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        //שליפת נתמך לפי קוד
        public static Supporteds GetSupportedsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Supporteds.FirstOrDefault(p => p.SupportedID == ID);
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }
        //פונקציות הוספה
        //הוספת נתמך
        public static bool InsertSupporteds(Supporteds an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Supporteds.Add(an);
                    db.SaveChanges();
                    return true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //פונקציות מחיקה
        //מחיקת נתמך
        public static bool RemoveSupporteds(Supporteds an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Supporteds.Remove(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch
            {
                return false;
            }
        }

        //עדכון נתמך
        public static bool UpdateSupporteds(Supporteds an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var an1 = db.Supporteds.FirstOrDefault(p => p.SupportedID == an.SupportedID);
                    if (an1 != null)
                    {
                        an1.SupFirstName = an.SupFirstName;
                        an1.SupLastName = an.SupLastName;
                        an1.SupportedIdentity = an.SupportedIdentity;
                        an1.SupTelephone = an.SupTelephone;
                        an1.StatusID = an.StatusID;
                        an1.LayerID = an.LayerID;
                        an1.gambar = an.gambar;
                        db.SaveChanges();
                    }
                    else
                        InsertSupporteds(an);
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
