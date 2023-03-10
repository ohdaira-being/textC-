using System.Data.Entity;

namespace chapter13.Models {
    /// <summary>
    /// DBアクセスクラス
    /// </summary>
    public class BooksDbContext : DbContext {
        /// <summary>
        /// コンストラクタ
        /// </summary>
        public BooksDbContext() : base("name=BooksDbContext") {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BooksDbContext, Configuration>());
        }

        /// <summary>
        /// 書籍プロパティ
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// 著者プロパティ
        /// </summary>
        public DbSet<Author> Authors { get; set; }
    }
}