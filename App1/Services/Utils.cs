using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace App1.Services
{
    public static class Utils
    {
        public static async Task<Position> ObterPosicaoAtual()
        {
            Position position = null;
            try
            {
                var locator = CrossGeolocator.Current;
                locator.DesiredAccuracy = 100;

                position = await locator.GetLastKnownLocationAsync();

                if (position != null)
                    return position;

                if (!locator.IsGeolocationAvailable || !locator.IsGeolocationEnabled)
                {
                    DependencyService.Get<IActions>().EnableGPS();
                    return null;
                }

                position = await locator.GetPositionAsync(TimeSpan.FromSeconds(20), null, true);

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Atenção", $"Não foi possivel obter a localização [{ex.Message}]", "OK");
            }

            if (position == null)
                return null;

            return position;
        }
    }
}
