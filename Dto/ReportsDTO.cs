using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ReportsDTO
    {
        private int reportID;

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }

        private int supportedID;

        public int SupportedID
        {
            get { return supportedID; }
            set { supportedID = value; }
        }

        private DateTime reportDate;

        public DateTime ReportDate
        {
            get { return reportDate; }
            set { reportDate = value; }
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



        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Reports toReports(ReportsDTO AS)
        {
            try
            {

                Reports newLD = new Reports();
                newLD.ReportID = AS.ReportID;
                newLD.SupportedID = AS.SupportedID;
                newLD.ReportDate = AS.ReportDate;
                newLD.Details = AS.Details;
                newLD.GabayID = AS.ResponsibleID;

                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ReportsDTO toReportsDTO(Reports AS)
        {
            try
            {

                ReportsDTO newLD = new ReportsDTO();
                newLD.ReportID = AS.ReportID;
                newLD.SupportedID = (int)AS.SupportedID;
                newLD.ReportDate = (DateTime)AS.ReportDate;
                newLD.Details = AS.Details;
                newLD.ResponsibleID = (int)AS.GabayID;
                return newLD;
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ReportsDTO> toDTO_List(List<Reports> AS)
        {
            List<ReportsDTO> AList = new List<ReportsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toReportsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Reports> toTBL_List(List<ReportsDTO> AS)
        {
            List<Reports> AList = new List<Reports>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toReports(item));
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
