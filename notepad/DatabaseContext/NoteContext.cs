using System;
using Microsoft.EntityFrameworkCore;
using notepad.Models;

namespace notepad.DatabaseContext
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions<NoteContext> options)
          : base(options)
        {
        }
        public DbSet<NoteItem> Notes { get; set; }
    }
}
