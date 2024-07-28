using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProtocolsDAL
    {
       
        //פונקציות שליפה
        //שליפת כל הפרוטוקולים
        public static List<Protocols> GetAllProtocols()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Protocols.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת פרוטוקול לפי קוד 
        public static Protocols GetProtocolsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Protocols.FirstOrDefault(p => p.ProtocolID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        //שליפת פרוטוקול לפי קוד תמיכה 
        public static Protocols GetProtocolsBySupportID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Protocols.FirstOrDefault(p => p.SupportID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת פרוטוקול
        public static bool InsertProtocols(Protocols an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Protocols.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //עדכון פרוטוקול
        public static bool UpdateProtocols(int id,Protocols an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var an1 = db.Protocols.FirstOrDefault(p => p.ProtocolID == id);
                    if (an1 != null)
                    {                       
                        an1.SupportID = an.SupportID;
                        an1.IssueDate = an.IssueDate;
                        an1.SupportedToProtocol = an.SupportedToProtocol;
                        an1.ReasonForProtocol = an.ReasonForProtocol;
                        db.SaveChanges();
                    }
                    else
                        InsertProtocols(an);
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
