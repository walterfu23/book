using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BooksAPI.REST.Model
{
    public partial class BooksDBContext : DbContext
    {
        public BooksDBContext()
        {
        }

        public BooksDBContext(DbContextOptions<BooksDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Author { get; set; }
        public virtual DbSet<BizDoc> BizDoc { get; set; }
        public virtual DbSet<BizDocRev> BizDocRev { get; set; }
        public virtual DbSet<BizDocRevPage> BizDocRevPage { get; set; }
        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<DocDocType> DocDocType { get; set; }
        public virtual DbSet<DocType> DocType { get; set; }
        public virtual DbSet<DocTypeSubCategory> DocTypeSubCategory { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<P8ObjectStore> P8ObjectStore { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=ssalt465hdy;Initial Catalog=ddnv1_flex;Integrated Security=False;User Id=sqluser;Password=SQLfilenet1");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UX_Author")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BizDoc>(entity =>
            {
                entity.ToTable("Biz_Doc");

                entity.HasIndex(e => e.DocName)
                    .HasName("UX_Biz_Doc_Name")
                    .IsUnique();

                entity.HasIndex(e => e.DocNum)
                    .HasName("UX_Biz_Doc_Num")
                    .IsUnique();

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DocName)
                    .IsRequired()
                    .HasColumnName("Doc_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.DocNum)
                    .IsRequired()
                    .HasColumnName("Doc_Num")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BizDocRev>(entity =>
            {
                entity.ToTable("Biz_Doc_Rev");

                entity.HasIndex(e => new { e.DocId, e.RevName })
                    .HasName("UX_Biz_Doc_Id_Rev_Name")
                    .IsUnique();

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.Property(e => e.LangNormalized)
                    .HasColumnName("Lang_Normalized")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LangOrig)
                    .HasColumnName("Lang_Orig")
                    .HasMaxLength(100);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RevName)
                    .IsRequired()
                    .HasColumnName("Rev_Name")
                    .HasMaxLength(250);

                entity.Property(e => e.RevNormalized)
                    .HasColumnName("Rev_Normalized")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RevOrig)
                    .HasColumnName("Rev_Orig")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.BizDocRev)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Biz_Doc_Rev_Biz_Doc");
            });

            modelBuilder.Entity<BizDocRevPage>(entity =>
            {
                entity.ToTable("Biz_Doc_Rev_Page");

                entity.HasIndex(e => new { e.RevId, e.PgNum })
                    .HasName("UX_Biz_Doc_Rev_Id_Page_Num")
                    .IsUnique();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PgKey1)
                    .HasColumnName("Pg_Key_1")
                    .HasMaxLength(250);

                entity.Property(e => e.PgKey2)
                    .HasColumnName("Pg_Key_2")
                    .HasMaxLength(250);

                entity.Property(e => e.PgNum).HasColumnName("Pg_Num");

                entity.Property(e => e.PgType)
                    .IsRequired()
                    .HasColumnName("Pg_Type")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.RevId).HasColumnName("Rev_Id");

                entity.HasOne(d => d.Rev)
                    .WithMany(p => p.BizDocRevPage)
                    .HasForeignKey(d => d.RevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Biz_Doc_Rev_Page_Biz_Doc_Rev");
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UX_Book")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Author");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Book)
                    .HasForeignKey(d => d.PublisherId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Book_Publisher");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => new { e.ListId, e.Name })
                    .HasName("UX_Category_Name")
                    .IsUnique();

                entity.HasIndex(e => new { e.ListId, e.Val })
                    .HasName("UX_Category")
                    .IsUnique();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DispOrder).HasColumnName("Disp_Order");

                entity.Property(e => e.ListId).HasColumnName("List_Id");

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Val)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.List)
                    .WithMany(p => p.Category)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_List");
            });

            modelBuilder.Entity<DocDocType>(entity =>
            {
                entity.HasKey(e => new { e.DocId, e.DocTypeId });

                entity.ToTable("Doc_Doc_Type");

                entity.Property(e => e.DocId).HasColumnName("Doc_Id");

                entity.Property(e => e.DocTypeId).HasColumnName("Doc_Type_Id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Doc)
                    .WithMany(p => p.DocDocType)
                    .HasForeignKey(d => d.DocId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doc_Doc_Type_Biz_Doc");

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.DocDocType)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doc_Doc_Type_Doc_Type");
            });

            modelBuilder.Entity<DocType>(entity =>
            {
                entity.ToTable("Doc_Type");

                entity.HasIndex(e => new { e.ListId, e.Name })
                    .HasName("UX_Doc_Type_Name")
                    .IsUnique();

                entity.HasIndex(e => new { e.ListId, e.Val })
                    .HasName("UX_Doc_Type")
                    .IsUnique();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DispOrder).HasColumnName("Disp_Order");

                entity.Property(e => e.ListId).HasColumnName("List_Id");

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Val)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.List)
                    .WithMany(p => p.DocType)
                    .HasForeignKey(d => d.ListId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doc_Type_List");
            });

            modelBuilder.Entity<DocTypeSubCategory>(entity =>
            {
                entity.HasKey(e => new { e.DocTypeId, e.SubcatId });

                entity.ToTable("Doc_Type_Sub_Category");

                entity.Property(e => e.DocTypeId).HasColumnName("Doc_Type_Id");

                entity.Property(e => e.SubcatId).HasColumnName("Subcat_Id");

                entity.Property(e => e.Comment)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.DocType)
                    .WithMany(p => p.DocTypeSubCategory)
                    .HasForeignKey(d => d.DocTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doc_Type_Sub_Category_Doc_Type");

                entity.HasOne(d => d.Subcat)
                    .WithMany(p => p.DocTypeSubCategory)
                    .HasForeignKey(d => d.SubcatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Doc_Type_Sub_Category_Sub_Category");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.HasIndex(e => e.ListName)
                    .HasName("UX_List")
                    .IsUnique();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ListLabel)
                    .HasColumnName("List_Label")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ListName)
                    .IsRequired()
                    .HasColumnName("List_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<P8ObjectStore>(entity =>
            {
                entity.ToTable("P8_Object_Store");

                entity.HasIndex(e => e.OsName)
                    .HasName("UX_P8_Object_Store")
                    .IsUnique();

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OsLabel)
                    .HasColumnName("OS_Label")
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.OsName)
                    .IsRequired()
                    .HasColumnName("OS_Name")
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Publisher>(entity =>
            {
                entity.HasIndex(e => e.Name)
                    .HasName("UX_Publisher")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("Sub_Category");

                entity.HasIndex(e => new { e.CatId, e.Name })
                    .HasName("UX_Sub_Category_Name")
                    .IsUnique();

                entity.HasIndex(e => new { e.CatId, e.Val })
                    .HasName("UX_Sub_Category")
                    .IsUnique();

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CreateTime)
                    .HasColumnName("Create_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Creator)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DispOrder).HasColumnName("Disp_Order");

                entity.Property(e => e.ModTime)
                    .HasColumnName("Mod_Time")
                    .HasColumnType("datetime");

                entity.Property(e => e.Modifier)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Val)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.SubCategory)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sub_Category_Category");
            });
        }
    }
}
