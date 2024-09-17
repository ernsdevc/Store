using System.ComponentModel.DataAnnotations;

namespace StoreApp.Models
{
    public class LoginModel
    {
        private string? _returnUrl;
        [Required(ErrorMessage = "Name is required.")]
        public String? UserName { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public String? Password { get; set; }
        public string ReturnUrl
        {
            get
            {
                if (_returnUrl is null)
                    return "/";
                else
                    return _returnUrl;
            }
            set
            {
                _returnUrl = value;
            }
        }
    }
}