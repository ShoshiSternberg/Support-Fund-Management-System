using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
using System.Xml.Linq;

namespace Bll
{
    public class ProductsBLL
    {
        //שליפת כל המוצרים
        public static List<dynamic> GetAllProducts()
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = ProductsDTO.toDTO_List(ProductsDAL.GetAllProducts());
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.ProdID = item.ProdID;
                    MyDynamic.ProdName = item.ProdName;
                    MyDynamic.ProviderID = item.ProviderID;
                    MyDynamic.ProviderName = ProvidersBLL.GetProviderByID(item.ProviderID) != null ? ProvidersBLL.GetProviderByID(item.ProviderID).ProvName : null;
                    MyDynamic.PricePerUnit = item.PricePerUnit;
                    MyDynamic.SupportWayID = item.SupportWayID;
                    MyDynamic.SupportWay = SupportWayBLL.GetSupportWayByID(item.SupportWayID) != null ? SupportWayBLL.GetSupportWayByID(item.SupportWayID).PaymentWay : null;

                    list1.Add(MyDynamic);
                }
                return list1;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת מוצר לפי קוד
        public static dynamic GetProductByID(int ID)
        {
            try
            {
                ProductsDTO item = ProductsDTO.toProductsDTO(ProductsDAL.GetProductByID(ID));
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.ProdID = item.ProdID;
                MyDynamic.ProdName = item.ProdName;
                MyDynamic.ProviderID = item.ProviderID;
                MyDynamic.ProviderName = ProvidersBLL.GetProviderByID(item.ProviderID).ProvName;
                MyDynamic.PricePerUnit = item.PricePerUnit;
                MyDynamic.SupportWayID = item.SupportWayID;
                MyDynamic.SupportWay = SupportWayBLL.GetSupportWayByID(item.SupportWayID).PaymentWay;
                MyDynamic.Reasons=ProductsToReasonsBLL.GetAllReasonsByProdID(ID);
                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת כל המוצרים עם שם המוצר המבוקש
        public static List<dynamic> GetProductsByName(string name)
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = ProductsDTO.toDTO_List(ProductsDAL.GetProductsByName(name));
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.ProdID = item.ProdID;
                    MyDynamic.ProdName = item.ProdName;
                    MyDynamic.ProviderID = item.ProviderID;
                    MyDynamic.ProviderName = ProvidersBLL.GetProviderByID(item.ProviderID).ProvName;
                    MyDynamic.PricePerUnit = item.PricePerUnit;
                    MyDynamic.SupportWayID = item.SupportWayID;
                    MyDynamic.SupportWay = SupportWayBLL.GetSupportWayByID(item.SupportWayID) == null ? null : SupportWayBLL.GetSupportWayByID(item.SupportWayID).PaymentWay;

                    list1.Add(MyDynamic);
                }
                return list1;

            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל המוצרים עם המוצר והספק

        public static List<dynamic> GetProductsByName(string name, int prov)
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = ProductsDTO.toDTO_List(ProductsDAL.GetProductsByName(name, prov));
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.ProdID = item.ProdID;
                    MyDynamic.ProdName = item.ProdName;
                    MyDynamic.ProviderID = item.ProviderID;
                    MyDynamic.ProviderName = ProvidersBLL.GetProviderByID(item.ProviderID).ProvName;
                    MyDynamic.PricePerUnit = item.PricePerUnit;
                    MyDynamic.SupportWayID = item.SupportWayID;
                    MyDynamic.SupportWay = SupportWayBLL.GetSupportWayByID(item.SupportWayID).PaymentWay;

                    list1.Add(MyDynamic);
                }
                return list1;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //מקבל קוד מוצר ומחזיר  אמת אם הוא לבן ושקר אם הוא שחור
        public static bool IsWhite(int prod)
        {
            try
            {
                //המוצר
                dynamic prod1 = GetProductByID(prod);
                return SupportWayBLL.GetSupportWayByID(prod1.SupportWayID).BlackOrWhite;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        //שליפת כל המוצרים המתאימים לסיבת התמיכה המבוקשת
        public static List<dynamic> GetAllProductByReason(int reason)
        {
            try
            {
                var reasonToProducts = ProductsToReasonsBLL.GetProductsToReasonsBySupportReason(reason).ToList();
                List<dynamic> lista = new List<dynamic>();
                for (int i = 0; i < reasonToProducts.Count; i++)
                {
                    lista.Add(GetProductByID(reasonToProducts[i].ProdID));
                }
                List<dynamic> list1 = new List<dynamic>();

                foreach (var item in lista)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.ProdID = item.ProdID;
                    MyDynamic.ProdName = item.ProdName;
                    MyDynamic.ProviderID = item.ProviderID;
                    MyDynamic.ProviderName = ProvidersBLL.GetProviderByID(item.ProviderID).ProvName;
                    MyDynamic.PricePerUnit = item.PricePerUnit;
                    MyDynamic.SupportWayID = item.SupportWayID;
                    MyDynamic.SupportWay = SupportWayBLL.GetSupportWayByID(item.SupportWayID).PaymentWay;

                    list1.Add(MyDynamic);
                }
                return list1;
            }
            catch (Exception e)
            {
                return null;

            }
        }
        //הוספת מוצר
        public static bool InsertProduct(List<int> reasons, ProductsDTO newld)
        {
            try
            {
                //הוספת מוצר לטבלת מוצרים וקבלת ה קוד שלו  
                if (ProductsDAL.InsertProduct(ProductsDTO.toProducts(newld)) == true)
                {
                    //אם המוצר התווסף בהצלחה מוסיפים אותו ואת הסיבה שנשלחה לטבלת מוצרים לתמיכות
                    int id = ProductsBLL.GetProductsByName(newld.ProdName).FirstOrDefault(p => (p.ProviderID == newld.ProviderID) && (p.SupportWayID == newld.SupportWayID)).ProdID;
                    ProductsToReasonsDTO productsToReasonsDTO1 = new ProductsToReasonsDTO();
                    bool a = true;
                    
                    for (int i = 0; i < reasons.Count; i++)
                    {
                        productsToReasonsDTO1.ProdID = id;
                        productsToReasonsDTO1.ReasonID = reasons[i];
                        a=a&& ProductsToReasonsBLL.InsertProductToReason(productsToReasonsDTO1);
                    }
                    
                    return a;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }   
    
    //עדכון מוצר
        public static bool UpdateProduct(List<int> reasons, ProductsDTO newld)
        {
            try
            {
                //הוספת מוצר לטבלת מוצרים וקבלת ה קוד שלו  
                if (ProductsDAL.UpdateProduct(ProductsDTO.toProducts(newld)) == true)
                {
                    //אם המוצר התעדכן בהצלחה מוסיפים אותו ואת הסיבה שנשלחה לטבלת מוצרים לסיבות
                    int id = newld.ProdID;
                    ProductsToReasonsDTO productsToReasonsDTO1 = new ProductsToReasonsDTO();
                    // צריך למחוק את כל הסיבות למוצר של המוצר הזה ואח"כ להוסיף הכל
                    ProductsToReasonsBLL.DeleteAllReasonsByProduct(id);
                    bool a = true;
                    for (int i = 0; i < reasons.Count; i++)
                    {
                        productsToReasonsDTO1.ProdID = id;
                        productsToReasonsDTO1.ReasonID = reasons[i];
                        a=a&& ProductsToReasonsBLL.UpdateProductToReason(productsToReasonsDTO1);
                    }
                    
                    return a;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
