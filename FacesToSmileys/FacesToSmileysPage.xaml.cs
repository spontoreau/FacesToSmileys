using System;
using FacesToSmileys.Services;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace FacesToSmileys
{
    public partial class FacesToSmileysPage : ContentPage
    {
        public FacesToSmileysPage()
        {
            InitializeComponent();
        }

        async void Button_Clicked(object sender, System.EventArgs e)
        {
            var photoService = new PhotoService();
            var file = await photoService.TaskPhotoAsync();
            image.Source = ImageSource.FromFile(file);
        }
    }
}
