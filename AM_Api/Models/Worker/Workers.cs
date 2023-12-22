using AM_Api.Models.Appointment;

namespace AM_Api.Models.Worker
{
    public class Workers : UserPrincipalModel
    {
        public List<Appointments> AppointmentsAttended { get; set; }
    }
}
