using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DanceCon.Models
{
    public class ContestModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Required."), StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string City { get; set; }



        public static List<SelectListItem> Category = new List<SelectListItem>
        {
            new SelectListItem("HipHop", "1"),
            new SelectListItem("Breaking", "2"),
            new SelectListItem("Popping","3"),
            new SelectListItem("House","4"),
            new SelectListItem("Waacking","5"),
            new SelectListItem("Locking","6"),
            new SelectListItem("AllStyles","7")

        };

        public static List<SelectListItem> Types = new List<SelectListItem>
        {
            new SelectListItem("Adults", "1"),
            new SelectListItem("Kids", "2"),
            new SelectListItem("Open","3")

        };
        [Required(ErrorMessage = "Required.")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Required.")]
        public string Categories { get; set; }

        public string TypeText
        {
            get
            {
                //var type = Types.First(x => x.Value == Type);
                //return type.Text;
                return Types.First(x => x.Value == Type).Text;
            }
        }

        public string CategoryText
        {
            get
            {
                //var type = Types.First(x => x.Value == Type);
                //return type.Text;
                return Category.First(x => x.Value == Categories).Text;
            }
        }


        [Required(ErrorMessage = "Required."), StringLength(1000, ErrorMessage = "Title cannot be longer than 50 characters.")]
        public string Description { get; set; }

        // public bool Important { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime AddedDate { get; set; }
        [Required(ErrorMessage = "Required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ContestDate { get; set; }
        public string _UserID { get; set; }

        public IFormFile Photo { get; set; }

    }
}
