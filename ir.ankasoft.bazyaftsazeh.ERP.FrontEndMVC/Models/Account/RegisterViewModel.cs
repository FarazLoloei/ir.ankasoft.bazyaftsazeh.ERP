using ir.ankasoft.resource;
using System.ComponentModel.DataAnnotations;

namespace ir.ankasoft.bazyaftsazeh.ERP.FrontEndMVC.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = nameof(Email), ResourceType = typeof(Resource))]
        public string Email { get; set; }

        [Required]
        [StringLength(100,
            ErrorMessageResourceName = "The0MusBeAtLeast2CharactersLong",
            MinimumLength = 6,
            ErrorMessageResourceType = typeof(Resource))]
        [Display(Name = nameof(UserName), ResourceType = typeof(Resource))]
        public string UserName { get; set; }

        [Required]
        [StringLength(100,
            ErrorMessageResourceName = "The0MusBeAtLeast2CharactersLong",
            MinimumLength = 6,
            ErrorMessageResourceType = typeof(Resource))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Resource))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword", ResourceType = typeof(Resource))]
        [Compare("Password",
            ErrorMessageResourceName = "ThePasswordAndConfirmationPasswordDoNotMatch",
            ErrorMessageResourceType = typeof(Resource))]
        public string ConfirmPassword { get; set; }
    }
}