using BooKMyShowModel.Models;
using BookMyShowServices.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [Route("api/bookingShow")]
    [ApiController]
    public class BookingShowController : MainController
    {
        private readonly IBookMyShowRepository bookMyShowRepository;

        public BookingShowController(IBookMyShowRepository _bookMyShowRepository)
        {
            this.bookMyShowRepository = _bookMyShowRepository;
            
        }

        [HttpGet("{id}")]
        public Show GetBookingShow(int id)
        {
            return this.bookMyShowRepository.GetBookingShow(id);
        }
    }
}
