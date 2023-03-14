using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ChromeExtensionBackend.Models.Entities;

namespace ChromeExtensionBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TagItemsController : ControllerBase
    {
        private readonly TagItemContext _context;

        public TagItemsController(TagItemContext context)
        {
            _context = context;
        }

        // GET: api/TagItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagItem>>> GetTagItems()
        {
          if (_context.TagItems == null)
          {
              return NotFound();
          }
            return await _context.TagItems.ToListAsync();
        }

        // GET: api/TagItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TagItem>> GetTagItem(int id)
        {
          if (_context.TagItems == null)
          {
              return NotFound();
          }
            var tagItem = await _context.TagItems.FindAsync(id);

            if (tagItem == null)
            {
                return NotFound();
            }

            return tagItem;
        }

        // PUT: api/TagItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTagItem(int id, TagItem tagItem)
        {
            if (id != tagItem.TagItemId)
            {
                return BadRequest();
            }

            _context.Entry(tagItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TagItemExists(id))
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

        // POST: api/TagItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TagItem>> PostTagItem(TagItem tagItem)
        {
          if (_context.TagItems == null)
          {
              return Problem("Entity set 'TagItemContext.TagItems'  is null.");
          }
            _context.TagItems.Add(tagItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTagItem), new { id = tagItem.TagItemId }, tagItem);
            //return CreatedAtAction("GetTagItem", new { id = tagItem.TagItemId }, tagItem);
        }

        // DELETE: api/TagItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTagItem(int id)
        {
            if (_context.TagItems == null)
            {
                return NotFound();
            }
            var tagItem = await _context.TagItems.FindAsync(id);
            if (tagItem == null)
            {
                return NotFound();
            }

            _context.TagItems.Remove(tagItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TagItemExists(int id)
        {
            return (_context.TagItems?.Any(e => e.TagItemId == id)).GetValueOrDefault();
        }
    }
}
