using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RossetaStone.Models
{
    public class Dictionary
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("English word")]
        public string WordEng { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [DisplayName("Russian word")]
        public string WordRus { get; set; }
    }
}
