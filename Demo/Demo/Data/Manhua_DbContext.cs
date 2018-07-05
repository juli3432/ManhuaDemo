namespace Demo.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Manhua_DbContext : DbContext
    {
        public Manhua_DbContext()
            : base("name=Manhua_DbContext")
        {
        }

        public virtual DbSet<Comic> Comics { get; set; }
        public virtual DbSet<ComicDetail> ComicDetails { get; set; }
        public virtual DbSet<ComicDetailImgae> ComicDetailImgaes { get; set; }
        public virtual DbSet<Website> Websites { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comic>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Comic>()
                .HasMany(e => e.ComicDetails)
                .WithOptional(e => e.Comic)
                .HasForeignKey(e => e.codeComic);

            modelBuilder.Entity<ComicDetail>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<ComicDetail>()
                .HasMany(e => e.ComicDetailImgaes)
                .WithOptional(e => e.ComicDetail)
                .HasForeignKey(e => e.codeComicDetail);

            modelBuilder.Entity<ComicDetailImgae>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Website>()
                .Property(e => e.link)
                .IsUnicode(false);

            modelBuilder.Entity<Website>()
                .HasMany(e => e.Comics)
                .WithOptional(e => e.Website)
                .HasForeignKey(e => e.codeWebsite);
        }
    }
}
