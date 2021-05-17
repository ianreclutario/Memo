using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Memo.Models
{
    public class Header
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public string To { get; set; }
        public string Date { get; set; }
        public string Address { get; set; }
        public string Store { get; set; }
        public string Text { get; set; }
        public string Amount { get; set; }
        public string Pesos { get; set; }
        public string Reference { get; set; }

    }
}