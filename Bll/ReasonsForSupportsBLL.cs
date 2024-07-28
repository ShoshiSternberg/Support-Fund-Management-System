using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class ReasonsForSupportsBLL
    {
        //שליפת כל סיבות התמיכה
        public static List<ReasonsForSupportsDTO> GetAllReasonsForSupports()
        {
            try
            {
                return ReasonsForSupportsDTO.toDTO_List(ReasonsForSupportsDAL.GetAllReasonsForSupports());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת סיבת תמיכה לפי קוד
        public static ReasonsForSupportsDTO GetReasonForSupportByID(int ID)
        {
            try
            {
                return ReasonsForSupportsDTO.toReasonsForSupportsDTO(ReasonsForSupportsDAL.GetReasonsForSupportsByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת סיבת תמיכה
        public static bool InsertReasonsForSupports(ReasonsForSupportsDTO LName)
        {
            try
            {      
                return ReasonsForSupportsDAL.InsertReasonsForSupports(ReasonsForSupportsDTO.toReasonsForSupports(LName));
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //עדכון סיבת תמיכה
        public static bool UpdateReasonsForSupports(ReasonsForSupportsDTO LName)
        {
            try
            {      
                return ReasonsForSupportsDAL.UpdateReasonsForSupports(ReasonsForSupportsDTO.toReasonsForSupports(LName));
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
