using Restaurante.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurante.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PaginaDeProdutosView : ContentPage
    {
        PaginaDeProdutosVM vm { get; set; }
        public PaginaDeProdutosView(string categoria)
        {
            vm = new PaginaDeProdutosVM(categoria);
            InitializeComponent();
            BindingContext = vm;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await vm.InitializeAsync();
        }
    }
}