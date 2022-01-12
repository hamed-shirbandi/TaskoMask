using System.Text.RegularExpressions;

namespace TaskoMask.Domain.Share.Helpers
{
    public static class PhoneNumberValidator
    {
        public static bool IsValid(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
                return false;
            //TODO validate phoneNumber for all countries
            string MatchPhoneNumberPattern = "^[0-9]*$";
            return Regex.IsMatch(phoneNumber, MatchPhoneNumberPattern);
        }
    }
}
