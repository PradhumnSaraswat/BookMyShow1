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
    [Route("api/movie")]
    [ApiController]
    public class MovieController : MainController
    {

        private readonly IBookMyShowRepository bookMyShowRepository;

        public MovieController( IBookMyShowRepository _bookMyShowRepository)
        {
            this.bookMyShowRepository = _bookMyShowRepository;
        }

        [HttpGet]
        public List<Movie> GetMovies()
        {
            return this.bookMyShowRepository.GetMovies();
        }

        [HttpGet("{id}")]
        public Movie GetMovieById(int id)
        {
            return this.bookMyShowRepository.GetMovieById(id);
        }
    }
}
