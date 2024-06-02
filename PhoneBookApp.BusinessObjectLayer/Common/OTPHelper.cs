using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookApp.BusinessObjectLayer.Common
{
    public class OTPHelper
    {
        public static string GenerateOTP()
        {
            Random random = new Random();
            int sixDigitNumber = random.Next(100000, 1000000); // Generates a number between 100000 and 999999
            return sixDigitNumber.ToString();
        }
    }
}
