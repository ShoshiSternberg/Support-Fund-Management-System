using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ProductsToSupportsDTO
    {
        public int ProdsToSupportsID { get; set; }
        public int SupportID { get; set; }
        public int ProdID { get; set; }
        
        public int Qty { get; set; }
        public int NumCheckOrCupon { get; set; }
        public bool InvoiceReceived { get; set; }
        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static ProductsToSupports toProductsToSupports(ProductsToSupportsDTO AS)
        {
            try
            {
                ProductsToSupports newLD = new ProductsToSupports();
                newLD.ProdsToSupportsID = AS.ProdsToSupportsID;
                newLD.SupportID = AS.SupportID;
                newLD.ProdID = AS.ProdID;                
                newLD.Qty = AS.Qty;
                newLD.NumCheckOrCupon = AS.NumCheckOrCupon;
                newLD.InvoiceReceived = AS.InvoiceReceived;
                return newLD;
            }
            catch
            {
                return null;
            }

        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ProductsToSupportsDTO toProductsToSupportsDTO(ProductsToSupports AS)
        {
            try
            {
                ProductsToSupportsDTO newLD = new ProductsToSupportsDTO();
                
                newLD.ProdsToSupportsID = AS.ProdsToSupportsID;
                newLD.SupportID = (int)AS.SupportID;
                newLD.ProdID =(int) AS.ProdID;                
                newLD.Qty =(int) AS.Qty;
                newLD.NumCheckOrCupon = (int)AS.NumCheckOrCupon;
                newLD.InvoiceReceived = (bool)AS.InvoiceReceived;
                return newLD;

            }
            catch
            {
                return null;
            }


        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ProductsToSupportsDTO> toDTO_List(List<ProductsToSupports> AS)
        {
            List<ProductsToSupportsDTO> AList = new List<ProductsToSupportsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProductsToSupportsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<ProductsToSupports> toTBL_List(List<ProductsToSupportsDTO> AS)
        {
            List<ProductsToSupports> AList = new List<ProductsToSupports>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProductsToSupports(item));
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

