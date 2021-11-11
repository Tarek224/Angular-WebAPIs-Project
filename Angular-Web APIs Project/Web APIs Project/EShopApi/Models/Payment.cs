using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EShopApi.Models
{
    [Table("Payment"), MetadataType(typeof(PaymentMetaData))]
    public class Payment
    {
        public int Payment_ID { get; set; }
        public string Payment_Method { get; set; }
        public int Payment_Status { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}