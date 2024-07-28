using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dto;
using Dal;
namespace Bll
{
    public class ProtocolsBLL
    {

        //שליפת כל הפרוטוקולים
        public static List<dynamic> GetAllProtocols()
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2 = ProtocolsDTO.toDTO_List(ProtocolsDAL.GetAllProtocols());
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.ProtocolID = item.ProtocolID;
                    MyDynamic.SupportID = item.SupportID;
                    MyDynamic.SupportedToProtocolID = item.SupportedToProtocolID;
                    MyDynamic.SupportedToProtocolName = SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupFirstName + " " + 
                        SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupLastName;
                    MyDynamic.SupportedIdentity = SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupportedIdentity;
                    MyDynamic.IssueDate = item.IssueDate;
                    MyDynamic.ReasonForProtocolID = item.ReasonForProtocolID;
                    MyDynamic.ReasonForProtocol = ReasonsForSupportsBLL.GetReasonForSupportByID(item.ReasonForProtocolID);

                    list1.Add(MyDynamic);
                }
                return list1;

            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת פרוטוקול לפי קוד
        public static dynamic GetProtocolByID(int ID)
        {
            try
            {
                var item = ProtocolsDTO.toProtocolsDTO(ProtocolsDAL.GetProtocolsByID(ID));
                if(item == null)    
                    return null;
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.ProtocolID = item.ProtocolID;
                MyDynamic.SupportID = item.SupportID;
                MyDynamic.SupportedToProtocolID = item.SupportedToProtocolID;
                MyDynamic.SupportedToProtocolName = SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupFirstName + " " + 
                    SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupLastName;
                MyDynamic.SupportedIdentity = SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupportedIdentity;
                MyDynamic.IssueDate = item.IssueDate;
                MyDynamic.ReasonForProtocolID = item.ReasonForProtocolID;
                MyDynamic.ReasonForProtocol = ReasonsForSupportsBLL.GetReasonForSupportByID(item.ReasonForProtocolID);
                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת פרוטוקול לפי קוד תמיכה
        public static dynamic GetProtocolBySupportID(int id)
        {
            var item = ProtocolsDTO.toProtocolsDTO(ProtocolsDAL.GetProtocolsBySupportID(id));
            if(item == null)    
                return null;
            dynamic MyDynamic = new System.Dynamic.ExpandoObject();
            MyDynamic.ProtocolID = item.ProtocolID;
            MyDynamic.SupportID = item.SupportID;
            MyDynamic.SupportedToProtocolID = item.SupportedToProtocolID;
            MyDynamic.SupportedToProtocolName = SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupFirstName + " " +
                SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupLastName;
            MyDynamic.SupportedIdentity = SupportedsBLL.GetSupportedByID(item.SupportedToProtocolID).SupportedIdentity;
            MyDynamic.IssueDate = item.IssueDate;
            MyDynamic.ReasonForProtocolID = item.ReasonForProtocolID;
            MyDynamic.ReasonForProtocol = ReasonsForSupportsBLL.GetReasonForSupportByID(item.ReasonForProtocolID);

            return MyDynamic;
        }
        //הוספת פרוטוקול
        public static bool InsertProtocol(ProtocolsDTO newld)
        {
            try
            {
                return ProtocolsDAL.InsertProtocols(ProtocolsDTO.toProtocols(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //עדכון פרוטוקול
        public static bool UpdateProtocol(int id, ProtocolsDTO newld)
        {
            try
            {
                return ProtocolsDAL.UpdateProtocols(id, ProtocolsDTO.toProtocols(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }



    }
}
