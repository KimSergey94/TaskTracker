

namespace TaskTracker.Models
{
    public class ClientVM
    {
        //[Required(ErrorMessage = "Client Id field is required")]
        public int ClientId { get; set; }
        public int UserId { get; set; }


        public string Country{ get; set; }
        public string Address { get; set; }


        //[Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }
        //[Required(ErrorMessage = "Company Name field is required")]
        public string CompanyName { get; set; }
    }
}