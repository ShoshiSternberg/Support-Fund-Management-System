using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class AnnualSummaryBLL
    {



        //שליפת כל הסיכומים השנתיים
        public static List<AnnualSummaryDTO> GetAnnualSummaries()
        {
            try
            {
                return AnnualSummaryDTO.toDTO_List(AnnualSummaryDAL.GetAllAnnualSummary());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת סיכום לפי שנה
        public static AnnualSummaryDTO GetAnnualSummaryByYear(int year)
        {
            try
            {                
                return AnnualSummaryDTO.ToAnnualSummaryDTO(AnnualSummaryDAL.GetAnnualSummaryByYear(year));
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת סיכום שנתי
        public static bool InsertAnnualSummary(AnnualSummaryDTO newld)
        {
            try
            {                
                return AnnualSummaryDAL.InsertAnnualSummary(AnnualSummaryDTO.toAnnualSummaryDAL(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }
        //עדכון יתרה נוכחית- מתבצע בכל הוספת תנועה או עדכון סכום תנועה
        public static bool UpdateCurrentBalance(int year, double sum, bool white)
        {
            try
            {                
                if (white == true)
                    AnnualSummaryDAL.UpdateBalance(year, 0, sum);
                else
                    AnnualSummaryDAL.UpdateBalance(year, sum, 0);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
