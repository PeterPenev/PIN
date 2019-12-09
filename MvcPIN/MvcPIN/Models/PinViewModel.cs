using System.ComponentModel.DataAnnotations;

namespace MvcPIN.Web.Models
{
    public class PinViewModel
    {
        public int Id { get; set; }

        [StringLength(10, MinimumLength = 10)]
        public string Name { get; set; }

        public string MessageText { get; set; }

        //when is valid will be set to true and button add to database will be rendered, based on this condition 
        public bool IsValid { get; set; }

    }

}
