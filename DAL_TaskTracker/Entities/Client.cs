

namespace DAL_TaskTracker.Entities
{
    public class Client
    {
        //[Required(ErrorMessage = "Client Id field is required")]
        public int ClientId { get; set; }



        //[Required(ErrorMessage = "Country field is required")]
        public string Country { get; set; }
        public string Address { get; set; }


        //[Required(ErrorMessage = "Company Name field is required")]
        public string CompanyName { get; set; }


        public int UserId { get; set; }
        //public virtual User User { get; set; }
    }
}