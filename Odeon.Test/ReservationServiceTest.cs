using Newtonsoft.Json;
using Odeon.Application.ViewModels.Reservations;
using System.Net;
using System.Text;

namespace Odeon.Test
{
    public class ReservationServiceTest
    {
        [Fact]
        public async void CreateReservationTest()
        {
            var client = TestClientProvider.Current.Client();
            CreateReservationRequest req = new CreateReservationRequest
            {
                HotelId = "A4469F56-6CDF-4BF0-ACBA-65E9177E4CCA",
                RoomTypeId = "CAD176C0-57FC-408D-9BED-DB1028EC8F3D",
                BookingDateStart = DateTime.Now.ToString(),
                BookingDateEnd = DateTime.Now.AddDays(5).ToString(),
                RequestedRoomCount = 2

            };
            var result = await client.PostAsync("Reservations/CreateReservation", new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<object>(result.Content.ReadAsStringAsync().Result);
            }
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async void CancelReservationTest()
        {
            var client = TestClientProvider.Current.Client();
            string reservationId = "C4033644-6413-4CF2-8797-08DA49DA8EA3";
            var result = await client.PostAsync(string.Format("Reservations/CancelReservation?reservationId={0}", reservationId), null);
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<object>(result.Content.ReadAsStringAsync().Result);
            }
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}