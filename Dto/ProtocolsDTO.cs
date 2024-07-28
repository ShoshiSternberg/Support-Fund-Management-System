using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;


namespace Dto
{
    public class ProtocolsDTO
    {
        private int protocolID;

        public int ProtocolID
        {
            get { return protocolID; }
            set { protocolID = value; }
        }

        private int supportID;

        public int SupportID
        {
            get { return supportID; }
            set { supportID = value; }
        }

        private int supportedToProtocolID;

        public int SupportedToProtocolID
        {
            get { return supportedToProtocolID; }
            set { supportedToProtocolID = value; }
        }

        private DateTime issueDate;

        public DateTime IssueDate
        {
            get { return issueDate; }
            set { issueDate = value; }
        }

        private int reasonForProtocolID;

        public int ReasonForProtocolID
        {
            get { return reasonForProtocolID; }
            set { reasonForProtocolID = value; }
        }

        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static Protocols toProtocols(ProtocolsDTO AS)
        {
            try
            {
                Protocols newLD = new Protocols();
                newLD.ProtocolID = AS.ProtocolID;
                newLD.IssueDate = (DateTime)AS.IssueDate;
                newLD.SupportedToProtocol = (int)AS.SupportedToProtocolID;
                newLD.ReasonForProtocol = (int)AS.ReasonForProtocolID;
                newLD.SupportID = (int)AS.SupportID;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static ProtocolsDTO toProtocolsDTO(Protocols AS)
        {
            try
            {
                if (AS != null)
                {
                    ProtocolsDTO newLD = new ProtocolsDTO();
                    newLD.ProtocolID = AS.ProtocolID;
                    newLD.issueDate = (DateTime)AS.IssueDate;
                    newLD.supportedToProtocolID = (int)AS.SupportedToProtocol;
                    newLD.reasonForProtocolID = (int)AS.ReasonForProtocol;
                    newLD.SupportID = (int)AS.SupportID;
                    return newLD;
                }
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<ProtocolsDTO> toDTO_List(List<Protocols> AS)
        {
            List<ProtocolsDTO> AList = new List<ProtocolsDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProtocolsDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<Protocols> toTBL_List(List<ProtocolsDTO> AS)
        {
            List<Protocols> AList = new List<Protocols>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toProtocols(item));
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
