namespace Question6_2 {
    /// <summary>
    /// 教科書が定義したBookクラス
    /// </summary>
    class Book {
        /// <summary>
        /// 本のタイトルプロパティ
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 本の値段プロパティ
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// 本のページ数プロパティ
        /// </summary>
        public int Pages { get; set; }

        //追加
        /// <summary>
        /// 本のコンストラクタ
        /// </summary>
        /// <param name="vTitle">本のタイトル</param>
        /// <param name="vPrice">本の値段</param>
        /// <param name="vPages">本のページ数</param>
        public Book(string vTitle, int vPrice, int vPages) {
            this.Title = vTitle;
            this.Price = vPrice;
            this.Pages = vPages;
        }
    }
}
