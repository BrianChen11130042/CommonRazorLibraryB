using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.FeaturePackage.UserPack.Data;

namespace CommonRazorLibraryB.FeaturePackage.UserPack.DtoModel
{
    public class UserInfoDto
    {
        public Guid Id { get; set; }

        public string UserName { get; set; } = string.Empty;

        public string Account { get; set; } = string.Empty;

        public ERoleType Role { get; set; } = ERoleType.Guest;
    }
}
