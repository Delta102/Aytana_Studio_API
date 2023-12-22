using System.ComponentModel.DataAnnotations;

namespace AM_Api.Models
{
    public class UserPrincipalModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Cifrado { get; set; }
        public byte[] Password { get; set; }
    }
}