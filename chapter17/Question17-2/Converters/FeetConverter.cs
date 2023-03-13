namespace Question17_2 {
    public class FeetConverter : ConverterBase {
        public override bool IsMyUnit(string vName) => vName.ToLower() == "feet" || vName == UnitName;
        protected override double Ratio { get { return 0.3048; } }
        public override string UnitName { get { return "フィート"; } }
    }
}
