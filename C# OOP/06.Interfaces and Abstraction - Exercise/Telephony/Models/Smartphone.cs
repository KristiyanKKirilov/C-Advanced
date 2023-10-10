using Telephony.Models.Interfaces;

namespace Telephony.Models
{
    public class Smartphone : ICallable, IBrowsable
    {
        public string Call(string phoneNumber)
        {
            if (!IsPhoneNumberValid(phoneNumber))
            {
                throw new ArgumentException("Invalid number!");
            }

            return $"Calling... {phoneNumber}";
        }
        public string Browse(string url)
        {
            if (!IsURLValid(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }

        
        private bool IsPhoneNumberValid(string phoneNumber)
        => phoneNumber.All(c => char.IsDigit(c));

        private bool IsURLValid(string url)
            => url.All(c => !char.IsDigit(c));
    }
    
}
