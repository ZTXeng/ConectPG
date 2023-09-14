using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPG
{
    [Table("tabe_Class")]
    public  class Class
    {
        public int Id { get; set; }
        [StringLength(20)]
        [Required]
        public string Name { get; set; }
    }
}
