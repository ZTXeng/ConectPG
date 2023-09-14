using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkPG
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birthday { get; set; }

        [NotMapped]
        public int Age
        {
            get {
               return DateTime.Now.Year-Birthday.Year;
            }
        }
        [ForeignKey(nameof(Class))]
        public int ClassId { get; set; }
        public Class Class { get; set; }    
    }
}
