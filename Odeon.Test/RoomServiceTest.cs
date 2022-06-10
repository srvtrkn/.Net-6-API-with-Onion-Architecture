using Newtonsoft.Json;
using Odeon.Application.ViewModels.Room;
using System.Net;
using System.Text;

namespace Odeon.Test
{
    public class RoomServiceTest
    {
        [Fact]
        public async void GetCheapestRoomPricesTest()
        {
            var client = TestClientProvider.Current.Client();
            var result = await client.GetAsync("Room/GetCheapestRoomPrices");
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<object>(result.Content.ReadAsStringAsync().Result);                
            }
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async void AdvancedRoomSearchTest()
        {
            var client = TestClientProvider.Current.Client();
            RoomSearchRequest req = new RoomSearchRequest
            {
                HotelIds = new List<string>(),
                RoomTypeIds = new List<string> { "F901A591-35EB-4031-804A-CBE66F6762B3", "CAD176C0-57FC-408D-9BED-DB1028EC8F3D" }
            };
            var result = await client.PostAsync("Room/AdvancedRoomSearch", new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<object>(result.Content.ReadAsStringAsync().Result);               
            }
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
        [Fact]
        public async void RoomAvailabilityCheckTest()
        {
            var client = TestClientProvider.Current.Client();
            RoomAvailabilityCheckRequest req = new RoomAvailabilityCheckRequest
            {
                HotelIds = new List<string>() { "CA1094A1-3116-47F4-9B49-356397CFEAB6" },
                RoomTypeIds = new List<string> { "CAD176C0-57FC-408D-9BED-DB1028EC8F3D" },
                RequestedRoomCount = 2
            };
            var result = await client.PostAsync("Room/RoomAvailabilityCheck", new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json"));
            if (result.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<object>(result.Content.ReadAsStringAsync().Result);               
            }
            result.EnsureSuccessStatusCode();
            Assert.Equal(HttpStatusCode.OK, result.StatusCode);
        }
    }
}