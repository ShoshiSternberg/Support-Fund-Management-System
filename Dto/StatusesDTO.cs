using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class StatusesDTO
    {
        private int statusID;

        public int StatusID
        {
            get { return statusID; }
            set { statusID = value; }
        }

        private string statusName;

        public string StatusName
        {
            get { return statusName; }
            set { statusName = value; }
        }


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Statuses toStatuses(StatusesDTO AS)
        {
            try
            {
                Statuses newLD = new Statuses();
                newLD.StatusID = AS.StatusID;
                newLD.statusName = AS.StatusName;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static StatusesDTO toStatusesDTO(Statuses AS)
        {
            try
            {
                StatusesDTO newLD = new StatusesDTO();
                newLD.StatusID = AS.StatusID;
                newLD.StatusName = AS.statusName;
                return newLD;
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<StatusesDTO> toDTO_List(List<Statuses> AS)
        {
            List<StatusesDTO> AList = new List<StatusesDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toStatusesDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Statuses> toTBL_List(List<StatusesDTO> AS)
        {
            List<Statuses> AList = new List<Statuses>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toStatuses(item));
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
