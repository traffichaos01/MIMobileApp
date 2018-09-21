using System;
using System.Text.RegularExpressions;
namespace MIMobileApp.Classes
{
    public class FIeldValidationCheck
    {
        //FIeldValidationCheck
        //Check to see if string has special characters
		public static string HasSpecialChars(string testString){
			var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
			return regexItem.IsMatch(testString).ToString();
		}
    }
}
