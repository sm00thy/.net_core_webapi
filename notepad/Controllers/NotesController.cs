using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using notepad.DatabaseContext;
using notepad.Models;

namespace notepad.Controllers
{
    [Route("web/[controller]")]
    [ApiController]


    public class NotesController : ControllerBase
    {
        private readonly NoteContext _context;

        public NotesController(NoteContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<NoteItem>> GetAll()
        {
            return _context.Notes.ToList();
        }

        [HttpGet("{id}", Name = "GetNote")]
        public ActionResult<NoteItem> GetById(long id)
        {
            var item = _context.Notes.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        [HttpPost]
        public IActionResult Create(NoteItem item)
        {
            _context.Notes.Add(item);
            _context.SaveChanges();

            return CreatedAtRoute("GetNote", new { id = item.Id }, item);
        }


        [HttpPut("{id}")]
        public IActionResult Update(long id, NoteItem item)
        {
            var toUpdate = _context.Notes.Find(id);
            if (toUpdate == null)
            {
                return NotFound();
            }

            toUpdate.Title = item.Title;
            toUpdate.TextField = item.TextField;

            _context.Notes.Update(toUpdate);
            _context.SaveChanges();
            return NoContent();
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var note = _context.Notes.Find(id);
            if (note == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(note);
            _context.SaveChanges();
            return NoContent();
        }

    }
}
