using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProvidersDAL
    {
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }

        //פונקציות שליפה
        //שליפת כל הספקים
        public static List<Providers> GetAllProviders()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Providers.ToList();
                    Console.WriteLine(list1.First().ToString());
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        
        //שליפת  ספק לפי קוד
        public static Providers GetProviderByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Providers.FirstOrDefault(p => p.ProviderID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת קוד ספק לפי שם 
        public static int GetProviderCodeByDetails(string name)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    int ans = db.Providers.FirstOrDefault(p => (p.ProviderName == name)).ProviderID;
                    return ans;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        //הוספת ספק
        public static bool InsertProvider(Providers an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Providers.Add(an);
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

