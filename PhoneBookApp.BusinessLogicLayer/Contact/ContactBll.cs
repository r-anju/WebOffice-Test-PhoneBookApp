using PhoneBookApp.BusinessObjectLayer.Dtos;
using PhoneBookApp.DataAccessLayer;
using PhoneBookApp.DataAccessLayer.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessLogicLayer
{
    public class ContactBll
    {
        private readonly ContactDal _contactDal;
        private readonly UnitOfWork _uow;
        public ContactBll()
        {
            _contactDal = new ContactDal();
            _uow = new UnitOfWork(_contactDal.Context);
        }

        public List<ContactDto> GetAllContactsByUser(long userId)
        {
            try
            {
                var contactList = _contactDal.FindBy(item => (bool)!item.IsDeleted && item.UserReferenceId == userId)
                    .Select(item => new ContactDto
                    {
                        Id = item.Id,
                        ContactName = item.ContactName,
                        EmailAddress = item.EmailAddress,
                        PhoneNumber = item.PhoneNumber,
                    }).ToList();
                return contactList;
            }
            catch (Exception)
            {

                throw;
            }
        }


        public (bool Status, string Message) DeleteContact(long contactId, long userId)
        {
            try
            {
                var contact = _contactDal.FindBy(item => (bool)!item.IsDeleted && item.Id == contactId && item.UserReferenceId == userId)
                    .FirstOrDefault();
                if (contact == null)
                {
                    return (false, "Invalid Contact Id");
                }
                contact.IsDeleted = true;
                _contactDal.Update(contact);
                if (_uow.Save() <= 0)
                {
                    return (false, "Failed to delete contact");
                }
                return (true, "Contact deleted succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public ContactDto GetSingleContact(long contactId, long userId)
        {
            try
            {
                var contact = _contactDal.FindBy(item => (bool)!item.IsDeleted && item.Id == contactId && item.UserReferenceId == userId)
                    .FirstOrDefault();
                if (contact == null)
                {
                    return null;
                }
                var contactDto = new ContactDto
                {
                    ContactName = contact.ContactName,
                    EmailAddress = contact.EmailAddress,
                    PhoneNumber = contact.PhoneNumber,
                    Id = contact.Id,
                };
                return contactDto;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public (bool Status, string Message) AddContact(CreateContactDto createContactDto)
        {
            try
            {
                var contactExist = _contactDal.FindBy(item => (bool)!item.IsDeleted && (item.EmailAddress == createContactDto.EmailAddress.Trim() || item.PhoneNumber == createContactDto.PhoneNumber.Trim())).ToList();
                if (contactExist != null && contactExist.Any())
                {
                    var emailExist = contactExist.FirstOrDefault(x => x.EmailAddress == createContactDto.EmailAddress);
                    if (emailExist != null)
                        return (false, $"Email Address already exist in Contact {emailExist.ContactName}");
                    var phoneExist = contactExist.FirstOrDefault(x => x.PhoneNumber == createContactDto.PhoneNumber.Trim());
                    if (phoneExist != null)
                        return (false, $"Phone number already exist in Contact {phoneExist.ContactName}");
                }
                var contact = new Contacts
                {
                    ContactName = createContactDto.ContactName,
                    PhoneNumber = createContactDto.PhoneNumber,
                    EmailAddress = createContactDto.EmailAddress,
                    UserReferenceId = createContactDto?.UserReferenceId,
                    IsDeleted = false,
                };
                _contactDal.Add(contact);
                if (_uow.Save() <= 0)
                {
                    return (false, $"Failed to save contact");
                }
                return (true, $"Contact created succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
        public (bool Status, string Message) UpdateContact(UpdateContactDto updateContactDto)
        {
            try
            {
                var contactExist = _contactDal.FindBy(item => (bool)!item.IsDeleted && item.Id != updateContactDto.Id && (item.EmailAddress == updateContactDto.EmailAddress.Trim() || item.PhoneNumber == updateContactDto.PhoneNumber.Trim())).ToList();
                if (contactExist != null && contactExist.Any())
                {
                    var emailExist = contactExist.FirstOrDefault(x => x.EmailAddress == updateContactDto.EmailAddress);
                    if (emailExist != null)
                        return (false, $"Email Address already exist in Contact {emailExist.ContactName}");
                    var phoneExist = contactExist.FirstOrDefault(x => x.PhoneNumber == updateContactDto.PhoneNumber.Trim());
                    if (phoneExist != null)
                        return (false, $"Phone number already exist in Contact {phoneExist.ContactName}");
                }
                var contact = _contactDal.FindBy(item => (bool)!item.IsDeleted && item.Id == updateContactDto.Id && item.UserReferenceId == updateContactDto.UserReferenceId).FirstOrDefault();
                if (contact == null)
                {
                    return (false, "Invalid contact Id");
                }
                contact.Id = updateContactDto.Id;
                contact.ContactName = updateContactDto.ContactName;
                contact.PhoneNumber = updateContactDto.PhoneNumber;
                contact.EmailAddress = updateContactDto.EmailAddress;
                _contactDal.Update(contact);
                if (_uow.Save() <= 0)
                {
                    return (false, $"Failed to update contact");
                }
                return (true, $"Contact updated succesfully");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
