using System.Threading.Tasks;
using MemoryLeakTest.Localization;
using Volo.Abp.UI.Navigation;

namespace MemoryLeakTest.Blazor
{
    public class MemoryLeakTestMenuContributor : IMenuContributor
    {
        public Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if(context.Menu.DisplayName != StandardMenus.Main)
            {
                return Task.CompletedTask;
            }

            var l = context.GetLocalizer<MemoryLeakTestResource>();

            context.Menu.Items.Insert(
                0,
                new ApplicationMenuItem(
                    "MemoryLeakTest.Home",
                    l["Menu:Home"],
                    "/",
                    icon: "fas fa-home"
                )
            );

            return Task.CompletedTask;
        }
    }
}
