namespace Question15_1 {
    /// <summary>
    /// 書籍クラス
    /// </summary>
    public class Book {
        /// <summary>
        /// タイトルプロパティ
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 値段プロパティ
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// IDプロパティ
        /// </summary>
        public int CategoryId { get; }
        /// <summary>
        /// 発行年プロパティ
        /// </summary>
        public int PublishedYear { get; set; }
        /// <summary>
        /// ToStringをオーバーライド
        /// </summary>
        /// <returns>書籍クラスの文字列</returns>
        public override string ToString() => $"発行年：{this.PublishedYear}、カテゴリ名：{this.CategoryId}、価格：{this.Price}、タイトル：{this.Title}";
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル名</param>
        /// <param name="vCategoryId">ID</param>
        /// <param name="vPrice">値段</param>
        /// <param name="vPublisherYear">発行年</param>
        public Book(string vTitle, int vCategoryId, int vPrice, int vPublisherYear) {
            this.Title = vTitle;
            this.Price = vPrice;
            this.CategoryId = vCategoryId;
            this.PublishedYear = vPublisherYear;
        }
    }
}
