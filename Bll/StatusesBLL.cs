using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
    public class StatusesBLL
    {
        //שליפת כל הסטטוסים
        public static List<StatusesDTO> GetAllStatuses()
        {
            try
            {
                return StatusesDTO.toDTO_List(StatusesDAL.GetAllStatuses());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת סטטוס לפי קוד
        public static StatusesDTO GetStatusByID(int ID)
        {
            try
            {
                return StatusesDTO.toStatusesDTO(StatusesDAL.GetStatusesByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת סטטוס
        public static bool InsertStatus( string LName)
        {
            try
            {
                StatusesDTO newld = new StatusesDTO();
                
                newld.StatusName = LName;
                

                return StatusesDAL.InsertStatuses(StatusesDTO.toStatuses(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
