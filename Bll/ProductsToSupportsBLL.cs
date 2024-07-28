using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class prod
    {
        public string prodName { get; set; }
        public int Shop { get; set; }
        public int paymentWay { get; set; }

        
    
        //תרגום פרטי מוצר לקוד מוצר
        public  int GetProductCodeByDetails()
        {
            try
            {                
                int payment = SupportWayDAL.GetSupportWayByID(this.paymentWay).SupportWayID;
                return ProductsDAL.GetProductCodeByDetails(this.prodName,this.Shop,payment);

            }
            catch (Exception e)
            {
                return 0;
            }
        }

        
    }

    public class ProductsToSupportsBLL
    {
        //שליפת כל המוצרים לתמיכות
        public static List<ProductsToSupportsDTO> GetAllProductsToSupports()
        {
            try
            {
                return ProductsToSupportsDTO.toDTO_List(ProductsToSupportsDAL.GetAllProductsToSupports());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // שליפת מוצרים לתמיכה לפי קוד תמיכה
        public static List< ProductsToSupportsDTO> GetProductsToSupportsByID(int ID)
        {
            try
            {
                return ProductsToSupportsDTO.toDTO_List(ProductsToSupportsDAL.GetProductsToSupportsByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל המוצרים הלבנים של תמיכה מסוימת
        public static List<ProductsToSupportsDTO> GetWhiteProductsToSupportsByID(int ID)
        {
            try
            {
                var listAll = ProductsToSupportsDTO.toDTO_List(ProductsToSupportsDAL.GetProductsToSupportsByID(ID));
                var listWhite = listAll.Where(p =>ProductsBLL.IsWhite(p.ProdID) == true).ToList();
                return listWhite;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //הוספת מוצר לתמיכה
        public static bool InsertProductsToSupports(ProductsToSupportsDTO newld)
        {
            try
            {
                return ProductsToSupportsDAL.InsertProductsToSupports(ProductsToSupportsDTO.toProductsToSupports(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //הוספת רשימה של מוצרים לתמיכה
        public static bool InsertProductsToSupportsList(List< ProductsToSupportsDTO> newld)
        {
            try
            {
                
                bool ans = true;
                foreach (var item in newld)
                {
                    ans = ans && (ProductsToSupportsDAL.InsertProductsToSupports(ProductsToSupportsDTO.toProductsToSupports(item)));
                    //בהוספת מוצר לתמיכה מתווספת תנועה
                    TransactionsOnCofferDTO newTrans = new TransactionsOnCofferDTO();
                    newTrans.SupportID=item.SupportID;
                    newTrans.TransactionSum = item.Qty * (ProductsBLL.GetProductByID(item.ProdID)).PricePerUnit;
                    newTrans.TransactionDate = (SupportsBLL.GetSupportByID(item.SupportID)).SupportDate;
                    newTrans.Year = newTrans.TransactionDate.Year;
                    newTrans.BlackOrWhite=(SupportWayBLL.GetSupportWayByID( ProductsBLL.GetProductByID(item.ProdID).SupportWayID)).BlackOrWhite;
                    newTrans.TypeOfExpensesAndIncome = 9;//קוד של סוג תנועה-"מוצר לתמיכה" קבוע                     
                    return ans && TransactionsOnCofferBLL.InsertTransaction(newTrans);;
                }
                return ans;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //מחיקת מוצרים של  תמיכה מסוימת
        public static bool RemoveProuctsToSupportBySupportID(int id)
        {
            try
            {
                bool status=true;
                List<ProductsToSupportsDTO> listProducts = GetProductsToSupportsByID(id).ToList();
                List<dynamic> listTransactions = TransactionsOnCofferBLL.GetAllTransactionsOnCofferBySupport(id).ToList();
                foreach (var item in listProducts)
                {
                    foreach (var item2 in listTransactions)                  
                    {
                        int idProd = item.ProdsToSupportsID;
                        status = (status) && (ProductsToSupportsDAL.RemoveProductToSupport(idProd)) && (TransactionsOnCofferBLL.RemoveTransaction(item2));
                    }
                }
                return status;
            }
            catch(Exception e)
            {
                return false;
            }
        }
    }
}

