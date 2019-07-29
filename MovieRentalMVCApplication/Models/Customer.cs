using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalMVCApplication.Models
{
    public class Customer
    {
        
        public int ID { get; set; }
        [Required (ErrorMessage= "Customer Name is Mandatory")]
        [StringLength(50)]
       

        public string CustName { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        public int MembershipTypeId { get; set; }

        [Display(Name= "Date of Birth")]
        [Min18YearsMembers]
        public DateTime DOB { get; set; }
    }
}