using Odeon.Application.Repositories;
using Odeon.Application.ViewModels.Reservations;
using Odeon.Application.ViewModels.Responses;

namespace Odeon.Application.Services.Reservations
{
    public class ReservationsService : IReservationsService
    {
        private readonly IReservationReadRepository reservationReadRepository;
        private readonly IReservationWriteRepository reservationWriteRepository;
        private readonly IHotelRoomReadRepository hotelRoomReadRepository;
        private readonly IHotelRoomWriteRepository hotelRoomWriteRepository;

        public ReservationsService(IReservationReadRepository reservationReadRepository, IReservationWriteRepository reservationWriteRepository, IHotelRoomReadRepository hotelRoomReadRepository, IHotelRoomWriteRepository hotelRoomWriteRepository)
        {
            this.reservationReadRepository = reservationReadRepository;
            this.reservationWriteRepository = reservationWriteRepository;
            this.hotelRoomReadRepository = hotelRoomReadRepository;
            this.hotelRoomWriteRepository = hotelRoomWriteRepository;
        }
        public async Task<Response<string>> CreateReservation(CreateReservationRequest req)
        {
            try
            {
                var hRoom = await hotelRoomReadRepository.GetSingleAsync(h => h.Hotel.Id == new Guid(req.HotelId) && h.RoomType.Id == new Guid(req.RoomTypeId) && !h.LogicalDeleteKey.HasValue);
                if ((hRoom.MaxAllotment - hRoom.SoldAllotment) >= req.RequestedRoomCount)
                {
                    Guid reservationId = Guid.NewGuid();
                    await reservationWriteRepository.AddAsync(new()
                    {
                        Id = reservationId,
                        StartDate = Convert.ToDateTime(req.BookingDateStart),
                        EndDate = Convert.ToDateTime(req.BookingDateEnd),
                        RoomCount = req.RequestedRoomCount,
                        HotelRoom = hRoom
                    });

                    int result = await reservationWriteRepository.SaveAsync();
                    if (result > 0)
                    {
                        hRoom.SoldAllotment = hRoom.SoldAllotment + req.RequestedRoomCount;
                        result = await hotelRoomWriteRepository.SaveAsync();
                    }
                    return new Response<string>
                    {
                        Success = result > 0 ? true : false,
                        Message = result > 0 ? "Rezervasyon oluşturuldu" : "Rezervasyon işlemi esnasında bir hata oluştu",
                        Data = result > 0 ? reservationId.ToString() : ""
                    };
                }
                return new Response<string>
                {
                    Success = false,
                    Message = "İsteğinize uygun yeterli sayıda oda bulunmuyor"
                };
            }
            catch (Exception e)
            {
                return new Response<string>
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
        public async Task<Response<string>> CancelReservation(string resevationId)
        {
            try
            {
                var reservation = await reservationReadRepository.GetSingleAsync(r => r.Id == Guid.Parse(resevationId) && !r.LogicalDeleteKey.HasValue);
                if (reservation != null)
                {
                    var hRoom = await hotelRoomReadRepository.GetSingleAsync(h => h.Id == reservation.HotelRoomId);
                    reservation.LogicalDeleteKey = Guid.NewGuid();
                    int result = await reservationWriteRepository.SaveAsync();
                    if (result > 0)
                    {
                        hRoom.SoldAllotment = hRoom.SoldAllotment - reservation.RoomCount;
                        result = await hotelRoomWriteRepository.SaveAsync();
                    }
                    return new Response<string>
                    {
                        Success = result > 0 ? true : false,
                        Message = result > 0 ? "Rezervasyonunuz iptal edildi" : "Rezervasyon iptal işlemi esnasında bir hata oluştu",
                    };
                }
                return new Response<string>
                {
                    Success = false,
                    Message = "İsteğinize uygun rezervasyon bulunmuyor"
                };
            }
            catch (Exception e)
            {
                return new Response<string>
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }
    }
}
