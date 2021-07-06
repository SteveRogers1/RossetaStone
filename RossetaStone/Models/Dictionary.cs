using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RossetaStone.Models
{
    public class Dictionary
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DictionaryId { get; set; } = 0;
        public string WordEng { get; set; } = "";
        public string WordRus { get; set; } = "";
    }
}
