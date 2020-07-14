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
    public partial class PaginaCadastroView : ContentPage
    {
        public PaginaCadastroView()
        {
            InitializeComponent();
            BindingContext = new PaginaCadastroVM();
        }
    }
}