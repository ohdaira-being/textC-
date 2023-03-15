namespace Question17_2 {

    /// <summary>
    /// フィート変換クラス
    /// </summary>
    public class FeetConverter : ConverterBase {

        /// <summary>
        /// フィート判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>フィートかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "feet" || vName == UnitName;

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected override double Ratio { get { return 0.3048; } }

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public override string UnitName { get { return "フィート"; } }
    }
}
