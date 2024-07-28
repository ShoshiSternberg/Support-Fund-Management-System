using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using System.Drawing.Imaging;
using System.IO;

namespace Dto
{
    public class SupportedsDTO
    {
        public int SupportedID { get; set; }

        public string SupFirstName { get; set; }

        public string SupLastName { get; set; }

        public int LayerID { get; set; }

        public string SupTelephone { get; set; }

        public int StatusID { get; set; }

        public string SupportedIdentity { get; set; }

        public byte[] Gambar { get; set; }
        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Supporteds toSupporteds(SupportedsDTO AS)
        {
            try
            {
                Supporteds newLD = new Supporteds();
                newLD.SupportedID = AS.SupportedID;
                newLD.SupFirstName = AS.SupFirstName;
                newLD.SupLastName = AS.SupLastName;
                newLD.LayerID = AS.LayerID;
                newLD.SupTelephone = AS.SupTelephone;
                newLD.StatusID = AS.StatusID;
                newLD.SupportedIdentity = AS.SupportedIdentity;
                newLD.gambar = AS.Gambar;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static SupportedsDTO toSupportedsDTO(Supporteds AS)
        {
            try
            {
                SupportedsDTO newLD = new SupportedsDTO();
                newLD.SupportedID = AS.SupportedID;
                newLD.SupFirstName = AS.SupFirstName;
                newLD.SupLastName = AS.SupLastName;
                newLD.LayerID = (int)AS.LayerID;
                newLD.SupTelephone = AS.SupTelephone;
                newLD.StatusID = (int)AS.StatusID;
                newLD.SupportedIdentity = AS.SupportedIdentity;
                newLD.Gambar = AS.gambar;
                return newLD;
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<SupportedsDTO> toDTO_List(List<Supporteds> AS)
        {
            List<SupportedsDTO> AList = new List<SupportedsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toSupportedsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Supporteds> toTBL_List(List<SupportedsDTO> AS)
        {
            List<Supporteds> AList = new List<Supporteds>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toSupporteds(item));
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
