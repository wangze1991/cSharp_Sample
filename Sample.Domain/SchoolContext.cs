using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Sample.Domain
{
    public class SchoolContext:DbContext,IDbContext
    {
        public SchoolContext()
            : base("name=MySchool")
        {
            Database.SetInitializer<SchoolContext>(new DropCreateDatabaseIfModelChanges<SchoolContext>());
        }

        #region property
        public DbSet<Student> Student { get; set; }
        public DbSet<StudentAddress> StudentAddress { get; set; }
        #endregion 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /**custome creating
             */
            modelBuilder.Entity<Student>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Student>().Property(x => x.RowVersion).IsRowVersion();

            modelBuilder.Entity<StudentAddress>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<StudentAddress>().Property(x => x.RowVersion).IsRowVersion();


            modelBuilder.Entity<Book>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Book>().Property(x => x.RowVersion).IsRowVersion();
            modelBuilder.Entity<Book>().Property(x => x.StudentId).IsOptional();
            modelBuilder.Entity<Book>().ToTable("Book");


            modelBuilder.Entity<Course>().Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Course>().Property(x => x.RowVersion).IsRowVersion();

            modelBuilder.Entity<Course>().ToTable("Course");

            #region 配置1对1 或者1对0的关系
            modelBuilder.Entity<StudentAddress>().HasKey(x => x.StudentId);
            //hasOption Student可以有StudentAddress 可以没有StudentAddress, WithRequired StudentAddress 必须要有Student
            //第一种方式
            modelBuilder.Entity<Student>().HasOptional(x=>x.StudentAddress).WithRequired(sa=>sa.Student);
            //第二种方式
            //modelBuilder.Entity<StudentAddress>().HasRequired(x => x.Student).WithOptional(s => s.StudentAddress);
            #endregion

            #region  配置1对多关系
            //modelBuilder.Entity<Book>().HasRequired(x => x.Student).WithMany(x => x.Books).HasForeignKey(x=>x.StudentId);

            //modelBuilder.Entity<Student>().HasMany(x => x.Books).WithOptional(x => x.Student).HasForeignKey(x => x.StudentId);
            #endregion

            #region 配置多对多关系
            modelBuilder.Entity<Student>().HasMany(x => x.Scores).WithRequired(x => x.Student).HasForeignKey(x => x.StudentId);
            modelBuilder.Entity<Course>().HasMany(x => x.Scores).WithRequired(x => x.Course).HasForeignKey(x=>x.CourseId);
            //modelBuilder.Entity<Course>().HasMany(x => x.Students).WithMany(x => x.Courses).Map(cs =>
            //{
            //    cs.MapLeftKey("StudentId");
            //    cs.MapRightKey("CourseId");

            //    cs.ToTable("StudentCourse");

            //});
            #endregion

            base.OnModelCreating(modelBuilder);
        }

        /// <summary>
        /// 获取当前实体所有数据
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns></returns>
        public new IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
          return this.Database.SqlQuery<TElement>(sql, parameters);
        }
         /// <summary>
        /// Executes the given DDL/DML command against the database.
        /// </summary>
        /// <param name="sql">The command string</param>
        /// <param name="doNotEnsureTransaction">false - the transaction creation is not ensured; true - the transaction creation is ensured.</param>
        /// <param name="timeout">Timeout value, in seconds. A null value indicates that the default value of the underlying provider will be used</param>
        /// <param name="parameters">The parameters to apply to the command string.</param>
        /// <returns>The result returned by the database after executing the command.</returns>
        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}