using System.Collections.Generic;

namespace MvcPIN.Web.Models
{
    public class PinsViewModel
    {
        public ICollection<PinViewModel> Pins { get; set; }
    }
}
