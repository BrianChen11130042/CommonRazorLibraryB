using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.FeaturePackage.UserPack.Data;

namespace CommonRazorLibraryB.FeaturePackage.UserPack.EFModel
{
    public class UserInfoTable
    {
        [Key]
        public Guid Id { get; set; }

        [MaxLength(500)]
        public string UserName { get; set; }

        [MaxLength(500)]
        public string Account { get; set; }

        public string PasswordHash { get; set; }

        public ERoleType Role { get; set; }
    }
}
