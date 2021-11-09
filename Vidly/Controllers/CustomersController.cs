using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Vidly.Data;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private readonly VidlyContext _vidlyContext;
        private readonly IMapper _mapper;

        public CustomersController(VidlyContext vidlyContext, IMapper mapper)
        {
            _vidlyContext = vidlyContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            var customers = await _vidlyContext.Customers
                .Include(c => c.MembershipType)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            return View(customers);
        }

        public async Task<IActionResult> Details(int id, CancellationToken cancellationToken)
        {
            var customers = await _vidlyContext.Customers
                .Include(c => c.MembershipType)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            var customer = customers.FirstOrDefault(c => c.Id == id);

            if (customer != null)
            {
                return View(customer);
            }
            else
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> New(CancellationToken cancellationToken)
        {
            var membershipTypes = await _vidlyContext.MembershipType
                .AsNoTracking()
                .ToListAsync(cancellationToken);
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Save(Customer customer, CancellationToken cancellationToken)
        {
            if (customer.Id == 0)
            {
                await _vidlyContext.AddAsync(customer, cancellationToken);
            }
            else
            {
                var customerInDb = await _vidlyContext.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id, cancellationToken);
                customerInDb.Name = customer.Name;
                customerInDb.Birthday = customer.Birthday;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            await _vidlyContext.SaveChangesAsync(cancellationToken);
            return RedirectToAction("Index", "Customers");
        }

        public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
        {
            var customer = await _vidlyContext.Customers.FirstOrDefaultAsync(c => c.Id == id, cancellationToken);

            if (customer == null)
            {
                return NotFound();
            }

            CustomerFormViewModel viewModel = new()
            {
                Customer = customer,
                MembershipTypes = await _vidlyContext.MembershipType.ToListAsync(cancellationToken)
            };
            return View("CustomerForm", viewModel);
        }
    }
}
