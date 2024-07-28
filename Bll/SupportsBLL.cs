using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
    public class SupportsBLL
    {
        //שליפת כל התמיכות
        public static List<dynamic> GetAllSupports()
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = SupportsDTO.toDTO_List(SupportsDAL.GetAllSupports());
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.SupportID=item.SupportID; 
                    MyDynamic.SupportedID=item.SupportedID; 
                    MyDynamic.SupportedName=SupportedsBLL.GetSupportedByID(item.SupportedID).SupFirstName+" "+ 
                        SupportedsBLL.GetSupportedByID(item.SupportedID).SupLastName;
                    MyDynamic.SupportDate=item.SupportDate;
                    MyDynamic.ReasonID=item.ReasonID;   
                    MyDynamic.Reason=ReasonsForSupportsBLL.GetReasonForSupportByID(item.ReasonID).ReasonForSupport;
                    MyDynamic.SumOfSupport=item.SumOfSupport;
                    MyDynamic.Details=item.Details;
                    MyDynamic.ResponsibleID=item.ResponsibleID;
                    MyDynamic.ResponsibleName=ResponsiblesBLL.GetResponsibleByID(item.ResponsibleID).ResponsibleName;
                    MyDynamic.Referrer=item.Referrer;                      
                    
                    list1.Add(MyDynamic);
                }
                return list1;
                
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת תמיכה לפי קוד תמיכה
        public static dynamic GetSupportAndAllProducts(int id)
        {
            try
            {
                var item=SupportsDTO.toSupportsDTO(SupportsDAL.GetSupportsByID(id));
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.SupportID = item.SupportID;
                MyDynamic.SupportedID = item.SupportedID;
                MyDynamic.SupportedName = SupportedsBLL.GetSupportedByID(item.SupportedID).SupFirstName + " " + 
                    SupportedsBLL.GetSupportedByID(item.SupportedID).SupLastName;
                MyDynamic.SupportedIdentity = SupportedsBLL.GetSupportedByID(item.SupportedID).SupportedIdentity;
                MyDynamic.SupportDate = item.SupportDate;
                MyDynamic.ReasonID = item.ReasonID;
                MyDynamic.Reason = ReasonsForSupportsBLL.GetReasonForSupportByID(item.ReasonID).ReasonForSupport;
                MyDynamic.SumOfSupport = item.SumOfSupport;
                MyDynamic.Details = item.Details;
                MyDynamic.ResponsibleID = item.ResponsibleID;
                MyDynamic.ResponsibleName = ResponsiblesBLL.GetResponsibleByID(item.ResponsibleID).ResponsibleName;
                MyDynamic.Referrer = item.Referrer;               

                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל התמיכות של נתמך מסוים- לפי קוד נתמך
        public static List<dynamic> GetAllSupportsBySupported(int ID)
        {
            try
            {
                var list1 = GetAllSupports().Where(p => p.SupportedID == ID).ToList();

                return list1;
            }
            catch (Exception e)
            {
                return null;
            }
        }

       //שליפת תמיכה לפי קוד תמיכה
        public static dynamic GetSupportByID(int ID)
        {
            try
            {
                var item = SupportsDTO.toSupportsDTO(SupportsDAL.GetSupportsByID(ID));
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.SupportID = item.SupportID;
                MyDynamic.SupportedID = item.SupportedID;
                MyDynamic.SupportedName = SupportedsBLL.GetSupportedByID(item.SupportedID).SupFirstName + " " + 
                    SupportedsBLL.GetSupportedByID(item.SupportedID).SupLastName;
                MyDynamic.SupportedIdentity= SupportedsBLL.GetSupportedByID(item.SupportedID).SupportedIdentity;    
                MyDynamic.SupportDate = item.SupportDate;
                MyDynamic.ReasonID = item.ReasonID;
                MyDynamic.Reason = ReasonsForSupportsBLL.GetReasonForSupportByID(item.ReasonID).ReasonForSupport;
                MyDynamic.SumOfSupport = item.SumOfSupport;
                MyDynamic.Details = item.Details;
                MyDynamic.ResponsibleID = item.ResponsibleID;
                MyDynamic.ResponsibleName = ResponsiblesBLL.GetResponsibleByID(item.ResponsibleID).ResponsibleName;
                MyDynamic.Referrer = item.Referrer;

                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת תמיכה
        public static int InsertSupport(SupportsDTO newld)
        {
            try
            {
                if (SupportsDAL.InsertSupports(SupportsDTO.toSupports(newld)) == true)
                    return SupportsDAL.GetSupportIDByDetails(SupportsDTO.toSupports(newld));
                else
                    return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
        
        //עדכון תמיכה
        public static int UpdateSupport(int id,SupportsDTO newld)
        {
            try
            {
                if (SupportsDAL.UpdateSupports(id, SupportsDTO.toSupports(newld)) == true)
                {
                    return SupportsDAL.GetSupportIDByDetails(SupportsDTO.toSupports(newld));
                }
                else
                    return 0;
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
