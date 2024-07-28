using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class ProductsToReasonsBLL
    {

        //שליפת כל המוצרים לסיבות
        public static List<ProductsToReasonsDTO> GetAllProductsToReasons()
        {
            return ProductsToReasonsDTO.toDTO_List(ProductsToReasonsDAL.GetAllProductsToReasons());
        }

        //שליפת כל מוצרים לפי סיבה
        public static ProductsToReasonsDTO GetLayerByID(int ID)
        {
            return ProductsToReasonsDTO.toProductsToReasonsDTO(ProductsToReasonsDAL.GetProductsByReasonID(ID));
        }
        //שליפת כל הסיבות לפי מוצר
        public static List<int> GetAllReasonsByProdID(int ID)
        {
            var list = GetAllProductsToReasons();
            var ans = list.Where(p => p.ProdID == ID).Select(s => s.ReasonID).ToList();
            return ans;
        }
        //שליפת כל המוצרים לסיבות שהסיבה היא מה שנשלח
        public static List<ProductsToReasonsDTO> GetProductsToReasonsBySupportReason(int reason)
        {
            try
            {
                var arr = ProductsToReasonsBLL.GetAllProductsToReasons();
                arr = arr.Where(p => p.ReasonID == reason).ToList();
                return arr;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת מוצר לסיבה
        public static bool InsertProductToReason(ProductsToReasonsDTO newld)
        {
            return ProductsToReasonsDAL.InsertProductsToReasons(ProductsToReasonsDTO.toProductsToReasons(newld));
        }

        //עדכון מוצר לסיבה
        public static bool UpdateProductToReason(ProductsToReasonsDTO newld)
        {
            return ProductsToReasonsDAL.UpdateProductToReason(ProductsToReasonsDTO.toProductsToReasons(newld));
        }
        //מחיקת כל המוצרים לסיבות לפי מוצר
        public static bool DeleteAllReasonsByProduct(int id)
        {
            try
            {
                var list = GetAllProductsToReasons().Where(p => p.ProdID == id).ToList();
                bool ans = true;
                foreach (var item in list)
                {
                    ans = ans & ProductsToReasonsDAL.DeleteReasonToProduct(ProductsToReasonsDTO.toProductsToReasons(item));
                }
                return ans;
            }
            catch (Exception e) {
                return false;   
            }

        }


    }
}
