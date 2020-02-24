using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace COMP2084MidtermW20.Models
{
    public class Party
    {
        public Party()
        {
            Election = new HashSet<Election>();
        }

        public int PartyId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Logo { get; set; }

        [InverseProperty("Party")]
        public virtual ICollection<Election> Election { get; set; }
    }
}
