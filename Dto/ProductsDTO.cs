using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ProductsDTO
    {
        private int prodID;

        public int ProdID
        {
            get { return prodID; }
            set { prodID = value; }
        }

        private string prodName;

        public string ProdName
        {
            get { return prodName; }
            set { prodName = value; }
        }

        private int providerID;

        public int ProviderID
        {
            get { return providerID; }
            set { providerID = value; }
        }
        private double pricePerUnit;

        public double PricePerUnit
        {
            get { return pricePerUnit; }
            set { pricePerUnit = value; }
        }
        private int supportWayID;

        public int SupportWayID
        {
            get { return supportWayID; }
            set { supportWayID = value; }
        }
        


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Products toProducts(ProductsDTO AS)
        {
            try
            {
                Products newLD = new Products();
                newLD.ProdID = AS.ProdID;
                newLD.ProdName = AS.ProdName;
                newLD.PricePerUnit = (decimal)AS.PricePerUnit;
                newLD.providerID = AS.providerID;
                newLD.SupportWayID = AS.SupportWayID;
                return newLD;
            }
            catch
            {
                return null;
            }

        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ProductsDTO toProductsDTO(Products AS)
        {
            try
            {
                ProductsDTO newLD = new ProductsDTO();
                newLD.ProdID = AS.ProdID;
                newLD.ProdName = AS.ProdName;
                newLD.PricePerUnit = AS.PricePerUnit!=null? (double)AS.PricePerUnit:0.0;
                newLD.providerID = AS.providerID != null ? (int)AS.providerID : 0;
                newLD.SupportWayID = AS.SupportWayID != null ? (int)AS.SupportWayID : 0 ;
                return newLD;
            }
            catch(Exception e)
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ProductsDTO> toDTO_List(List<Products> AS)
        {
            List<ProductsDTO> AList = new List<ProductsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProductsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Products> toTBL_List(List<ProductsDTO> AS)
        {
            List<Products> AList = new List<Products>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProducts(item));
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
