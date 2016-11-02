namespace WebApplication1
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class BlogDatabase : DbContext
    {
        //您的上下文已配置为从您的应用程序的配置文件(App.config 或 Web.config)
        //使用“BlogDatabase”连接字符串。默认情况下，此连接字符串针对您的 LocalDb 实例上的
        //“WebApplication1.BlogDatabase”数据库。
        // 
        //如果您想要针对其他数据库和/或数据库提供程序，请在应用程序配置文件中修改“BlogDatabase”
        //连接字符串。
        public BlogDatabase()
            : base("name=BlogDatabase")
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogArtice> BlogArticles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var blogTable = modelBuilder.Entity<Blog>();
            var blogArtticleTable = modelBuilder.Entity<BlogArtice>();

            blogTable.HasKey(o => o.Id);
            blogArtticleTable.HasKey(o => o.Id);

            base.OnModelCreating(modelBuilder);
        }
    }

    /// <summary>
    /// 播客
    /// </summary>
    public class Blog
    {
        public int Id { get; set; }
        public int Title { get; set; }//标题
    }

    /// <summary>
    /// 播客文章
    /// </summary>
    public class BlogArtice
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Subject { get; set; }//标题
        public string Body { get; set; }//文章内容
        public DateTime DateCreated { get; set; }//创建时间
    }

}