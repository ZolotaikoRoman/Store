using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.IdentityServer.Models.Account
{
    public class UserCredentials
    {
        [Required]
        [DisplayName("User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
