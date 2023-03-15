namespace Question17_2 {

    /// <summary>
    /// ヤード変換クラス
    /// </summary>
    public class YardConverter : ConverterBase {

        /// <summary>
        /// ヤード判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>ヤードかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "yard" || vName == UnitName;

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected override double Ratio { get { return 0.9144; } }

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public override string UnitName { get { return "ヤード"; } }
    }
}
