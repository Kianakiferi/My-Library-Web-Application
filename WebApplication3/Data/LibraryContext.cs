using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
	public partial class LibraryContext : DbContext
	{
		public LibraryContext(DbContextOptions<LibraryContext> options)
			: base(options)
		{
		}

		public virtual DbSet<Book> Books { get; set; }
		public virtual DbSet<BookLanguage> BookLanguage { get; set; }
		public virtual DbSet<BookStatus> BookStatus { get; set; }
		public virtual DbSet<Borrow> Borrow { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseMySql("server=localhost;user id=root;pwd=7DGKWdtpdf!;database=testlibrary;charset=utf8;port=3307", x => x.ServerVersion("8.0.21-mysql"));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Book>(entity =>
			{
				entity.HasIndex(e => e.BookLanguageId)
					.HasName("book_language_id");

				entity.HasIndex(e => e.BookStatusId)
					.HasName("book_status_id");

				entity.Property(e => e.BookId).HasComment("图书序号");

				entity.Property(e => e.BookAuthor)
					.HasComment("作者")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookBrief)
					.HasComment("内容简介")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookClccode)
					.HasComment("CLC 分类号")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookCode)
					.HasComment("图书编号或条码号")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookCover)
					.HasComment("封面")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookIsbn)
					.HasComment("ISBN 书号")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookLanguageId).HasComment("语言ID");

				entity.Property(e => e.BookName)
					.HasComment("书名")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookNameSub)
					.HasComment("副书名")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookPages).HasComment("页数");

				entity.Property(e => e.BookPressDate).HasComment("出版日期");

				entity.Property(e => e.BookPrice).HasComment("价格");

				entity.Property(e => e.BookPublisher)
					.HasComment("出版社")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");

				entity.Property(e => e.BookPurchaseDate).HasComment("入馆时间");

				entity.Property(e => e.BookStatusId).HasComment("图书状态ID");

				entity.HasOne(d => d.BookLanguage)
					.WithMany(p => p.Book)
					.HasForeignKey(d => d.BookLanguageId)
					.HasConstraintName("book_language_id");

				entity.HasOne(d => d.BookStatus)
					.WithMany(p => p.Book)
					.HasForeignKey(d => d.BookStatusId)
					.HasConstraintName("book_status_id");
			});

			modelBuilder.Entity<BookLanguage>(entity =>
			{
				entity.HasKey(e => e.LanguageId)
					.HasName("PRIMARY");

				entity.Property(e => e.LanguageId).ValueGeneratedNever();

				entity.Property(e => e.LanguageName)
					.HasComment("语言类型")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");
			});

			modelBuilder.Entity<BookStatus>(entity =>
			{
				entity.HasKey(e => e.StatusId)
					.HasName("PRIMARY");

				entity.Property(e => e.StatusId).ValueGeneratedNever();

				entity.Property(e => e.StatusName)
					.HasComment("图书状态")
					.HasCharSet("utf8mb4")
					.HasCollation("utf8mb4_bin");
			});


			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
