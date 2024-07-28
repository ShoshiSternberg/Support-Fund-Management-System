using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class SupportsDTO
    {
        private int supportID;

        public int SupportID
        {
            get { return supportID; }
            set { supportID = value; }
        }

        private int supportedID;

        public int SupportedID
        {
            get { return supportedID; }
            set { supportedID = value; }
        }

        private DateTime supportDate;

        public DateTime SupportDate
        {
            get { return supportDate; }
            set { supportDate = value; }
        }

        private int reasonID;

        public int ReasonID
        {
            get { return reasonID; }
            set { reasonID = value; }
        }

        private double sumOfSupport;

        public double SumOfSupport
        {
            get { return sumOfSupport; }
            set { sumOfSupport = value; }
        }

        

        private string details;

        public string Details
        {
            get { return details; }
            set { details = value; }
        }

        private int responsibleID;

        public int ResponsibleID
        {
            get { return responsibleID; }
            set { responsibleID = value; }
        }

        private string referrer;

        public string Referrer
        {
            get { return referrer; }
            set { referrer = value; }
        }

        public ProductsDTO [] ProductsArr;

        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Supports toSupports(SupportsDTO AS)
        {
            try
            {
                Supports newLD = new Supports();
                newLD.SupportID = AS.SupportID;
                newLD.SupportedID = AS.SupportedID;
                newLD.SuppDate = AS.SupportDate;
                newLD.ReasonID = AS.ReasonID;
                newLD.SumOfSupport = (decimal)AS.SumOfSupport;                
                newLD.Details = AS.Details;
                newLD.ResponsibleID = AS.ResponsibleID;
                newLD.Referrer = AS.Referrer;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static SupportsDTO toSupportsDTO(Supports AS)
        {
            SupportsDTO newLD = new SupportsDTO();
            newLD.SupportID = AS.SupportID;
            newLD.SupportedID = (int)AS.SupportedID;
            newLD.supportDate = (DateTime)AS.SuppDate;
            newLD.ReasonID = (int)AS.ReasonID;
            newLD.SumOfSupport = (double)AS.SumOfSupport;            
            newLD.Details = AS.Details;
            newLD.ResponsibleID = (int)AS.ResponsibleID;
            newLD.Referrer = AS.Referrer;            
            return newLD;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<SupportsDTO> toDTO_List(List<Supports> AS)
        {
            List<SupportsDTO> AList = new List<SupportsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toSupportsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Supports> toTBL_List(List<SupportsDTO> AS)
        {
            List<Supports> AList = new List<Supports>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toSupports(item));
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
