using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR.Businesslayer.Abstract;
using SignalR.DtoLayer.AboutDto;
using SignalR.DtoLayer.BookingDto;
using SignalR.EntityLayer.Entities;
using SignalRApi.Hubs;
using System;

namespace SignalRApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;
        private readonly IHubContext<SignalRHub> _hubContext;
        private readonly INotificationService _notificationService;

        public BookingController(IBookingService bookingService, IHubContext<SignalRHub> hubContext, INotificationService notificationService)
        {
            _bookingService = bookingService;
            _hubContext = hubContext;
            _notificationService = notificationService;
        }
        [HttpGet]
        public IActionResult BookingList()
        {
            var values = _bookingService.TGetListAll();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto createBookingDto)
        {
            Booking booking = new Booking()
            {
                Description = createBookingDto.Description,
                Name = createBookingDto.Name,
                Phone = createBookingDto.Phone,
                Mail = createBookingDto.Mail,
                PersonCount = createBookingDto.PersonCount,
                Date = createBookingDto.Date
            };
            _bookingService.TAdd(booking);
            
            await _hubContext.Clients.All.SendAsync("ReciveBookingList", _bookingService.TGetListAll());
            
            // Yeni rezervasyon için bildirim oluştur
            var rezDate = booking.Date == default ? DateTime.Now : booking.Date;
            var description = $"Yeni rezervasyon: {booking.Name} - {booking.PersonCount} kişilik - {rezDate:dd.MM.yyyy}";
            _notificationService.TAdd(new Notification
            {
                Type = "Yeni Rezervasyon",
                Icon = "fa fa-calendar-check-o",
                Description = description,
                Date = DateTime.Now,
                Status = false
            });
            
            return Ok("Başarılı");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            _bookingService.TDelete(value);
            
            await _hubContext.Clients.All.SendAsync("ReciveBookingList", _bookingService.TGetListAll());
            
            return Ok("silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(UpdateBookingDto updateBookingDto)
        {
            Booking booking = new Booking()
            {
                BookingID = updateBookingDto.BookingID,
                Name = updateBookingDto.Name,
                Phone = updateBookingDto.Phone,
                Mail = updateBookingDto.Mail,
                PersonCount = updateBookingDto.PersonCount,
                Date = updateBookingDto.Date,
                Description = updateBookingDto.Description
            };
            _bookingService.TUpdate(booking);
            
            await _hubContext.Clients.All.SendAsync("ReciveBookingList", _bookingService.TGetListAll());
            
            return Ok("güncellendi");
        }
        [HttpGet("{id}")]
        public IActionResult GetBooking(int id)
        {
            var value = _bookingService.TGetByID(id);
            return Ok(value);
        }

        [HttpGet("BookingStatusApprov/{id}")]
        public IActionResult BookingStatusApprov(int id)
        {
            _bookingService.TbookingStatusDescriptionApprove(id);
            return Ok();
        }
        [HttpGet("BookingStatusCancel/{id}")]
        public IActionResult BookingStatusCancel(int id)
        {
            _bookingService.TbookingStatusDescriptionCancel(id);
            return Ok();
        }
    }
}
