using Restaurante.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Restaurante.ViewModel;

namespace Restaurante.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditarProdutoView : ContentPage
    {
        public EditarProdutoView(ProdutoModel produto)
        {
            InitializeComponent();
            BindingContext = new EditarProdutoVM(produto);
        }
    }
}