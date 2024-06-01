using PhoneBookApp.BusinessObjectLayer.Common;
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
    public class UserBll
    {
        private readonly UserDal _user;
        private readonly UnitOfWork _uow;
        public UserBll()
        {
            _user = new UserDal();
            _uow = new UnitOfWork(_user.Context);
        }

        public (bool Status, string Message) AddUser(UserRegistrationDto userRegistrationDto)
        {
            try
            {
                var userExist = _user.FindBy(item => item.EmailAddress == userRegistrationDto.EmailAddress).FirstOrDefault();
                if (userExist != null)
                {
                    return (false, "User Email Address Already Exist");
                }
                var user = new Users
                {
                    EmailAddress = userRegistrationDto.EmailAddress,
                    NickName = userRegistrationDto.NickName,
                    Password = Authentication.HashPasswordWithMD5(userRegistrationDto.Password),
                    IsDeleted = false,
                };
                _user.Add(user);
                if (_uow.Save() <= 0)
                {
                    return (false, "Failed to save user details");
                }
                return (true, "User added Succesfully");
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
