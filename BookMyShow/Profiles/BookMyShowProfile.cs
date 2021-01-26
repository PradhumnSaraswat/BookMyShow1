using AutoMapper;
using BooKMyShowModel.Models;
using BookMyShowServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel = BooKMyShowModel.DataModel;
namespace BookMyShow.Profiles
{
    public class BookMyShowProfile:  Profile
    {
        public BookMyShowProfile()
        {
            CreateMap<DataModel.Booking, Booking>().ReverseMap();

            CreateMap<DataModel.Hall, Hall>().ReverseMap();

            CreateMap<DataModel.Movie, Movie>().ReverseMap();

            CreateMap<DataModel.Show, Show>().ReverseMap();

            CreateMap<DataModel.Theater, Theater>().ReverseMap();

        }
    }
}
