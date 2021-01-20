using BookManager.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Editor> Editor { get; set; }
        public DbSet<Author> Author { get; set; }

        public DataBaseContext(DbContextOptions<DataBaseContext> options)
        : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.HasDefaultSchema("tbl");
            BookConfig(modelBuilder);
            AuthorConfig(modelBuilder);
            EditorConfig(modelBuilder);
        }

        private void AuthorConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(e => 
            {
                e.ToTable("Author");
                e.HasKey(c => c.AuthorId).HasName("AuthorId");
                e.Property(c => c.AuthorId).HasColumnName("AuthorId").ValueGeneratedOnAdd();
                e.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100);

                
            });

            modelBuilder.Entity<Author>().HasMany(c => c.Books).WithOne(e => e.Author);
        }

        private void EditorConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Editor>(e =>
            {
                e.ToTable("Editor");
                e.HasKey(c => c.EditorId).HasName("EditorId");
                e.Property(c => c.EditorId).HasColumnName("EditorId").ValueGeneratedOnAdd();
                e.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100);
            });

            modelBuilder.Entity<Editor>().HasMany(c => c.Books).WithOne(e => e.Editor);
        }

        private void BookConfig(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book>(etd =>
            {
                etd.ToTable("Book");
                etd.HasKey(c => c.Id).HasName("id");
                etd.Property(c => c.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                etd.Property(c => c.Name).HasColumnName("Name").HasMaxLength(100);                
                etd.Property(c => c.ISBN).HasColumnName("ISBN").HasMaxLength(100);
                etd.Property(c => c.NumberPages).HasColumnName("numberPages");
            });

            modelBuilder.Entity<Book>().HasOne(c => c.Author);
        }
    }
}
