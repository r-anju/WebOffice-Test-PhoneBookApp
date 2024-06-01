using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessObjectLayer.Dtos
{
    public class UserRegistrationDto
    {
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string NickName { get; set; }
    }
}
