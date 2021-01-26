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
    [Route("api/show")]
    [ApiController]
    public class ShowController : MainController
    {
        private readonly IBookMyShowRepository bookMyShowRepository;

        public ShowController(IBookMyShowRepository _bookMyShowRepository)
        {
            this.bookMyShowRepository = _bookMyShowRepository;
        }

        [HttpGet("{id}")]
        public List<Show> GetShows(int id)
        {
            return this.bookMyShowRepository.GetShows(id);
        }
    }
}
