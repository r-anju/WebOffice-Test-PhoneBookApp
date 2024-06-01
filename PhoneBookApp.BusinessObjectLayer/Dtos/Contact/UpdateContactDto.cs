using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessObjectLayer.Dtos
{
    public class UpdateContactDto : CreateContactDto
    {
        public long Id { get; set; }
        public long UserReferenceId { get; set; }
    }
}
