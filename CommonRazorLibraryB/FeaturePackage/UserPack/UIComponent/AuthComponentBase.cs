using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonRazorLibraryB.FeaturePackage.UserPack.Application;
using Microsoft.AspNetCore.Components;

namespace CommonRazorLibraryB.FeaturePackage.UserPack.UIComponent
{
    public class AuthComponentBase : ComponentBase, IDisposable
    {

        [Inject]
        protected AuthApplication AuthApp { get; set; } = null!;

        protected override async Task OnInitializedAsync()
        {
            AuthApp.dgUserStatusChanged += handleUserChanged;

            await AuthApp.RetrieveUserInfoFromCookie();

            await base.OnInitializedAsync();
        }

        async Task handleUserChanged()
        {
            await InvokeAsync(StateHasChanged);
        }

        public void Dispose()
        {
            AuthApp.dgUserStatusChanged -= handleUserChanged;
        }
    }
}
