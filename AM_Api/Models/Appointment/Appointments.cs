using AM_Api.Models.User;
using AM_Api.Models.Worker;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AM_Api.Models.Appointment
{
    public class Appointments
    {
        [Key]
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }

        [ForeignKey("Buyer")]
        public int BuyerId { get; set; }
        public Users Buyer { get; set; }

        [ForeignKey("Attendent")]
        public int AttendentId {  get; set; }
        public Workers Attendent { get; set; }

    }
}
