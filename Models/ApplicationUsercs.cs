using Microsoft.AspNetCore.Identity;

namespace CLDV_Part2.Models
{
    public class ApplicationUsercs : IdentityUser
    {
        public String Firstname { get; set; }
        public String Lastname { get; set; }
    }
}
