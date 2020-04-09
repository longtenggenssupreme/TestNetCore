using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Globalization;

namespace TestNetCore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //检查公告信息所属部门机构是否需要变更
            //1、顺序比较 Enumerable.SequenceEqual(new int[]{1,2 }, new int[] { 2,3})，比较现在的公告信息下的部门公告信息列表与原来的是否有变化
            //2、集合的交集，
            //(new int[] { 1, 2 }).Intersect(new int[] { 2, 3 })  2
            //(new int[] { 1, 2 }).Except(new int[] { 2, 3 }) 1

            string str = "red house";
            Console.WriteLine(System.Text.RegularExpressions.Regex.Replace(str, "^[a-z]", m => m.Value.ToUpper()));
            Console.WriteLine(Regex.Replace(str, @"^\w", t => t.Value.ToUpper()));

            Console.WriteLine(CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str.ToLower()));
            Console.WriteLine(new CultureInfo("en-US").TextInfo.ToTitleCase("red house"));
            if (Enumerable.SequenceEqual(new int[] { 1, 2 }, new int[] { 1, 2,4 }))
            {
                Console.WriteLine("一样!");
            }
            else
            {
                Console.WriteLine("不一样!");
            }
            
            Console.WriteLine("Hello World!");

            #region MyRegion
            //TestDBConext testDB = new TestDBConext();
            ////testDB.Database.EnsureDeleted();
            //if (testDB.Database.EnsureCreated())
            //{
            //    Console.WriteLine("数据库创建成功");
            //}
            //testDB.Add(new StudentAA { StudentName = "9999" });
            //testDB.SaveChanges(); 
            #endregion

            #region 测试一对一
            //Person person = testDB.Find<Person>(10);
            //testDB.Remove(person);
            //testDB.SaveChanges(); 
            #endregion

            #region 测试一对多
            //Product product = testDB.Find<Product>(10);
            //testDB.Remove(product);
            //testDB.SaveChanges();
            #endregion

            #region 测试多对多
            //Student student = testDB.Find<Student>(2);
            //testDB.Remove(student);
            //testDB.SaveChanges();

            //Teacher teacher = testDB.Find<Teacher>(8);
            //testDB.Remove(teacher);
            //testDB.SaveChanges();
            #endregion
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("成功");
            Console.ReadLine();
        }

        //public static unsafe string ToUpperFirst(this string str)
        //{
        //    if (str == null) return null;
        //    string ret = string.Copy(str);
        //    fixed (char* ptr = ret)
        //        *ptr = char.ToUpper(*ptr);
        //    return ret;
        //}
    }

    #region EntityFrameworkCore DbContext
    public class TestDBConext : DbContext
    {
        public TestDBConext()
        {
        }

        //public DbSet<Person> Persons { get; set; }第一种EF to DB映射方式
        //public DbSet<IdCard> IdCards { get; set; }第一种EF to DB映射方式

        //public DbSet<Product> Products { get; set; }第一种EF to DB映射方式
        //public DbSet<Category> Categorys { get; set; }第一种EF to DB映射方式 

        //public DbSet<Teacher> Teachers { get; set; }第一种EF to DB映射方式
        //public DbSet<Student> Students { get; set; }第一种EF to DB映射方式

        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(op => op.AddConsole().AddConsole());
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server =localhost;Database=mytest;Persist Security Info=True;User Id=sa;Password=sa123;");
            //optionsBuilder.UseMySql("Server =localhost;Database=mytest;User Id=root;Password=123456;");
            optionsBuilder.UseLoggerFactory(loggerFactory);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region 一对一
            //HasData()初始化参数
            //List<Person> list = new List<Person>();
            //List<IdCard> listIdCard = new List<IdCard>();
            //for (int i = 0; i < 10; i++)
            //{
            //    Person person = new Person { Id = i + 1, Name = $"{i}:name", IdCardId = i + 2 };
            //    list.Add(person);
            //    IdCard idCard = new IdCard { Id = i + 2, Name = $"{i}:name", PersonId = i + 1 };
            //    listIdCard.Add(idCard);
            //}

            #region 第二种EF to DB映射方式
            //创建表结构
            ////modelBuilder.Entity<Person>()
            ////.HasOne(a => a.IdCard).WithOne(a => a.Person).
            ////HasForeignKey<IdCard>(a => a.PersonId).OnDelete(DeleteBehavior.Cascade)//默认级联删除，即删除person就删除IdCard，这一句和下面一句效果一样
            //modelBuilder.Entity<Person>().HasOne(a => a.IdCard).WithOne(a => a.Person).HasForeignKey<IdCard>(a => a.PersonId);
            //初始化表数据
            //modelBuilder.Entity<Person>().HasData(list);
            //modelBuilder.Entity<IdCard>().HasData(listIdCard);
            #endregion

            #region 第三种EF to DB映射方式
            ////创建表结构
            //modelBuilder.ApplyConfiguration(new PersonMap());
            //modelBuilder.ApplyConfiguration(new IdCardMap());
            ////初始化表数据
            //modelBuilder.Entity<Person>().HasData(list);
            //modelBuilder.Entity<IdCard>().HasData(listIdCard);
            #endregion
            #endregion

            #region 一对多
            ////HasData()初始化参数
            //List<Product> list = new List<Product>();
            //List<Category> listCategory = new List<Category>();
            ////List<Category> productCategories = new List<Category>();
            //for (int i = 0; i < 10; i++)
            //{
            //    Product product = new Product { Id = i + 1, ProductName = $"{i}:Productname" };
            //    //var arry = Enumerable.Range(1, i).ToArray();
            //    for (int j = 0; j < i; j++)
            //    {
            //        Category category = new Category { Id = j + i * 10, CategoryName = $"{j}:Categoryname", ProductId = product.Id };
            //        listCategory.Add(category);
            //    }
            //    list.Add(product);
            //}

            #region 第二种EF to DB映射方式
            ////创建表结构
            ////modelBuilder.Entity<Product>().HasMany(a => a.Categories).WithOne(a => a.Product).OnDelete(DeleteBehavior.Cascade)//默认级联删除，即删除person就删除IdCard，
            ////这一句和下面一句效果一样
            //modelBuilder.Entity<Product>().HasMany(a => a.Categories).WithOne(a => a.Product);
            ////初始化表数据
            //modelBuilder.Entity<Product>().HasData(list);
            //modelBuilder.Entity<Category>().HasData(listCategory);
            #endregion

            #region 第三种EF to DB映射方式
            ////创建表结构
            //modelBuilder.ApplyConfiguration(new ProductMap());
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            ////初始化表数据
            //modelBuilder.Entity<Product>().HasData(list);
            //modelBuilder.Entity<Category>().HasData(listCategory);
            #endregion
            #endregion

            #region 多对多
            //HasData()初始化参数

            List<Student> list = new List<Student>
            {
                new Student { Id = 1, StudentName = $"StudentName 1" },
                new Student { Id = 2, StudentName = $"StudentName 2" },
                new Student { Id = 3, StudentName = $"StudentName 3" },
                new Student { Id = 4, StudentName = $"StudentName 4" }
            };
            List<Teacher> listTeacher = new List<Teacher>
            {
                new Teacher { Id = 6, TeacherName = $"StudentName 6" },
                new Teacher { Id = 7, TeacherName = $"StudentName 7" },
                new Teacher { Id = 8, TeacherName = $"StudentName 8" },
                 new Teacher { Id = 9, TeacherName = $"StudentName 9" }
            };
            List<StudentTeacher> studentTeacher = new List<StudentTeacher>
            {
                new StudentTeacher { StudentId = 1, TeacherId = 6 },
                new StudentTeacher { StudentId = 2, TeacherId = 6 },
                new StudentTeacher { StudentId = 3, TeacherId = 6 },
                new StudentTeacher { StudentId = 4, TeacherId = 6 },
                new StudentTeacher { StudentId = 2, TeacherId = 8 },
                new StudentTeacher { StudentId = 3, TeacherId = 8 },
                new StudentTeacher { StudentId = 4, TeacherId = 8 }
            };

            List<StudentAA> list1 = new List<StudentAA>
            {
                new StudentAA { StudentId = 33, StudentName = $"StudentName 1" },
                new StudentAA { StudentId = 244, StudentName = $"StudentName 2" },
                new StudentAA { StudentId = 377, StudentName = $"StudentName 3" },
                new StudentAA { StudentId = 4777, StudentName = $"StudentName 4" }
            };
            modelBuilder.ApplyConfiguration(new StudentAAMap());
            ////初始化表数据
            modelBuilder.Entity<StudentAA>().HasData(list1);


            #region 第二种EF to DB映射方式
            //创建表结构
            //////modelBuilder.Entity<Student>().HasMany(a => a.StudentTeachers).WithOne(a => a.Student).OnDelete(DeleteBehavior.Cascade)
            //////modelBuilder.Entity<Teacher>().HasMany(a => a.StudentTeachers).WithOne(a => a.Teacher).OnDelete(DeleteBehavior.Cascade)
            //modelBuilder.Entity<Student>().HasMany(a => a.StudentTeachers).WithOne(a => a.Student);
            //modelBuilder.Entity<Teacher>().HasMany(a => a.StudentTeachers).WithOne(a => a.Teacher);
            //modelBuilder.Entity<StudentTeacher>().HasKey(a => new { a.StudentId, a.TeacherId });
            ////modelBuilder.Entity<StudentTeacher>().HasOne(a => a.Student).WithMany(a => a.StudentTeachers).HasForeignKey(a => a.StudentId);
            ////modelBuilder.Entity<StudentTeacher>().HasOne(a => a.Teacher).WithMany(a => a.StudentTeachers).HasForeignKey(a => a.TeacherId);
            //////初始化表数据
            //modelBuilder.Entity<Student>().HasData(list);
            //modelBuilder.Entity<Teacher>().HasData(listTeacher);
            //modelBuilder.Entity<StudentTeacher>().HasData(studentTeacher);
            #endregion

            #region 第三种EF to DB映射方式
            ////创建表结构
            modelBuilder.ApplyConfiguration(new StudentMap());
            modelBuilder.ApplyConfiguration(new TeacherMap());
            modelBuilder.ApplyConfiguration(new StudentTeacherMap());
            ////初始化表数据
            modelBuilder.Entity<Student>().HasData(list);
            modelBuilder.Entity<Teacher>().HasData(listTeacher);
            modelBuilder.Entity<StudentTeacher>().HasData(studentTeacher);
            #endregion
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }


    #endregion
    public class StudentAA
    {
        //public int Id { get; set; }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }

    public class StudentAAMap : IEntityTypeConfiguration<StudentAA>
    {
        public void Configure(EntityTypeBuilder<StudentAA> builder)
        {
            builder.ToTable(nameof(StudentAA));
            //builder.HasKey(o => o.Id);
            builder.HasKey(o => o.StudentId);
            builder.Property(o => o.StudentName).HasColumnType("varchar(30)");
            //builder.HasMany(o => o.StudentTeachers).WithOne(o => o.Student); //这里写这一句和在StudentTeacherMap对应关系一样的
        }
    }

    public class PersonMap : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable(nameof(Person));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Name);
            builder.Property(o => o.IdCardId);
        }
    }
    public class IdCardMap : IEntityTypeConfiguration<IdCard>
    {
        public void Configure(EntityTypeBuilder<IdCard> builder)
        {
            builder.ToTable(nameof(IdCard));
            builder.HasKey(o => o.Id);
            //builder.Property(o => o.Name);//字段Name的类型默认是nvarchar(MAX)
            builder.Property(o => o.Name).HasColumnType("varchar(20)");
            builder.HasOne(o => o.Person).WithOne(o => o.IdCard).HasForeignKey<IdCard>(o => o.PersonId);
        }
    }

    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(nameof(Product));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.ProductName).HasColumnType("varchar(50)");
            builder.HasMany(o => o.Categories).WithOne(o => o.Product);
        }
    }
    public class CategoryMap : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(nameof(Category));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.CategoryName).HasColumnType("varchar(30)");
            //builder.HasOne(o => o.Product).WithMany(o => o.Categories).HasForeignKey(o => o.ProductId);
        }
    }

    public class StudentMap : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(nameof(Student));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.StudentName).HasColumnType("varchar(30)");
            //builder.HasMany(o => o.StudentTeachers).WithOne(o => o.Student); //这里写这一句和在StudentTeacherMap对应关系一样的
        }
    }

    public class TeacherMap : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable(nameof(Teacher));
            builder.HasKey(o => o.Id);
            builder.Property(o => o.TeacherName).HasColumnType("varchar(33)");
            //builder.HasMany(o => o.StudentTeachers).WithOne(o => o.Teacher);//这里写这一句和在StudentTeacherMap对应关系一样的
        }
    }

    public class StudentTeacherMap : IEntityTypeConfiguration<StudentTeacher>
    {
        public void Configure(EntityTypeBuilder<StudentTeacher> builder)
        {
            builder.ToTable(nameof(StudentTeacher));
            builder.HasKey(a => new { a.StudentId, a.TeacherId });
            builder.HasOne(a => a.Student).WithMany(a => a.StudentTeachers).HasForeignKey(a => a.StudentId);
            builder.HasOne(a => a.Teacher).WithMany(a => a.StudentTeachers).HasForeignKey(a => a.TeacherId);
        }
    }

    #region EntityFrameworkCore 实体类

    #region 一对一

    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCardId { get; set; }
        public IdCard IdCard { get; set; }
    }

    public class IdCard
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
    }
    #endregion

    #region 一对多
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public IList<Category> Categories { get; set; }
    }
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
    #endregion

    #region  多对多
    public class Student
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public IList<StudentTeacher> StudentTeachers { get; set; }
    }
    public class Teacher
    {
        public int Id { get; set; }
        public string TeacherName { get; set; }
        public IList<StudentTeacher> StudentTeachers { get; set; }
    }

    public class StudentTeacher
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
    #endregion
    #endregion
}
