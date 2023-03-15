namespace Question17_2 {

    /// <summary>
    /// 距離変換のベースクラス
    /// </summary>
    public abstract class ConverterBase {

        /// <summary>
        /// 単位判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>そのクラス（具象クラス）が扱える単位かどうか</returns>
        public abstract bool IsMyUnit(string vName);

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected abstract double Ratio { get; }

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public abstract string UnitName { get; }

        /// <summary>
        /// メートル単位の距離を他の単位の距離に変換する
        /// </summary>
        /// <param name="vMeter">単位変換前の距離(m)</param>
        /// <returns>単位変換後の距離</returns>
        public double FromMeter(double vMeter) => vMeter / this.Ratio;

        /// <summary>
        /// 他の単位の距離からメートル単位の距離に変換する
        /// </summary>
        /// <param name="vDistance">単位変換前の距離</param>
        /// <returns>単位変換後の距離(m)</returns>
        public double ToMeter(double vDistance) => vDistance * this.Ratio;
    }
}
