using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessObjectLayer.Dtos
{
    public class CreateContactDto
    {
        public string ContactName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public long UserReferenceId { get; set; }
    }
}
