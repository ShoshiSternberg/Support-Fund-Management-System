using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;

namespace Bll
{
    public class SupportedsBLL
    {


        //שליפת כל הנתמכים
        public static List<dynamic> GetAllSupporteds()
        {
            try
            {
                List<dynamic> list1 = new List<dynamic>();
                var list2=SupportedsDTO.toDTO_List(SupportedsDAL.GetAllSupporteds());
                foreach (var item in list2)
                {
                    dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                    MyDynamic.SupportedID = item.SupportedID;
                    MyDynamic.SupFirstName=item.SupFirstName;
                    MyDynamic.SupLastName=item.SupLastName; 
                    MyDynamic.SupportedIdentity=item.SupportedIdentity;
                    MyDynamic.SupTelephone=item.SupTelephone;   
                    MyDynamic.LayerID=item.LayerID; 
                    MyDynamic.LayerName=LayersBLL.GetLayerByID(item.LayerID).Layer;   
                    MyDynamic.StatusID=item.StatusID;   
                    MyDynamic.StatusName=StatusesBLL.GetStatusByID(item.StatusID).StatusName;
                    MyDynamic.Gambar = item.Gambar;  
                    list1.Add(MyDynamic);
                }
                return list1;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת כל הנתמכים בסטטוס שנשלח
        public static List<dynamic> GetAllSupportedsByStatus(int status)
        {
            try
            {
                return GetAllSupporteds().Where(p=>p.StatusID==status).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }


        //שליפת כל הנתמכים בשכבה שנשלחה
        public static List<dynamic> GetAllSupportedsByLayer(int layer)
        {
            try
            {
                return GetAllSupporteds().Where(p => p.LayerID == layer).ToList();
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //שליפת נתמך לפי קוד
        public static dynamic GetSupportedByID(int ID)
        {
            try
            {
                var item=SupportedsDTO.toSupportedsDTO(SupportedsDAL.GetSupportedsByID(ID));
                dynamic MyDynamic = new System.Dynamic.ExpandoObject();
                MyDynamic.SupportedID = item.SupportedID;
                MyDynamic.SupFirstName = item.SupFirstName;
                MyDynamic.SupLastName = item.SupLastName;
                MyDynamic.SupportedIdentity = item.SupportedIdentity;
                MyDynamic.SupTelephone = item.SupTelephone;
                MyDynamic.LayerID = item.LayerID;
                MyDynamic.LayerName = LayersBLL.GetLayerByID(item.LayerID).Layer;
                MyDynamic.StatusID = item.StatusID;
                MyDynamic.StatusName = StatusesBLL.GetStatusByID(item.StatusID).StatusName;
                MyDynamic.Gambar = item.Gambar;
                return MyDynamic;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //הוספת נתמך
        public static bool InsertSupported(SupportedsDTO supportedToAdd)
        {
            try
            {
                return SupportedsDAL.InsertSupporteds(SupportedsDTO.toSupporteds(supportedToAdd));
            }
            catch (Exception e)
            {
                return false;
            }
        }

        //עדכון פרטי נתמך
        public static bool UpdateSupported(SupportedsDTO supportedToApdate)
        {
            try
            {                
                return SupportedsDAL.UpdateSupporteds(SupportedsDTO.toSupporteds( supportedToApdate));
            }
            catch(Exception e)
            {
                return false;
            }

        }
    }
}
