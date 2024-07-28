using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
   public  class SupportWayDTO
    {
        private int supportWayID;

        public int SupportWayID
        {
            get { return supportWayID; }
            set { supportWayID = value; }
        }

        private string paymentWay;

        public string PaymentWay
        {
            get { return paymentWay; }
            set { paymentWay = value; }
        }

        private string noteToProtocol;

        public string NoteToProtocol
        {
            get { return noteToProtocol; }
            set { noteToProtocol = value; }
        }

        private bool blackOrWhite;

        public bool BlackOrWhite
        {
            get { return blackOrWhite; }
            set { blackOrWhite = value; }
        }



        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static SupportWay toSupportWay(SupportWayDTO AS)
        {
            try
            {
                SupportWay newLD = new SupportWay();
                newLD.SupportWayID = AS.SupportWayID;
                newLD.PaymentWay = AS.PaymentWay;
                newLD.NoteToProtocol = AS.NoteToProtocol;
                newLD.BlackOrWhite = AS.BlackOrWhite;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static SupportWayDTO toSupportWayDTO(SupportWay AS)
        {
            try
            {
                if (AS == null)
                    return null;
                SupportWayDTO newLD = new SupportWayDTO();
                newLD.SupportWayID = AS.SupportWayID;
                newLD.PaymentWay = AS.PaymentWay;
                newLD.NoteToProtocol = AS.NoteToProtocol;
                newLD.BlackOrWhite = (bool)AS.BlackOrWhite;
                return newLD;
            }
            catch(Exception e)
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<SupportWayDTO> toDTO_List(List<SupportWay> AS)
        {
            List<SupportWayDTO> AList = new List<SupportWayDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toSupportWayDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<SupportWay> toTBL_List(List<SupportWayDTO> AS)
        {
            List<SupportWay> AList = new List<SupportWay>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toSupportWay(item));
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
