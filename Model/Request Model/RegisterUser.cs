using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace New_Curd_Operation.Model.Request_Model
{
    public class RegisterUser
    {
        public string CollegeId { get; set; }
        public string Name { get; set; }
        public string phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Department { get; set; }
    }
}
