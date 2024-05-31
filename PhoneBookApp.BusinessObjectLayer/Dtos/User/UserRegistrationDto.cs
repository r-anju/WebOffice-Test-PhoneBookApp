using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessObjectLayer.Dtos
{
    public class UserRegistrationDto
    {
        public string RegistrationId { get; set; }
        public string Password { get; set; }
        public string RecoveryEmail { get; set; }
    }
}
