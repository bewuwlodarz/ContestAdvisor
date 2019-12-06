using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DanceCon.Models
{
    public class DetailViewModel
    {
        public ContestViewModel Contests { get; set; }
        public IEnumerable<Judge> Judges { get; set; }
    }
}
