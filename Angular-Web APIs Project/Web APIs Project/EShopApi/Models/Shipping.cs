using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    public enum Cities
    {
        Qena = 1,
        Luxor = 4,
        Cairo = 8,
        Aswan = 16,
        Sohag = 32,
        Assiut = 128,
    }
    [Table("Shipping"), MetadataType(typeof(ShippingMetaData))]
    public class Shipping
    {
        public int Shipping_ID { get; set; }
        public string Shipping_Email { get; set; }
        public string Shipping_FName { get; set; }
        public string Shipping_LName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int? Postal_Code { get; set; }
        public Cities City { get; set; }
        public long Phone1 { get; set; }
        public long? Phone2 { get; set; }
        public string Notes { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}