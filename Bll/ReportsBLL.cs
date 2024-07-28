using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
using System.Collections;

namespace Bll
{
    public class ReportsBLL
    {
        //שליפת כל הדיווחים
        public static List<dynamic> GetAllReports()
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = ReportsDTO.toDTO_List(ReportsDAL.GetAllReports());
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.ReportID = item.ReportID;
                    MyDynamic.SupportedID=item.SupportedID;
                    MyDynamic.SupportedName=SupportedsBLL.GetSupportedByID(item.SupportedID).SupFirstName+" "+ 
                        SupportedsBLL.GetSupportedByID(item.SupportedID).SupLastName;
                    MyDynamic.ReportDate=item.ReportDate;
                    MyDynamic.Details=item.Details;
                    MyDynamic.ResponsibleID=item.ResponsibleID; 
                    MyDynamic.ResponsibleName=ResponsiblesBLL.GetResponsibleByID(item.ResponsibleID).ResponsibleName;
                    list1.Add(MyDynamic);
                }
                return list1;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת דיווח לפי קוד
        public static dynamic GetReportByID(int ID)
        {
            try
            {
                ReportsDTO item= ReportsDTO.toReportsDTO(ReportsDAL.GetReportsByID(ID));
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.ReportID = item.ReportID;
                MyDynamic.SupportedID = item.SupportedID;
                MyDynamic.SupportedName = SupportedsBLL.GetSupportedByID(item.SupportedID).SupFirstName + " " + 
                      SupportedsBLL.GetSupportedByID(item.SupportedID).SupLastName;
                MyDynamic.ReportDate = item.ReportDate;
                MyDynamic.Details = item.Details;
                MyDynamic.ResponsibleID = item.ResponsibleID;
                MyDynamic.ResponsibleName = ResponsiblesBLL.GetResponsibleByID(item.ResponsibleID).ResponsibleName;
                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל הדיווחים של נתמך מסוים
        public static List<dynamic> GetAllReportsBySupported(int id)
        {
            try
            {
                var list1 = ReportsBLL.GetAllReports().Where(p => p.SupportedID == id).ToList();
                return list1;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //הוספת דיווח
        public static bool InsertReport(ReportsDTO newld)
        {
            try
            {
                return ReportsDAL.InsertReports(ReportsDTO.toReports(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //עדכון דיווח
        public static bool UpdateReport(ReportsDTO report)
        {
            try
            {
                return ReportsDAL.UpdateReport(ReportsDTO.toReports( report));
            }
            catch(Exception e)
            {
                return false;
            }
        }
        //מחיקת דיווח
        public static bool RemoveReport(int report)
        {
            try
            {
                return ReportsDAL.RemoveReport( report);
            }
            catch(Exception e)
            {
                return false;
            }
        }

    }
}
