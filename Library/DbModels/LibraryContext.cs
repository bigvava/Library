using Library.DbModels.FluentModels;
using Microsoft.EntityFrameworkCore;

namespace Library.DbModels
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
        {
        }

        //public DbSet<Book> Books { get; set; }
        //public DbSet<BookDetail> BookDetails { get; set; }
        //public DbSet<Author> Authors { get; set; }
        //public DbSet<Publisher> Publishers { get; set; }
        //public DbSet<Reader> Readers { get; set; }
        //public DbSet<BookReader> BookReaders {get;set;}



        public DbSet<Fluent_Book> Fluent_Books { get; set; }
        public DbSet<Fluent_BookDetail> Fluent_BookDetails { get; set; }
        public DbSet<Fluent_Author> Fluent_Authors { get; set; }
        public DbSet<Fluent_Publisher> Fluent_Publishers { get; set; }
        public DbSet<Fluent_Reader> Fluent_Readers { get; set; }
        public DbSet<Fluent_Employee> Fluent_Employees { get; set; }
        public DbSet<Fluent_BookReader> Fluent_BookReaders { get; set; }

        public DbSet<Fluent_User> Fluent_Users { get; set; }
        public DbSet<Fluent_Role> Fluent_Roles { get; set; }
        public DbSet<Fluent_UserRole> Fluent_UsersRoles { get; set; }
        public DbSet<Fluent_BookWithDetails> Fluent_BookWithDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=ASUS\\BIGSERVER;Database=LibraryNew;TrustServerCertificate=True;Trusted_Connection=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fluent_BookWithDetails>().ToTable("Fluent_BookWithDetails", t => t.ExcludeFromMigrations());
            modelBuilder.Entity<Fluent_User>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_User>().HasOne(x => x.Reader).WithOne(r => r.User).HasForeignKey<Fluent_User>(x => x.ReaderId);
            modelBuilder.Entity<Fluent_User>().HasOne(x => x.Employee).WithOne(r => r.User).HasForeignKey<Fluent_User>(x => x.EmployeeId);

            modelBuilder.Entity<Fluent_Role>().HasKey(x => x.Id);

            modelBuilder.Entity<Fluent_UserRole>().HasKey(x => new { x.UserId, x.RoleId });
            modelBuilder.Entity<Fluent_UserRole>().ToTable("Fluent_Users_Roles");
            modelBuilder.Entity<Fluent_UserRole>().HasOne(x => x.User).WithMany(u => u.UsersRoles).HasForeignKey(x => x.UserId);
            modelBuilder.Entity<Fluent_UserRole>().HasOne(x => x.Role).WithMany(u => u.UsersRoles).HasForeignKey(x => x.RoleId);

            modelBuilder.Entity<Fluent_Author>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FullName).IsRequired();
            modelBuilder.Entity<Fluent_Author>().Property(x => x.FullName).HasMaxLength(200);

            modelBuilder.Entity<Fluent_Book>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Book>().Property(x => x.Description).HasMaxLength(200);
            modelBuilder.Entity<Fluent_Book>().HasOne(x=>x.Publisher).WithMany(x=>x.Books).HasForeignKey(x=>x.PublisherId);
            modelBuilder.Entity<Fluent_Book>().HasOne(x=>x.Employee).WithMany(x=>x.Books).HasForeignKey(x=>x.EmployeeID);
            modelBuilder.Entity<Fluent_Book>().HasOne(x=>x.Author).WithMany(x=>x.Books).HasForeignKey(x=>x.AuthorId);


            modelBuilder.Entity<Fluent_BookDetail>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.PagesCount).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.Price).IsRequired();
            modelBuilder.Entity<Fluent_BookDetail>().Property(x => x.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Fluent_BookDetail>().HasOne(x => x.Book).WithOne(x => x.BookDetail).HasForeignKey<Fluent_BookDetail>(x => x.BookId);

            modelBuilder.Entity<Fluent_Publisher>().HasKey(x => x.Id);
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Name).IsRequired();
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Name).HasMaxLength(50);
            modelBuilder.Entity<Fluent_Publisher>().Property(x => x.Address).HasMaxLength(100);

            modelBuilder.Entity<Fluent_BookReader>().HasKey(x => new { x.BookId, x.ReaderId });
            modelBuilder.Entity<Fluent_BookReader>().HasOne(x => x.Book).WithMany(x => x.BookReaders).HasForeignKey(x => x.BookId);
            modelBuilder.Entity<Fluent_BookReader>().HasOne(x => x.Reader).WithMany(x => x.BookReaders).HasForeignKey(x => x.ReaderId);
            modelBuilder.Entity<Fluent_BookReader>().ToTable("Fluent_BookReader");

            modelBuilder.Entity<Fluent_Employee>().HasKey(x=>x.Id);

            //modelBuilder.Entity<BookReader>().HasKey(x => new { x.BookId, x.ReaderId });


        }
        }
}
