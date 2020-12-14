using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WebApplication2.Models;

namespace WebApplication2.Data
{
    public partial class LibraryContext : DbContext
    {
        public LibraryContext()
        {
        }

        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<BookLanguage> BookLanguage { get; set; }
        public virtual DbSet<BookStatus> BookStatus { get; set; }
        public virtual DbSet<Borrow> Borrow { get; set; }
        public virtual DbSet<Reader> Readers { get; set; }
        public virtual DbSet<ReaderGender> ReaderGender { get; set; }
        public virtual DbSet<ReaderRole> ReaderRole { get; set; }
        public virtual DbSet<ReaderStatus> ReaderStatus { get; set; }
        public virtual DbSet<ReaderType> ReaderType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=localhost;user id=root;pwd=7DGKWdtpdf!;database=library;charset=utf8;port=3307;sslmode=none", x => x.ServerVersion("8.0.21-mysql"));
            }
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

            modelBuilder.Entity<Borrow>(entity =>
            {
                entity.HasIndex(e => e.BookId)
                    .HasName("book_id");

                entity.HasIndex(e => e.ReaderId)
                    .HasName("reader_id");

                entity.Property(e => e.BorrowContinueTimes)
                    .HasDefaultValueSql("'0'")
                    .HasComment("续借次数");

                entity.Property(e => e.DelayDays).HasComment("超时天数");

                entity.Property(e => e.DelayExpense).HasComment("超时产生金额");

                entity.Property(e => e.ExpectReturnDate).HasComment("应还日期");

                entity.Property(e => e.FineExpense).HasComment("罚款金额");

                entity.Property(e => e.LendDate).HasComment("借书日期");

                entity.Property(e => e.LendOperatorId).HasComment("借书操作员");

                entity.Property(e => e.ReturnOperatorId).HasComment("还书操作员");

                entity.HasOne(d => d.Book)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.BookId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("book_id");

                entity.HasOne(d => d.Reader)
                    .WithMany(p => p.Borrow)
                    .HasForeignKey(d => d.ReaderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reader_id");
            });

            modelBuilder.Entity<Reader>(entity =>
            {
                entity.HasIndex(e => e.ReaderGenderId)
                    .HasName("reader_gender_id");

                entity.HasIndex(e => e.ReaderRolesId)
                    .HasName("reader_roles_id");

                entity.HasIndex(e => e.ReaderStatusId)
                    .HasName("reader_status_id");

                entity.HasIndex(e => e.ReaderTypeId)
                    .HasName("reader_type_id");

                entity.Property(e => e.ReaderId).HasComment("读者ID");

                entity.Property(e => e.ReaderBorrowQuantity)
                    .HasDefaultValueSql("'0'")
                    .HasComment("借阅数量");

                entity.Property(e => e.ReaderDepartment)
                    .HasComment("单位")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ReaderEmail)
                    .HasComment("电子邮件")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ReaderGenderId).HasComment("性别");

                entity.Property(e => e.ReaderName)
                    .HasComment("读者姓名")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ReaderPassword)
                    .HasComment("密码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ReaderPhonenumber)
                    .HasComment("电话号码")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ReaderPhoto)
                    .HasComment("读者照片")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.ReaderRegisterDate).HasComment("注册日期");

                entity.Property(e => e.ReaderRolesId)
                    .HasDefaultValueSql("'0000'")
                    .HasComment("角色权限");

                entity.Property(e => e.ReaderStatusId).HasComment("读者状态");

                entity.Property(e => e.ReaderTypeId).HasComment("读者类别");

                entity.HasOne(d => d.ReaderGender)
                    .WithMany(p => p.Reader)
                    .HasForeignKey(d => d.ReaderGenderId)
                    .HasConstraintName("reader_gender_id");

                entity.HasOne(d => d.ReaderRoles)
                    .WithMany(p => p.Reader)
                    .HasForeignKey(d => d.ReaderRolesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("reader_roles_id");

                entity.HasOne(d => d.ReaderStatus)
                    .WithMany(p => p.Reader)
                    .HasForeignKey(d => d.ReaderStatusId)
                    .HasConstraintName("reader_status_id");

                entity.HasOne(d => d.ReaderType)
                    .WithMany(p => p.Reader)
                    .HasForeignKey(d => d.ReaderTypeId)
                    .HasConstraintName("reader_type_id");
            });

            modelBuilder.Entity<ReaderGender>(entity =>
            {
                entity.HasKey(e => e.GenderId)
                    .HasName("PRIMARY");

                entity.Property(e => e.GenderId).ValueGeneratedNever();

                entity.Property(e => e.GenderName)
                    .HasComment("性别")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");
            });

            modelBuilder.Entity<ReaderRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PRIMARY");

                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName)
                    .HasComment("角色权限")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");
            });

            modelBuilder.Entity<ReaderStatus>(entity =>
            {
                entity.HasKey(e => e.StatusIdR)
                    .HasName("PRIMARY");

                entity.Property(e => e.StatusIdR).ValueGeneratedNever();

                entity.Property(e => e.StatusName)
                    .HasComment("状态")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");
            });

            modelBuilder.Entity<ReaderType>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PRIMARY");

                entity.Property(e => e.TypeId).ValueGeneratedNever();

                entity.Property(e => e.TypeBorrowContinueTimes).HasComment("可续借次数");

                entity.Property(e => e.TypeBorrowDays).HasComment("可借书天数");

                entity.Property(e => e.TypeBorrowQuantity).HasComment("可借书数量");

                entity.Property(e => e.TypeExpirationDate).HasComment("借书许有效时长(Year)");

                entity.Property(e => e.TypeName)
                    .HasComment("类型")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_bin");

                entity.Property(e => e.TypeTimeoutExpense).HasComment("超时费用");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
