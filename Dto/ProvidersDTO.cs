using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ProvidersDTO
    {
        private int provID;

        public int ProvID
        {
            get { return provID; }
            set { provID = value; }
        }
        private string provName;

        public string ProvName
        {
            get { return provName; }
            set { provName = value; }
        }
        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Providers toProviders(ProvidersDTO AS)
        {
            try
            {
                Providers newLD = new Providers();
                newLD.ProviderID = AS.ProvID;
                newLD.ProviderName = AS.ProvName;
                return newLD;
            }
            catch
            {
                return null;
            }

        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ProvidersDTO toProvidersDTO(Providers AS)
        {
            try
            {
                if (AS == null)
                    return null;
                else
                {
                    ProvidersDTO newLD = new ProvidersDTO();
                    newLD.ProvID = AS.ProviderID;
                    newLD.ProvName = AS.ProviderName;
                    return newLD;
                }
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ProvidersDTO> toDTO_List(List<Providers> AS)
        {
            List<ProvidersDTO> AList = new List<ProvidersDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProvidersDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Providers> toTBL_List(List<ProvidersDTO> AS)
        {
            List<Providers> AList = new List<Providers>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProviders(item));
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

