using System.ComponentModel.DataAnnotations;

namespace ZwalApp.API.Dtos
{
    public class UserForRegisterDto
    {[Required]
        public string Username { get; set; }
        [StringLength(8,MinimumLength=4,ErrorMessage="كلمة السر يجب ان لا تزيد عن 8 احرف ولاتقل عن 4  احرف") ]
        public string Password { get; set; }
    }
}