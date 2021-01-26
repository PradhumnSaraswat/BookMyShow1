using AutoMapper;
using BooKMyShowModel.Models;
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
    [Route("api/hall")]
    [ApiController]
    public class HallController : MainController
    {
        private readonly IBookMyShowRepository bookMyShowRepository;
        public HallController(IBookMyShowRepository _bookMyShowRepository)
        {
            this.bookMyShowRepository = _bookMyShowRepository;
        }

        [HttpGet]
        public List<Hall> GetHall()
        {
            return this.bookMyShowRepository.GetHall();
        }

        [HttpGet("{id}")]
        public Hall GetHallById(int id)
        {
            return this.bookMyShowRepository.GetHallById(id);
        }
    }
}
