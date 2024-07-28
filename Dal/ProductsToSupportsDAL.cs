using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public class ProductsToSupportsDAL
    {
        public int ProdsToSupportsID { get; set; }
        public int SupportID { get; set; }
        public int ProdID { get; set; }

        public int Qty { get; set; }
        public int NumCheckOrCupon { get; set; }
        public bool InvoiceReceived { get; set; }

        //פונקציות שליפה
        //שליפת כל המוצרים לתמיכות
        public static List<ProductsToSupports> GetAllProductsToSupports()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ProductsToSupports.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת כל המוצרים לתמיכה לפי קוד תמיכה 
        public static List<ProductsToSupports> GetProductsToSupportsByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.ProductsToSupports.Where(p => p.SupportID == ID).ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת מוצר לתמיכה
        public static bool InsertProductsToSupports(ProductsToSupports an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ProductsToSupports.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //מחיקה
        public static bool RemoveProductToSupport(int id)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.ProductsToSupports.Remove(db.ProductsToSupports.FirstOrDefault(p => p.ProdsToSupportsID == id));
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

