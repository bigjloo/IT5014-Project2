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
    // + hexadecimal of first three characters of timestamp (using milliseconds)
    public static class PasswordGenerator
    {
        public static string GeneratePassword(string staffID, uint ticketNumber)
        {
            string passwordFirstBlock = staffID.Substring(0, 2);
            string passwordSecondBlock = UintToHex(ticketNumber);
            string passwordFinalBlock = StringToHex(DateTime.Now.Millisecond.ToString());
            var password = passwordFirstBlock + passwordSecondBlock + passwordFinalBlock;
            return password;
        }

        private static string StringToHex(string originalString)
        {
            byte[] bytes = Encoding.Default.GetBytes(originalString);
            string hexString = BitConverter.ToString(bytes);
            hexString = hexString.Replace("-", "");
            return hexString;
        }

        private static string UintToHex(uint integer)
        {
            string hexString = integer.ToString("X");
            return hexString;
        }
    }
}
