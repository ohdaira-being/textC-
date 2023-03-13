namespace Question17_2 {
    public class InchConverter : ConverterBase {
        public override bool IsMyUnit(string vName) => vName.ToLower() == "inch" || vName == UnitName;
        protected override double Ratio { get { return 0.0254; } }
        public override string UnitName { get { return "インチ"; } }
    }
}
