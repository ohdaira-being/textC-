namespace Question17_2 {
    public class MileConverter : ConverterBase {
        public override bool IsMyUnit(string vName) => vName.ToLower() == "mile" || vName == UnitName;
        protected override double Ratio { get { return 1609.344; } }
        public override string UnitName { get { return "マイル"; } }
    }
}
