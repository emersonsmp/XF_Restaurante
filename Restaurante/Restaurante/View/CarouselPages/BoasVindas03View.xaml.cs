using Restaurante.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurante.View.CarouselPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BoasVindas03View : ContentPage
    {
        public BoasVindas03View()
        {
            InitializeComponent();
            BindingContext = new BoasVindas03VM();
        }
    }
}