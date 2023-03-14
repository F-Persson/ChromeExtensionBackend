using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ChromeExtensionBackend.Models.Entities;

public partial class TagItemContext : DbContext
{
    public TagItemContext(DbContextOptions<TagItemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TagItem> TagItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Finnish_Swedish_CI_AI");

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.Property(e => e.Tag1).HasColumnName("Tag");

            entity.HasOne(d => d.TagItem).WithMany(p => p.Tags)
                .HasForeignKey(d => d.TagItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Tag_TagItems_TagItemId");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
