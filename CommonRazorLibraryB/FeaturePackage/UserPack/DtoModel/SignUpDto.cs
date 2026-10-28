using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.FeaturePackage.UserPack.Data;

namespace CommonRazorLibraryB.FeaturePackage.UserPack.DtoModel
{
    public class SignUpDto
    {
        [Required(AllowEmptyStrings = false)]
        public string UserName { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Account { get; set; } = string.Empty;

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; } = string.Empty;

        public ERoleType Role { get; set; } = ERoleType.User;
    }
}
