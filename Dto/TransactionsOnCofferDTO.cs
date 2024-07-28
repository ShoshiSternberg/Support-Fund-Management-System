using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
namespace Dto
{
    public class TransactionsOnCofferDTO
    {
        private int transactionID;

        public int TransactionID
        {
            get { return transactionID; }
            set { transactionID = value; }
        }

        private DateTime transactionDate;

        public DateTime TransactionDate
        {
            get { return transactionDate; }
            set { transactionDate = value; }
        }

        private int typeOfExpensesAndIncome;

        public int TypeOfExpensesAndIncome
        {
            get { return typeOfExpensesAndIncome; }
            set { typeOfExpensesAndIncome = value; }
        }

        private double transactionSum;

        public double TransactionSum
        {
            get { return transactionSum; }
            set { transactionSum = value; }
        }

        private int supportID;

        public int SupportID
        {
            get { return supportID; }
            set { supportID = value; }
        }

        private int year;

        public int Year
        {
            get { return year; }
            set { year = value; }
        }
        private bool blackOrWhite;

        public bool BlackOrWhite
        {
            get { return blackOrWhite; }
            set { blackOrWhite = value; }
        }


        //פונקציות המרה

        //המרת אוביקט שלנו לאוביקט של מיקרוסופט
        public static TransactionsOnCoffer toTransactionsOnCofferDAL(TransactionsOnCofferDTO AS)
        {
            try
            {
                TransactionsOnCoffer newLD = new TransactionsOnCoffer();
                newLD.TransactionID = AS.TransactionID;
                newLD.TransactionDate = AS.TransactionDate;
                newLD.TypeOfExpensesAndIncome = AS.TypeOfExpensesAndIncome;
                newLD.TransactionSum = (decimal)AS.TransactionSum;
                newLD.SupportID = AS.SupportID;
                newLD.Year = AS.Year;
                newLD.BlackOrWhite = AS.BlackOrWhite;
                return newLD;
            }
            catch
            {
                return null;
            }
        }

        // המרת אוביקט מיקרוסופט  לאוביקט שלנו 
        public static TransactionsOnCofferDTO toTransactionsOnCofferDTO(TransactionsOnCoffer AS)
        {
            TransactionsOnCofferDTO newLD = new TransactionsOnCofferDTO();
            newLD.TransactionID = AS.TransactionID;
            newLD.TransactionDate = (DateTime)AS.TransactionDate;
            newLD.TypeOfExpensesAndIncome = (int)AS.TypeOfExpensesAndIncome;
            newLD.TransactionSum = (int)AS.TransactionSum;
            newLD.SupportID = (int)AS.SupportID;
            newLD.Year = (int)AS.Year;
            newLD.blackOrWhite = (bool)AS.BlackOrWhite;
            return newLD;
        }


        //המרת אוסף ממיקרוסופט לשלנו
        public static List<TransactionsOnCofferDTO> toDTO_List(List<TransactionsOnCoffer> AS)
        {
            List<TransactionsOnCofferDTO> AList = new List<TransactionsOnCofferDTO>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toTransactionsOnCofferDTO(item));
                }
                return AList;
            }
            catch (Exception e)
            {
                return null;
            }


        }
        //המרת אוסף  שלנו לשל מיקרוסופט
        public static List<TransactionsOnCoffer> toTBL_List(List<TransactionsOnCofferDTO> AS)
        {
            List<TransactionsOnCoffer> AList = new List<TransactionsOnCoffer>();
            try
            {
                foreach (var item in AS)
                {
                    AList.Add(toTransactionsOnCofferDAL(item));
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
