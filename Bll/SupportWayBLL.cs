using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
    public class SupportWayBLL
    {
        //שליפת כל צורות התמיכה
        public static List<SupportWayDTO> GetAllSupportWays()
        {
            try
            {
                return SupportWayDTO.toDTO_List(SupportWayDAL.GetAllSupportWay());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת צורת תמיכה לפי קוד
        public static SupportWayDTO GetSupportWayByID(int ID)
        {
            try
            {
                return SupportWayDTO.toSupportWayDTO(SupportWayDAL.GetSupportWayByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת צורת התמיכה המוצעות למוצר וספק אלו
        public static List<SupportWayDTO> GetSupportWaysByProdAndProv(string product,int provider)
        {
            try
            {
                /*string ProdName = ProductsBLL.GetProductByID(product).ProdName*/                
                var products = ProductsBLL.GetProductsByName(product,provider);
                var SupportWaysCods = products.Select(s => s.SupportWayID).ToList();
                List<SupportWayDTO> ans = new List<SupportWayDTO>();
                foreach (var item in SupportWaysCods)
                {
                    ans.Add(GetSupportWayByID(item));
                }
                return ans;
            }
            catch (Exception e)
            {
                return null;
            }

        }
        
        //הוספת צורת תמיכה
        public static bool InsertSupportWay(string paymentWay, string note, bool blackOrWhite)
        {
            try
            {
                SupportWayDTO newld = new SupportWayDTO();
                
                newld.PaymentWay = paymentWay;
                newld.NoteToProtocol = note;
                newld.BlackOrWhite = blackOrWhite;
                
                return SupportWayDAL.InsertSupportWay(SupportWayDTO.toSupportWay(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
