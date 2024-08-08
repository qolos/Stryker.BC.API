using System.Text.Json.Serialization;
// Note: Properties must be public and must have { get; set; } or will return empty

namespace Stryker.BC.API.v1_0.Models
{
    public class CustomerModel
    {
        public int Customer_ID { get; set; }
        public string Customer_Name { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Notes { get; set; }
        public double Store_Credit { get; set; }
        public string Customer_Group { get; set; }
        public int Orders { get; set; }
        public DateTime Date_Joined { get; set; }
        public string Addresses { get; set; }
        public bool Receive_Marketing_Emails { get; set; }
        public string Tax_Exempt_Category { get; set; }

    }
}
