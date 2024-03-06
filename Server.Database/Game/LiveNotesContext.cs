using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Server.Database.Game.LiveNotes;

namespace Server.Database.Game;

public partial class LiveNotesContext : DbContext
{
    public LiveNotesContext()
    {
    }

    public LiveNotesContext(DbContextOptions<LiveNotesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LiveNote> LiveNotes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlite("Data Source=Databases/live_notes.db_");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
