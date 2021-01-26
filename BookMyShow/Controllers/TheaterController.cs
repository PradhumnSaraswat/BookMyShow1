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
    [Route("api/theater")]
    [ApiController]
    public class TheaterController : MainController
    {
        private readonly IBookMyShowRepository bookMyShowRepository;
        public TheaterController(IBookMyShowRepository _bookMyShowRepository)
        {
            this.bookMyShowRepository = _bookMyShowRepository;
        }

        [HttpGet]
        public List<Theater> GetTheater()
        {
            return this.bookMyShowRepository.GetTheater();
        }

        [HttpGet("{id}")]
        public Theater GetTheaterById(int id)
        {
            return this.bookMyShowRepository.GetTheaterById(id);
        }
    }
}
