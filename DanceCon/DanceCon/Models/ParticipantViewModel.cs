using System;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace DanceCon.Models
{
    public class ParticipantViewModel
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Required."), StringLength(50, ErrorMessage = "Name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string City { get; set; }
        [ForeignKey("Contests")]
        public int _ContestID { get; set; }

       [Required(ErrorMessage = "Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public string _UserID { get; set; }

    }
   
}
