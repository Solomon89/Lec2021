using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lec2021.Models;

namespace Lec2021.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestsModelsController : ControllerBase
    {
        private readonly TestDbConxextcs _context;

        public TestsModelsController(TestDbConxextcs context)
        {
            _context = context;
        }

        // GET: api/TestsModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TestsModel>>> GetTestsModels()
        {
            return await _context.TestsModels.ToListAsync();
        }

        // GET: api/TestsModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TestsModel>> GetTestsModel(int id)
        {
            var testsModel = await _context.TestsModels.FindAsync(id);

            if (testsModel == null)
            {
                return NotFound();
            }

            return testsModel;
        }

        // PUT: api/TestsModels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTestsModel(int id, TestsModel testsModel)
        {
            if (id != testsModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(testsModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TestsModelExists(id))
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

        // POST: api/TestsModels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TestsModel>> PostTestsModel(TestsModel testsModel)
        {
            _context.TestsModels.Add(testsModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTestsModel", new { id = testsModel.Id }, testsModel);
        }

        // DELETE: api/TestsModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTestsModel(int id)
        {
            var testsModel = await _context.TestsModels.FindAsync(id);
            if (testsModel == null)
            {
                return NotFound();
            }

            _context.TestsModels.Remove(testsModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TestsModelExists(int id)
        {
            return _context.TestsModels.Any(e => e.Id == id);
        }
    }
}
