namespace Question17_2 {
    public class KiloMeterConverter : ConverterBase {
        public override bool IsMyUnit(string vName) => vName.ToLower() == "kilometer" || vName == UnitName;
        protected override double Ratio { get { return 1000; } }
        public override string UnitName { get { return "キロメートル"; } }
    }
}
