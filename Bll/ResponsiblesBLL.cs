using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Dto;
namespace Bll
{
    public class ResponsiblesBLL
    {

        //שליפת כל האחראיים
        public static List<ResponsiblesDTO> GetAllResponsibles()
        {
            try
            {
                return ResponsiblesDTO.toDTO_List(ResponsiblesDAL.GetAllResponsibles());
            }
            catch (Exception e)
            {
                return null;
            }
        }

        //שליפת אחראי לפי קוד
        public static ResponsiblesDTO GetResponsibleByID(int ID)
        {
            try
            {
                return ResponsiblesDTO.toResponsiblesDTO(ResponsiblesDAL.GetResponsiblesByID(ID));
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //כל האחראיים שמשתתפים בישיבות- בשביל הפרוטוקולים
        public static List<string> GetNamesOfparticipants()
        {
            try
            {
                List<ResponsiblesDTO> list=GetAllResponsibles();
                List<string> ans=new List<string>();
                foreach(ResponsiblesDTO responsible in list)
                {
                    if (responsible.Participant == true)
                        ans.Add(responsible.ResponsibleName);
                }
                return ans;
            }
            catch(Exception e)
            {
                return null;
            }
        }
        //מקבל שם אחראי וסיסמה ומחזיר איזו הרשאת גישה יש לו- אמת מלאה שקר חלקית
        public static bool IsAllowingAccess(string name, string password)
        {
            try
            {
                //שליפת האחראי
                ResponsiblesDTO res = GetAllResponsibles().FirstOrDefault(p => (p.ResponsibleName == name) && (p.LoginPassword == password));
                return res.AllowingAccess;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        //מקבל שם אחראי וסיסמה ומחזיר את האחראי או נאל אם לא מצא
        public static ResponsiblesDTO GetResponsibleByNameAndPassword(string name, string password)
        {
            try
            {
                //שליפת האחראי
                ResponsiblesDTO res = GetAllResponsibles().FirstOrDefault(p => (p.ResponsibleName == name) && (p.LoginPassword == password));
                return res;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        //מחזיר את כל האחראיים עם הרשאת הגישה המלאה אם אלוו=אמת אחרת את האחראיים עם הרשאה חלקית
        public static List<ResponsiblesDTO> GetAllResponsiblesByAllowingAccess(bool Allow)
        {
            try
            {
                return GetAllResponsibles().Where(p => (IsAllowingAccess(p.ResponsibleName, p.LoginPassword) == Allow)).ToList();
            }
            catch(Exception e)
            {
                return null;
            }
        }
        //הוספת אחראי
        public static bool InsertResponsible( ResponsiblesDTO newld)
        {
            try
            {               
                return ResponsiblesDAL.InsertResponsibles(ResponsiblesDTO.toResponsibles(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }
        
        //הוספת אחראי
        public static bool UpdateResponsible( ResponsiblesDTO newld)
        {
            try
            {               
                return ResponsiblesDAL.UpdateResponsible(ResponsiblesDTO.toResponsibles(newld));
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
