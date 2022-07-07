using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SmartRepository.Core.Models
{
    public class User
    {
        [Key]
        public virtual Guid userId { get; set; }
        public virtual string userName { get; set; }
        public virtual string salt { get; set; }
        public virtual string hash_code { get; set; }
        [NotMapped]
        public virtual string password { get; set; }
        [NotMapped]
        public virtual string confirmPassword { get; set; }
        public virtual string deleted_by { get; set; }
        public virtual DateTime? deleted_date { get; set; }
        public virtual bool is_deleted { get; set; }
    }
}
