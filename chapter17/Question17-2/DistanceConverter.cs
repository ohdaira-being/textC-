namespace Question17_2 {

    /// <summary>
    /// 距離変換クラス
    /// </summary>
    class DistanceConverter {

        /// <summary>
        /// 変換前の距離プロパティ
        /// </summary>
        public ConverterBase From { get; private set; }

        /// <summary>
        /// 変換後の距離プロパティ
        /// </summary>
        public ConverterBase To { get; private set; }

        /// <summary>
        /// 距離変換
        /// </summary>
        /// <param name="vFrom">変換前の距離情報</param>
        /// <param name="vTo">変換後の距離情報</param>
        public DistanceConverter(ConverterBase vFrom, ConverterBase vTo) {
            this.From = vFrom;
            this.To = vTo;
        }

        /// <summary>
        /// 距離の長さ変換
        /// </summary>
        /// <param name="vValue">変換前の長さ</param>
        /// <returns>変換後の長さ</returns>
        public double Convert(double vValue) {
            double wMeter = this.From.ToMeter(vValue);
            return this.To.FromMeter(wMeter);
        }
    }
}
