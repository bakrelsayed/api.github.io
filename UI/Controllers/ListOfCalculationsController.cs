using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Domain.Concrete;
using Domain.Entities;
using Domain.Abstract;
using Microsoft.AspNetCore.Cors;

namespace UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [EnableCors("AllowOrigin")]
    public class ListOfCalculationsController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _db;
        public ListOfCalculationsController(AppDbContext context, IUnitOfWork db)
        {
            _context = context;
            _db = db;
        }

        // GET: api/ListOfCalculations
        //[HttpGet]
        //public Task<ActionResult<IEnumerable<ListOfCalculations>>> GetListOfCalculations()
        //{
        //    //return await _context.ListOfCalculations.ToListAsync();
        //    var data = _db.ListOfCalculations.GetFullLists();
        //    return data;
        //}
        [HttpGet]
        public MainTable GetListOfCalculations()
        {
            //return await _context.ListOfCalculations.ToListAsync();
            var data = _db.ListOfCalculations.GetFullLists();
            return data;
        }
        // GET: api/ListOfCalculations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListOfCalculations>> GetListOfCalculations(int id)
        {
            var listOfCalculations = await _context.ListOfCalculations.FindAsync(id);

            if (listOfCalculations == null)
            {
                return NotFound();
            }

            return listOfCalculations;
        }

        // PUT: api/ListOfCalculations/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListOfCalculations(int id, ListOfCalculations listOfCalculations)
        {
            if (id != listOfCalculations.Id)
            {
                return BadRequest();
            }

            _context.Entry(listOfCalculations).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListOfCalculationsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ListOfCalculations
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        //public async Task<ActionResult<ListOfCalculations>> PostListOfCalculations(List<ListOfCalculations> listOfCalculations)
        public async Task<ActionResult<ListOfCalculations>> PostListOfCalculations(MainTable objectData)
        {

            try
            {
                //_context.ListOfCalculations.AddRange(listOfCalculations);
                _db.ListOfCalculations.AddData(objectData);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetListOfCalculations", new { id = objectData.Id }, objectData.Id);
                //return CreatedAtAction("GetListOfCalculations", new { id = listOfCalculations.Id }, listOfCalculations);
            }
            catch (Exception ex)
            {
               
                throw;
            }
           
        }

        // DELETE: api/ListOfCalculations/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListOfCalculations>> DeleteListOfCalculations(int id)
        {
            var listOfCalculations = await _context.ListOfCalculations.FindAsync(id);
            if (listOfCalculations == null)
            {
                return NotFound();
            }

            _context.ListOfCalculations.Remove(listOfCalculations);
            await _context.SaveChangesAsync();

            return listOfCalculations;
        }

        private bool ListOfCalculationsExists(int id)
        {
            return _context.ListOfCalculations.Any(e => e.Id == id);
        }
    }
}
