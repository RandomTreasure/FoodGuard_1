using FoodGuard_1.Views;
using Xamarin.Forms;

namespace FoodGuard_1
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(RecapPage), typeof(RecapPage));
            Routing.RegisterRoute(nameof(InventoryPage), typeof(InventoryPage));
            Routing.RegisterRoute(nameof(ShoppingListPage), typeof(ShoppingListPage));
            Routing.RegisterRoute(nameof(ExpiringSoonPage), typeof(ExpiringSoonPage));

            //Routing.RegisterRoute(nameof(), typeof());


            //Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

        /*
        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
        */
    }
}
