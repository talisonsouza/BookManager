using BookManager.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManager.API.Repository.Context
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<Editor> Editor { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<User> Users { get; set; }

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
            UserConfig(modelBuilder);
            BookUserConfig(modelBuilder);
        }


        private void BookUserConfig(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookUser>().HasKey(bu => new { bu.BookId, bu.UserId });
            modelBuilder.Entity<BookUser>()
                .HasOne(bu => bu.Book).WithMany(bu => bu.BookUsers).HasForeignKey(b => b.BookId);

            modelBuilder.Entity<BookUser>()
                .HasOne(bu => bu.User).WithMany(bu => bu.BookUsers).HasForeignKey(u => u.UserId);

        }


        private void UserConfig(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(c => c.Id).HasName("UserId");
                e.Property(c => c.Id).HasColumnName("AuthorId").ValueGeneratedOnAdd();
                e.Property(c => c.Name).HasColumnName("Name").HasMaxLength(200);
                e.Property(c => c.Email).HasColumnName("Email").HasMaxLength(200);

            });            
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
                e.HasKey(c => c.Id).HasName("EditorId");
                e.Property(c => c.Id).HasColumnName("EditorId").ValueGeneratedOnAdd();
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
