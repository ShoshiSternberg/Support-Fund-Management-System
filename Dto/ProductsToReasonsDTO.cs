using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ProductsToReasonsDTO
    {
        private int prodToReasonID;

        public int ProdToReasonID
        {
            get { return prodToReasonID; }
            set { prodToReasonID = value; }
        }

        private int prodID;

        public int ProdID
        {
            get { return prodID; }
            set { prodID = value; }
        }

        private int reasonID;

        public int ReasonID
        {
            get { return reasonID; }
            set { reasonID = value; }
        }


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static ProductsToReasons toProductsToReasons(ProductsToReasonsDTO AS)
        {
            ProductsToReasons newLD = new ProductsToReasons();
            newLD.ProdToReasonID = AS.ProdToReasonID;
            newLD.ProdID = AS.ProdID;
            newLD.ReasonID = AS.ReasonID;
            return newLD;
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ProductsToReasonsDTO toProductsToReasonsDTO(ProductsToReasons AS)
        {
            ProductsToReasonsDTO newLD = new ProductsToReasonsDTO();
            newLD.prodToReasonID = AS.ProdToReasonID;
            newLD.ProdID = (int)AS.ProdID;
            newLD.ReasonID = (int)AS.ReasonID;
            return newLD;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ProductsToReasonsDTO> toDTO_List(List<ProductsToReasons> AS)
        {
            List<ProductsToReasonsDTO> AList = new List<ProductsToReasonsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProductsToReasonsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<ProductsToReasons> toTBL_List(List<ProductsToReasonsDTO> AS)
        {
            List<ProductsToReasons> AList = new List<ProductsToReasons>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProductsToReasons(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }

        }

    }

}

