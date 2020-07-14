using Plugin.Media;
using Plugin.Media.Abstractions;
using Restaurante.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Restaurante.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CameraPageView : ContentPage
    {
        ComunicacaoBancoProdutos conexao = new ComunicacaoBancoProdutos();
        public CameraPageView()
        {
            InitializeComponent();

        }


        /*private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("Nenhuma Câmera", ":( Nenuma Câmera disponível.", "OK");
                return;
            }

            var armazenamento = new StoreCameraMediaOptions()
            {
                SaveToAlbum = true,
                Name = "MinhaFoto.jpg"
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(armazenamento);

            if (foto == null)
                return;
            imgFoto.Source = ImageSource.FromStream(() =>
            {
                var stream = foto.GetStream();
                foto.Dispose();
                return stream;
            });
        }*/
        private async void btnSelecionarImagem_Clicked(object sender, EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                MediaFile imagem = await CrossMedia.Current.PickPhotoAsync();

                string spath = imagem.Path.ToString();

                if (imagem != null)
                {
                    //imgFoto.Source = ImageSource.FromStream(() =>
                    ImageSource img = ImageSource.FromStream(() =>
                    {
                        Stream stream = imagem.GetStream();
                        imagem.Dispose();
                        return stream;
                    });

                    imgFoto.Source = img;
                }
            }
        }
    }
}
