using MockAPIClientLibrary.Models;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Diagnostics;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;

namespace MockAPIClientLibrary
{
    public class MockSangueaseAPI : ISangueaseAPI
    {
        public async Task<List<BDEvent>> GetBDEventsAsync()
        {
            return await Task.Run(
                () =>
                {
                    Thread.Sleep(3000);

                    return new List<BDEvent>()
                    {
                        new BDEvent()
                        {
                            Id = 0,
                            Name = "TestName1",
                            Description = "TestDescription1",
                            StartDate = DateTime.Parse("01-01-2001"),
                            EndDate = DateTime.Parse("02-02-2002"),
                            Latitude = 1.0000m,
                            Longitude = 2.0000m,
                            Image = ConvertPngImageToByteArray(new BitmapImage(new Uri("./img1.png")))
                        },
                        new BDEvent()
                        {

                        },
                        new BDEvent()
                        {

                        }
                    };
                });
        }
        public async Task<BDEvent> GetBDEventByIdAsync(int id) 
        {
            return await Task.Run(
                () =>
                {
                    Thread.Sleep(3000);

                    return new BDEvent()
                    {

                    };
                });
        }

        public async Task AddBDEvent(BDEvent model)
        {
            await Task.Run(
                () =>
                {
                    Thread.Sleep(3000);

                    Debug.WriteLine("");
                });
        }

        public async Task UpdateBDEvent(int id, BDEvent model)
        {
            await Task.Run(
                () =>
                {
                    Thread.Sleep(3000);

                    Debug.WriteLine("");
                });
        }

        public async Task DeleteBDEvent(int id)
        {
            await Task.Run(
                () =>
                {
                    Thread.Sleep(3000);

                    Debug.WriteLine("");
                });
        }

        public async Task<string> GetLocationByCoordinatesAsync(decimal latitude, decimal longitude)
        {
            return await Task.Run(
                () =>
                {
                    string output = "";

                    Thread.Sleep(3000);

                    return output;
                });
        }

        //temporary
        private byte[] ConvertPngImageToByteArray(BitmapImage image)
        {
            byte[] output;
            PngBitmapEncoder encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                output = ms.ToArray();
            }

            return output;
        }
    }
}
