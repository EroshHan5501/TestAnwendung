using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Models;

public partial class UserGroupsContext : DbContext
{
    public UserGroupsContext()
    {
    }

    public UserGroupsContext(DbContextOptions<UserGroupsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<GroupRight> GroupRights { get; set; }

    public virtual DbSet<PermissionGroup> PermissionGroups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:SQLServer");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<GroupRight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GroupRig__3214EC07AA7D9361");

            entity.Property(e => e.Area)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.PermissionGroups).WithMany(p => p.GroupRights)
                .HasForeignKey(d => d.PermissionGroupsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__GroupRigh__Permi__398D8EEE");
        });

        modelBuilder.Entity<PermissionGroup>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Permissi__3214EC07BEDB5C7E");

            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
