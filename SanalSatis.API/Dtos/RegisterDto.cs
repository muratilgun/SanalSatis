using System.ComponentModel.DataAnnotations;

namespace SanalSatis.API.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression
        ("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$", ErrorMessage ="Şifreniz +1 küçük +1 büyük +1 sayı +1 simge içermelidir.")]
        public string Password { get; set; }
    }
}