namespace Question17_2 {

    /// <summary>
    /// メートル変換クラス
    /// </summary>
    public class MeterConverter : ConverterBase {

        /// <summary>
        /// メートル判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>メートルかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "meter" || vName == UnitName;

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected override double Ratio { get { return 1; } }

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public override string UnitName { get { return "メートル"; } }
    }
}
