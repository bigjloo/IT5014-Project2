using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{   
    // Generates password from:
    // First 2 characters of staffID
    // + hexadecimal of ticketNumber
    // + hexadecimal of first three characters of timestamp
    public static class PasswordGenerator
    {
        public static string GeneratePassword(string staffID, uint ticketNumber)
        {
            string passwordFirstBlock = staffID.Substring(0, 2);
            string passwordSecondBlock = UintToHex(ticketNumber);
            string passwordFinalBlock = DateTimeToHex();

            var password = passwordFirstBlock + passwordSecondBlock + passwordFinalBlock;
            return password;
        }

        private static string UintToHex(uint uinteger)
        {
            string hexString = uinteger.ToString("X");
            return hexString;
        }

        private static string DateTimeToHex()
        {
            //int[] hexArray = new int[numberOfChar];
            //var subString = dateTime.ToString().Substring(0, numberOfChar);
            //for (var i = 0; i < numberOfChar; i++)
            //{
            //    hexArray[i] = Convert.ToInt32(subString[i]);
            //}
            //string hexString = string.Join("", hexArray);
            //return hexString;
            var subString = DateTime.Now.ToString().Substring(0, 3);
            //var hexString = Convert.ToInt32(subString).ToString();
            byte[] ba = Encoding.Default.GetBytes(subString);
            var hexString = BitConverter.ToString(ba);
            hexString = hexString.Replace("-", "");
            return hexString;
        }

    }
}
