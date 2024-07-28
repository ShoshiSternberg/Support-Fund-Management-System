using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ResponsiblesDAL
    {
      


        //פונקציות שליפה
        //שליפת כל האחראיים
        public static List<Responsibles> GetAllResponsibles()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Responsibles.ToList();
                    return list1;
                }
            }
            catch(Exception e)
            {
                return null;
            }
        }

        //שליפת אחראי לפי קוד
        public static Responsibles GetResponsiblesByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Responsibles.FirstOrDefault(p => p.ResponsibleID == ID);
                    return list1;
                }
            }
            catch
            {
                return null;
            }
        }

        //הוספת אחראי
        public static bool InsertResponsibles(Responsibles an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Responsibles.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        //עדכון אחראי
        public static bool UpdateResponsible(Responsibles an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Responsibles.AddOrUpdate(an);
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
