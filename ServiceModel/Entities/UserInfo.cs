using ServiceModel.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceModel.Entities
{
    public class UserInfo
    {
        [Required]
        public EnableOption FirstName { get; set; }
        [Required]
        public EnableOption LastName { get; set; }
        [Required]
        public EnableOption Email { get; set; }
        public EnableOption Phone { get; set; }
        public EnableOption Nationality { get; set; }
        public EnableOption CurrentResidence { get; set; }
        public EnableOption IDNumber { get; set; }
        public EnableOption DateofBirth { get; set; }
        public EnableOption Gender { get; set; }
        public string userId { get; set; }
    }
}
