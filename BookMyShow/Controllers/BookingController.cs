using AutoMapper;
using BooKMyShowModel.Models;
using DataModel = BooKMyShowModel.DataModel;
using BookMyShowServices.Services;
using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BookMyShow.Controllers
{
    [Route("api/booking")]
    [ApiController]
    public class BookingController : MainController
    {
        private readonly IBookMyShowRepository bookMyShowRepository;

        public BookingController(IBookMyShowRepository _bookMyShowRepository)
        {
            this.bookMyShowRepository = _bookMyShowRepository;
        }

        [HttpGet("{id}")]
        public List<int> GetBookedSeat(int id)
        {
            return this.bookMyShowRepository.GetBookedSeat(id);
        }
        
        

        [Route("multi")]
        [HttpPost]
        public bool PostBookSeat(DataModel.BookSeat bookSeat)
        {
            return this.bookMyShowRepository.PostBookSeat(bookSeat);
        }
    }
}
