using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ReportsDAL
    {
       

        //פונקציות שליפה
        //שליפת כל הדיווחים
        public static List<Reports> GetAllReports()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Reports.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת דיווח לפי קוד
        public static Reports GetReportsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Reports.FirstOrDefault(p => p.ReportID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת דיווח
        public static bool InsertReports(Reports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Reports.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //עדכון דיווח
        public static bool UpdateReport(Reports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var an1 = db.Reports.FirstOrDefault(p => p.ReportID == an.ReportID);
                    if (an1 != null)
                    {
                       an1.ReportID=an.ReportID;    
                       an1.ReportDate=an.ReportDate;
                        an1.SupportedID=an1.SupportedID;
                        an1.GabayID = an.GabayID;
                        an1.Details = an.Details;
                        db.SaveChanges();
                    }
                    else
                        InsertReports(an);
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        } 
        
        //מחיקת דיווח
        public static bool RemoveReport(int an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    Reports a = db.Reports.FirstOrDefault(p => p.ReportID == an);
                    db.Reports.Remove(a);
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
