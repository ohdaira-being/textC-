namespace Question17_2 {

    /// <summary>
    /// インチ変換クラス
    /// </summary>
    public class InchConverter : ConverterBase {

        /// <summary>
        /// インチ判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>インチかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "inch" || vName == this.UnitName;

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected override double Ratio => 0.0254;

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public override string UnitName => "インチ";
    }
}
