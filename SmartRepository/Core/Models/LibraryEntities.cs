using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SmartRepository.Core.Models
{
    public class lib_region
    {
        //reference: https://psgc.gitlab.io/api/
        [Key]
        public virtual string regionCode { get; set; }
        public virtual string name { get; set; }
        public virtual string regionName { get; set; }
        public virtual string islandGroupCode { get; set; }
    }

    public class lib_province
    {
        //reference: https://psgc.gitlab.io/api/
        [Key]
        public virtual string provinceCode { get; set; }
        public virtual string provinceName { get; set; }
        public virtual string regionCode { get; set; }
        public virtual string islandGroupCode { get; set; }
    }

    public class lib_city
    {
        //reference: https://psgc.gitlab.io/api/
        [Key]
        public virtual string cityCode { get; set; }
        public virtual string cityName { get; set; }
        public virtual string oldName { get; set; }
        public virtual bool isCapital { get; set; }
        public virtual string regionCode { get; set; }
        public virtual string provinceCode { get; set; }
        public virtual string islandGroupCode { get; set; }
    }

    public class lib_barangay
    {
        //reference: https://psgc.gitlab.io/api/
        [Key]
        public virtual string barangayCode { get; set; }
        public virtual string barangayName { get; set; }
        public virtual string oldName { get; set; }
        public virtual string cityCode { get; set; }
        public virtual string provinceCode { get; set; }
        public virtual string regionCode { get; set; }
        public virtual string islandGroupCode { get; set; }
    }
}
