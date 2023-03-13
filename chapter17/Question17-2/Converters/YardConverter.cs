namespace Question17_2 {
    public class YardConverter : ConverterBase {
        public override bool IsMyUnit(string vName) => vName.ToLower() == "yard" || vName == UnitName;
        protected override double Ratio { get { return 0.9144; } }
        public override string UnitName { get { return "ヤード"; } }
    }
}
