using System;
using System.ComponentModel.DataAnnotations;

namespace PurchOrderWebApi.Models
{
    public class BCPurchOrder
    {
        [Key]
        public int EntryNo { get; set; }
        public string PurchOrderNo { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool Retrieved { get; set; }
    }
}
