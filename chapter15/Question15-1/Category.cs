namespace Question15_1 {
    /// <summary>
    /// カテゴリクラス
    /// </summary>
    public class Category {
        /// <summary>
        /// IDプロパティ
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// カテゴリ名プロパティ
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// ToStringメソッドをオーバーライド
        /// </summary>
        /// <returns>カテゴリクラスの要素の文字列</returns>
        public override string ToString() {
            return $"Id：{Id}、カテゴリ名：{Name}";
        }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vId">ID</param>
        /// <param name="vName">カテゴリ名</param>
        public Category(int vId, string vName) {
            this.Id = vId;
            this.Name = vName;
        }
    }
}
