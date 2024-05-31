using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessObjectLayer.Dtos
{
    public class UserDto
    {
        public long Id { get; set; }
        public string RegistrationId { get; set; }
        public string Password { get; set; }
        public string RecoveryEmail { get; set; }
        public string OneTimePassword { get; set; }
    }
}
