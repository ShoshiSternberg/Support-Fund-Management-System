using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProductsToReasonsDAL
    {
        //פונקציות שליפה
        //שליפת כל המוצרים לסיבות
        public static List<ProductsToReasons> GetAllProductsToReasons()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ProductsToReasons.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל המוצרים של סיבה מסוימת
        public static ProductsToReasons GetProductsByReasonID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ProductsToReasons.FirstOrDefault(p => p.ReasonID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת מוצר לסיבה לפי קוד 
        public static ProductsToReasons GetProductsToReasonsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ProductsToReasons.FirstOrDefault(p => p.ProdToReasonID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת מוצר לסיבה 
        public static bool InsertProductsToReasons(ProductsToReasons an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ProductsToReasons.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //עדכון מוצר לסיבה 
        public static bool UpdateProductToReason(ProductsToReasons an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ProductsToReasons.AddOrUpdate(an);

                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //מחיקת מוצר לתמיכה
        public static bool DeleteReasonToProduct(ProductsToReasons an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ProductsToReasons.Remove(an);
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

