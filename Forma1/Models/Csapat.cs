using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Forma1.Models
{
    public class Csapat
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string Nev { get; set; }

        [Range(1950,2020, ErrorMessage = "Az alapítás éve 1950 és 2020 közt kell legyen")]
        public int Alapitas { get; set; }

        [Range(0, Double.PositiveInfinity, ErrorMessage ="A megnyert bajnokságok száma csak pozitív lehet")]
        public int Bajnoksagok { get; set; }
        public bool Fizetes { get; set; }
    }
}
