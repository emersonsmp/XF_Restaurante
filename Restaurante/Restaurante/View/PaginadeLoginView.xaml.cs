﻿using System;
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
    public partial class PaginadeLoginView : ContentPage
    {
        public PaginadeLoginView()
        {
            InitializeComponent();
            BindingContext = new PaginadeLoginVM();
        }
    }
}