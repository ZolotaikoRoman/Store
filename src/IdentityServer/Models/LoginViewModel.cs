using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace IdentityServer.Models
{
    public sealed class LoginViewModel
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}