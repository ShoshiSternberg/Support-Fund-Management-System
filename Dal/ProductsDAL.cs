using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{

    public class ProductsDAL
    {
        //פונקציות שליפה
        //שליפת כל המוצרים
        public static List<Products> GetAllProducts()
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 =  db.Products.ToList();
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת  מוצר לפי קוד
        public static Products GetProductByID(int ID)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var list1 = db.Products.FirstOrDefault(p => p.ProdID == ID);
                    return list1;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת קוד מוצר לפי שם מוצר חנות ואמצעי תשלום
        public static int GetProductCodeByDetails(string name, int shop, int payment)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    int ans = db.Products.FirstOrDefault(p => (p.ProdName == name) && (p.providerID == shop) && (p.SupportWayID == payment)).ProdID;
                    return ans;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }

        //שליפת כל המוצרים לפי שם מוצר
        public static List<Products> GetProductsByName(string name)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var ans = db.Products.Where(p => p.ProdName == name).ToList();
                    return ans;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל המוצרים לפי שם מוצר וקוד ספק - העמסה
        public static List<Products> GetProductsByName(string name, int prov)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    var ans = db.Products.Where(p => (p.ProdName == name) && (p.providerID == prov)).ToList();
                    return ans;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //הוספת מוצר
        public static bool InsertProduct(Products an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Products.Add(an);
                    db.SaveChanges();
                    return true;

                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //עדכון מוצר
        public static bool UpdateProduct(Products an)
        {
            try
            {
                using (InstitutionalSupportFundEntities db = new InstitutionalSupportFundEntities())
                {
                    db.Products.AddOrUpdate(an);
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
