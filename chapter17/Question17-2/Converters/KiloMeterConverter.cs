namespace Question17_2 {

    /// <summary>
    /// キロメートル変換クラス
    /// </summary>
    public class KiloMeterConverter : ConverterBase {

        /// <summary>
        /// キロメートル判別プロパティ
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>キロメートルかどうか</returns>
        public override bool IsMyUnit(string vName) => vName.ToLower() == "kilometer" || vName == UnitName;

        /// <summary>
        /// メートルとの比率プロパティ
        /// </summary>
        protected override double Ratio { get { return 1000; } }

        /// <summary>
        /// 単位名プロパティ
        /// </summary>
        public override string UnitName { get { return "キロメートル"; } }
    }
}
