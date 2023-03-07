using System.ComponentModel.DataAnnotations;

namespace chapter13.Models {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book {

        /// <summary>
        /// 書籍のIdプロパティ
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 書籍のタイトルプロパティ
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// 書籍の発行者プロパティ
        /// </summary>
        public string Publisher { get; set; }

        /// <summary>
        /// 書籍の発行年プロパティ
        /// </summary>
        public int PublishedYear { get; set; }

        /// <summary>
        /// 著者プロパティ
        /// </summary>
        public virtual Author Author { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// </summary>
        public Book() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">書籍のタイトル名</param>
        /// <param name="vPublishedYear">書籍の発行年</param>
        /// <param name="vPublisher">書籍の著者名</param>
        /// <param name="vAuthor">書籍の著者情報</param>
        public Book(string vTitle, int vPublishedYear, string vPublisher, Author vAuthor) {
            this.Title = vTitle;
            this.PublishedYear = vPublishedYear;
            this.Publisher = vPublisher;
            this.Author = vAuthor;
        }
    }
}
