using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;
using Vidly.DTOs;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class MoviesController :ApiController
    {
        private VidlyContext _context;

        public MoviesController()
        {
            _context = new VidlyContext();
        }


        public IHttpActionResult GetMovies()
        {
            return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>));
        }

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.FirstOrDefault(x => x.Id == id);
            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(Mapper.Map<Movie,MovieDTO>(movie));
            }
        }

        [HttpPost]
        public IHttpActionResult CreateMovie(MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MovieDTO, Movie>(movieDTO);
                _context.Movies.Add(movie);
                _context.SaveChanges();

                movieDTO.Id = movie.Id;
                return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDTO);
            }
        }

        [HttpPut]
        public void UpdateMovie(int id, MovieDTO movieDTO)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movieInDb = _context.Movies.First( x => x.Id == id);
                if (movieInDb == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    Mapper.Map<MovieDTO, Movie>(movieDTO, movieInDb);
                    _context.SaveChanges();
                }
                
            }

        }

        [HttpDelete]
        public void DeleteMovie(int Id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            else
            {
                var movie = _context.Movies.FirstOrDefault(x => x.Id == Id);
                if (movie == null)
                {
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                }
                else
                {
                    _context.Movies.Remove(movie);
                    _context.SaveChanges();
                }
            }
            
        }

    }
}