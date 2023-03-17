using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {

        private readonly SupplierDbContext _db;

        public SupplierController(SupplierDbContext db)
        {
            _db = db;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<Suppliers>>> GetSuppliers()
        {
            if(_db.suppliers == null)
            {
                return NotFound();
            }
            return await _db.suppliers.ToListAsync();
        }


        [HttpGet("{id}")]

        public async Task<ActionResult<Suppliers>> GetSupplier(int id)
        {
            if (_db.suppliers == null)
            {
                return NotFound();
            }

            var sup = await _db.suppliers.FindAsync(id);

            if (sup == null)
            {
                return NotFound();
            }
            return sup;
        }

        [HttpPost]

        public async Task<ActionResult<Suppliers>> AddSupplier(Suppliers supplier)
        {
            if (_db.suppliers.Contains(supplier))
            {
                return BadRequest();
            }

            _db.suppliers.Add(supplier);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
