using EM.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EM.Views
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