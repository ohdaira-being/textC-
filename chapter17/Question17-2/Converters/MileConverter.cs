namespace Question17_2 {

    /// <summary>
    /// マイル変換クラス
    /// </summary>
    public class MileConverter : ConverterBase {

        /// <summary>
        /// マイル判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>マイルかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "mile" || vName == UnitName;

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected override double Ratio { get { return 1609.344; } }

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public override string UnitName { get { return "マイル"; } }
    }
}
