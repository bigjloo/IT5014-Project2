using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketLibrary
{   
    // Generates password from:
    // 1) First 2 characters of staffID
    // 2) hexadecimal of ticketNumber
    // 3) hexadecimal of first three characters of timestamp
    public static class PasswordGenerator
    {
        public static string GeneratePassword(string staffID, uint ticketNumber)
        {
            // First 2 characters of staffID
            string firstPasswordBlock = staffID.Substring(0, 2);

            // Hex representation of ticketNumber
            string secondPasswordBlock = IntToHex(Convert.ToInt32(ticketNumber));

            // DateTime.Now.Millisecond returns Int type range from 0-999
            string finalPasswordBlock = IntToHex(DateTime.Now.Millisecond);

            // Returns all three password blocks joined together 
            string password = firstPasswordBlock + secondPasswordBlock + finalPasswordBlock;
            return password;
        }

        // Converts Int to Hex
        private static string IntToHex(int integer)
        {
            string hexString = integer.ToString("X");
            return hexString;
        }
    }
}
