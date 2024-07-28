using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class AnnualSummaryDAL
    {    
        //פונקציות שליפה
        //שליפת כל הסיכומים השנתיים
        public static List<AnnualSummary> GetAllAnnualSummary()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.AnnualSummary.ToList();
                    return list1;
                }
            }
            catch(Exception e)
            {                
                return null;
            }
        }
        //שליפת סיכום לפי שנה
        public static AnnualSummary GetAnnualSummaryByYear(int year)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.AnnualSummary.FirstOrDefault(p=>p.Year==year);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //פונקציות הוספה
        //הוספת סיכום שנתי
        public static bool InsertAnnualSummary(AnnualSummary an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.AnnualSummary.Add(an);
                    db.SaveChanges();
                    return true;
                    
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //פונקציות מחיקה
        //מחיקת סיכום שנתי לפי שנה
        public static bool RemoveAnnualSummary(AnnualSummary ann)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.AnnualSummary.Remove(ann);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //פונקצית עדכון יתרה שחורה ולבנה
        public static bool UpdateBalance(int year,double black,double white)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var CurrYear = db.AnnualSummary.FirstOrDefault(p => p.Year == year);
                    CurrYear.CurrentBlackBalance += (decimal)black;
                    CurrYear.CurrentWhiteBalance += (decimal)white;
                    db.SaveChanges();
                    return true;
                }

            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
