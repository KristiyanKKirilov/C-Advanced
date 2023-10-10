using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class StationaryPhone : ICallable
    {
        public string Call(string phoneNumber)
        {
            if (!IsPhoneNumberValid(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Dialing... {phoneNumber}";
        }
        private bool IsPhoneNumberValid(string phoneNumber)
       => phoneNumber.All(c => char.IsDigit(c));
    }
}
