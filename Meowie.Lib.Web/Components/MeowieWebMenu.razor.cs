using Meowie.Lib.Services;

namespace Meowie.Lib.Web.Components
{
    public partial class MeowieWebMenu
    {

        private bool collapseNavMenu = true;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu()
        {
            collapseNavMenu = !collapseNavMenu;
        }
    }
}
