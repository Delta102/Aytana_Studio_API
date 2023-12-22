using AM_Api.Models.Appointment;

namespace AM_Api.Models.User
{
    public class Users : UserPrincipalModel
    {
        public string PhoneNumber { get; set; }
        public Appointments PurchasedAppointments { get; set; }
    }
}
