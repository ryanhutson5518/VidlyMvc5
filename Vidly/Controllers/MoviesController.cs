using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private readonly VidlyContext _vidlyContext;

        public MoviesController(VidlyContext vidlyContext)
        {
            _vidlyContext = vidlyContext;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var movies = await _vidlyContext.Movies
                .Include(m => m.Genre)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return View(movies);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var movie = await _vidlyContext.Movies
                .Include(m => m.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id, cancellationToken);

            return View(movie);
        }

        public IActionResult Random()
        {
            Movie movie = new()
            {
                Name = "Shrek!"
            };

            List<Customer> customers = new()
            {
                new Customer() { Name = "Customer 1" },
                new Customer() { Name = "Customer 2" }
            };

            RandomMovieViewModel viewModel = new()
            {
                Movie = movie,
                Customers = customers
            };

            return View(viewModel);
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
        }

        public IActionResult Edit(int id)
        {
            // movies/edit/5   returns id=5
            // movies/edit?id=3   return id=3
            return Content("id=" + id);
        }

        //public IActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }
        //    if (string.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    // query string pageIndex=1&sortBy=Name
        //    return Content($"pageIndex={pageIndex}&sortBy={sortBy}");
        //}

        [Route("movies/released/{year}/{month:regex(\\d{{2}})}")]
        public IActionResult ByReleaseDate(int year, int month)
        {
            return Content($"{year}/{month}");
        }

        public async Task<IActionResult> New(CancellationToken cancellationToken)
        {
            MovieFormViewModel viewModel = new()
            {
                Genres = await _vidlyContext.Genres.AsNoTracking().ToListAsync(cancellationToken)
            };

            return View("MovieForm", viewModel);
        }

        public async Task<IActionResult> Edit()
        {

        }

        public async Task<IActionResult> Save()
        {

        }
    }
}
