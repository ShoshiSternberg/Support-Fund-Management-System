using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class ProvidersBLL
    {
        //שליפת כל הספקים
        public static List<ProvidersDTO> GetAllProviders()
        {
            try
            {
                return ProvidersDTO.toDTO_List(ProvidersDAL.GetAllProviders());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת ספק לפי קוד
        public static ProvidersDTO GetProviderByID(int ID)
        {
            try
            {
                return ProvidersDTO.toProvidersDTO(ProvidersDAL.GetProviderByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }

        }
        //שליפת כל הספקים המספקים את המוצר המבוקש
        public static List<ProvidersDTO> GetProvidersByProduct(string name)
        {
            try
            {                
                var products = ProductsBLL.GetProductsByName(name);
                var ProvidersCods = products.Select(s => s.ProviderID).ToList();                
                List<ProvidersDTO> ans = new List<ProvidersDTO>();
                foreach (var item in ProvidersCods)
                {
                    ans.Add(GetProviderByID(item));
                }
                return ans;
            }
            catch(Exception e)
            {
                return null;
            }

        }


        //הוספת ספק
        public static bool InsertProvider(string LName)
        {
            try
            {
                ProvidersDTO newld = new ProvidersDTO();

                newld.ProvName = LName;

                return ProvidersDAL.InsertProvider(ProvidersDTO.toProviders(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}

