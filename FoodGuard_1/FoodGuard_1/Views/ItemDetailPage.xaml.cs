using FoodGuard_1.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace FoodGuard_1.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}