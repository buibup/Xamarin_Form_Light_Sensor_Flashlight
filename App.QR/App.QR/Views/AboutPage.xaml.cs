using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App.QR.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class AboutPage : ContentPage 
    {
        public AboutPage()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                if (Settings.CurrentLightSensorValue <= 100)
                {
                    // Turn On Flashlight  
                    await Flashlight.TurnOnAsync().ConfigureAwait(false);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await ShowAlert(fnsEx.Message);
            }
            catch (PermissionException pEx)
            {
                await ShowAlert(pEx.Message);
            }
            catch (Exception ex)
            {
                await ShowAlert(ex.Message);
            }
        }

        async void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            try
            {
                if (Settings.CurrentLightSensorValue > 100)
                {
                    // Turn Off Flashlight  
                    await Flashlight.TurnOffAsync().ConfigureAwait(false);
                }
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                await ShowAlert(fnsEx.Message);
            }
            catch (PermissionException pEx)
            {
                await ShowAlert(pEx.Message);
            }
            catch (Exception ex)
            {
                await ShowAlert(ex.Message);
            }
        }

        public async Task ShowAlert(string message)
        {
            await DisplayAlert("Faild", message, "Ok");
        }
    }
}