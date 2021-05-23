using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.Models
{
    public class Header
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string  Department { get; set; }
        public DateTime EncDate { get; set; }
        public string RNo { get; set; }
        public string Type { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public string Store { get; set; }
        public string Text { get; set; }
        public string Amount { get; set; }
        public string Pesos { get; set; }
        public string Reference { get; set; }
        

        public Header(int _ID, DateTime _EncDate, string _RNo, string _Type, string _To, string _Date, string _Address, string _Store, string _Text, string _Amount, string _Pesos, string _Reference)
        {
            ID = _ID;
            EncDate = _EncDate;
            RNo = _RNo;
            Type = _Type;
            To = _To;
            Date = _Date;
            Address = _Address;
            Store = _Store;
            Text = _Text;
            Amount = _Amount;
            Pesos = _Pesos;
            Reference = _Reference;
            

        }
    }
}