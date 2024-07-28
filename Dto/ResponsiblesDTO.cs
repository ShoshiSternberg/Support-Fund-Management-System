using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class ResponsiblesDTO
    {
        private int responsibleID;

        public int ResponsibleID
        {
            get { return responsibleID; }
            set { responsibleID = value; }
        }

        private string responsibleName;

        public string ResponsibleName
        {
            get { return responsibleName; }
            set { responsibleName = value; }
        }

        private bool allowingAccess;

        public bool AllowingAccess
        {
            get { return allowingAccess; }
            set { allowingAccess = value; }
        }

        private string loginPassword;

        public string LoginPassword
        {
            get { return loginPassword; }
            set { loginPassword = value; }
        }

        private string responsibleTelephone;

        public string ResponsibleTelephone
        {
            get { return responsibleTelephone; }
            set { responsibleTelephone = value; }
        }

        private string responsibleEmail;

        public string ResponsibleEmail
        {
            get { return responsibleEmail; }
            set { responsibleEmail = value; }
        }

        private bool participant;

        public bool Participant
        {
            get { return participant; }
            set { participant = value; }
        }


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Responsibles toResponsibles(ResponsiblesDTO AS)
        {
            try
            {
                Responsibles newLD = new Responsibles();
                newLD.ResponsibleID = AS.ResponsibleID;
                newLD.ResponsibleName = AS.ResponsibleName;
                newLD.AllowingAccess = AS.AllowingAccess;
                newLD.LoginPassword = AS.LoginPassword;
                newLD.ResponsibleTelephone = AS.ResponsibleTelephone;
                newLD.ResponsibleEmail = AS.ResponsibleEmail;
                newLD.Participant = AS.Participant;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ResponsiblesDTO toResponsiblesDTO(Responsibles AS)
        {
            try
            {
                ResponsiblesDTO newLD = new ResponsiblesDTO();
                newLD.ResponsibleID = AS.ResponsibleID;
                newLD.ResponsibleName = AS.ResponsibleName;
                newLD.AllowingAccess = (bool)AS.AllowingAccess;
                newLD.LoginPassword = AS.LoginPassword;
                newLD.ResponsibleTelephone = AS.ResponsibleTelephone;
                newLD.ResponsibleEmail = AS.ResponsibleEmail;
                newLD.participant = (bool)AS.Participant;
                return newLD;
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ResponsiblesDTO> toDTO_List(List<Responsibles> AS)
        {
            List<ResponsiblesDTO> AList = new List<ResponsiblesDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toResponsiblesDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Responsibles> toTBL_List(List<ResponsiblesDTO> AS)
        {
            List<Responsibles> AList = new List<Responsibles>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toResponsibles(item));
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
