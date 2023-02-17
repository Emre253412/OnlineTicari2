using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace ONLİNETİCARİOTOMASYON.Models.Sınıflar
{
    public class Stok
    {
        [Key]
        public int stokid { get; set; }
        public short adet { get; set; }
        public int arızalıürünsayısı { get; set; }
        public int ürünid { get; set; }
        public Ürünler ürünler { get; set; }
    }
}