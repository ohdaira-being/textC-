namespace Question17_2 {
    public class MeterConverter : ConverterBase {
        public override bool IsMyUnit(string vName) => vName.ToLower() == "meter" || vName == UnitName;
        protected override double Ratio { get { return 1; } }
        public override string UnitName { get { return "メートル"; } }
    }
}
