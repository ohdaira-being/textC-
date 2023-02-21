using System.Data.Entity.Migrations;

namespace chapter13.Models {
    /// <summary>
    /// 自動マイグレーション用クラス
    /// </summary>
    internal sealed class Configuration : DbMigrationsConfiguration<BooksDbContext> {

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "chapter13.Models.BookDbContext";
        }
    }
}
