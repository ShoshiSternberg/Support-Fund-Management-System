using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;

namespace Dto
{
    public class AnnualSummaryDTO
    {
        public int Year { get; set; }

        public double OpeningBalance { get; set; }

        public double CurrentBlackBalance { get; set; }

        public double CurrentWhiteBalance { get; set; }

        public double TerminationBalance { get; set; }
        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static AnnualSummary toAnnualSummaryDAL(AnnualSummaryDTO AS)
        {
            try
            {
                AnnualSummary newAnn = new AnnualSummary();
                newAnn.Year = AS.Year;
                newAnn.OpeningBalance = (decimal)AS.OpeningBalance;
                newAnn.CurrentBlackBalance = (decimal)AS.CurrentBlackBalance;
                newAnn.CurrentWhiteBalance = (decimal)AS.CurrentWhiteBalance;
                newAnn.TerminationBalance = (decimal)AS.TerminationBalance;
                return newAnn;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 

        public static AnnualSummaryDTO ToAnnualSummaryDTO(AnnualSummary AS)
        {
            try
            {
                AnnualSummaryDTO newld = new AnnualSummaryDTO();
                newld.Year = AS.Year;
                newld.CurrentBlackBalance = (double)AS.CurrentBlackBalance;
                newld.CurrentWhiteBalance = (double)AS.CurrentWhiteBalance;
                newld.OpeningBalance = (double)AS.OpeningBalance;
                newld.TerminationBalance = (double)AS.TerminationBalance;
                return newld;
            }
            catch (Exception ex)
            {
                // log the exception
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        //המרת אוסף ממיקרוסופט לשלנו
        public static List<AnnualSummaryDTO> toDTO_List(List<AnnualSummary> AS)
        {
            List<AnnualSummaryDTO> AList = new List<AnnualSummaryDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(ToAnnualSummaryDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<AnnualSummary> toTBL_List(List<AnnualSummaryDTO> AS)
        {
            List<AnnualSummary> AList = new List<AnnualSummary>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toAnnualSummaryDAL(item));
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
