namespace Question17_2 {
    public abstract class ConverterBase {
        /// <summary>
        /// 単位反別
        /// </summary>
        /// <param name="vName">単位</param>
        /// <returns>真偽</returns>
        public abstract bool IsMyUnit(string vName);
        /// <summary>
        /// メートルとの比率
        /// </summary>
        protected abstract double Ratio { get; }
        /// <summary>
        /// 距離の単位
        /// </summary>
        public abstract string UnitName { get; }
        /// <summary>
        /// メートルからの変換
        /// </summary>
        /// <param name="vMeter">単位変換前の長さ</param>
        /// <returns>単位変換後の長さ</returns>
        public double FromMeter(double vMeter) => vMeter / Ratio;
        /// <summary>
        /// メートルへの変換
        /// </summary>
        /// <param name="vFeet">単位変換前の長さ</param>
        /// <returns>単位変換後の長さ</returns>
        public double ToMeter(double vFeet) => vFeet * Ratio;
    }
}
