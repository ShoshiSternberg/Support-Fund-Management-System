using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
     
    public class LayersDAL { 
        //פונקציות שליפה
        //שליפת כל השכבות
        public static List<Layers> GetAllLayers()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Layers.ToList();
                    return list1;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        //שליפת שכבה לפי קוד
        public static Layers GetLayerByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Layers.FirstOrDefault(p => p.LayerID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת שכבה
        public static bool InsertLayer(Layers an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Layers.Add(an);
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
