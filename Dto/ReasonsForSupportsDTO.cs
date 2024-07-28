using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ReasonsForSupportsDTO
    {
        private int reasonID;

        public int ReasonID
        {
            get { return reasonID; }
            set { reasonID = value; }
        }

        private string reasonForSupport;

        public string ReasonForSupport
        {
            get { return reasonForSupport; }
            set { reasonForSupport = value; }
        }
        private string reasonText;

        public string ReasonText
        {
            get { return reasonText; }
            set { reasonText = value; }
        }


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static ReasonsForSupports toReasonsForSupports(ReasonsForSupportsDTO AS)
        {
            try
            {

                ReasonsForSupports newLD = new ReasonsForSupports();
                newLD.ReasonID = AS.ReasonID;
                newLD.ReasonForSupports = AS.ReasonForSupport;
                newLD.ReasonText = AS.ReasonText;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ReasonsForSupportsDTO toReasonsForSupportsDTO(ReasonsForSupports AS)
        {
            try
            {
                ReasonsForSupportsDTO newLD = new ReasonsForSupportsDTO();
                newLD.ReasonID = AS.ReasonID;
                newLD.ReasonForSupport = AS.ReasonForSupports;
                newLD.reasonText = AS.ReasonText;
                return newLD;
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ReasonsForSupportsDTO> toDTO_List(List<ReasonsForSupports> AS)
        {
            List<ReasonsForSupportsDTO> AList = new List<ReasonsForSupportsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toReasonsForSupportsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<ReasonsForSupports> toTBL_List(List<ReasonsForSupportsDTO> AS)
        {
            List<ReasonsForSupports> AList = new List<ReasonsForSupports>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toReasonsForSupports(item));
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
