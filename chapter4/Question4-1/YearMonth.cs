namespace Question4_1 {
    public class YearMonth {
        private int FCentury = 21;
        //1. の回答
        /// <summary>
        /// 年を表すプロパティ
        /// </summary>
        public int Year { get; private set; }
        /// <summary>
        /// 月を表すプロパティ
        /// </summary>
        public int Month { get; private set; }

        //2. の回答
        /// <summary>
        /// 21世紀を表すプロパティ
        /// </summary>
        public int Is21Century {
            get {
                return FCentury;
            }
            set {
                if (value < 2001 || value > 2100) FCentury = 0;
            }
        }

        /// <summary>
        /// YearMonthのコンストラクタ
        /// </summary>
        /// <param name="vYear"></param>
        /// <param name="vMonth"></param>
        public YearMonth(int vYear, int vMonth) {
            this.Year = vYear;
            this.Month = vMonth;
            this.Is21Century = vYear;
        }

        //3. の回答
        public YearMonth AddOneMonth() {
            if (Month == 12) {
                Month = 1;
            } else {
                Month++;
            }
            YearMonth YearAddOneMonth = new YearMonth(Year, Month);
            return YearAddOneMonth;
        }

        //4. の回答
        public override string ToString() {
            //ここを実装する
            string StringDay = Year.ToString() + "年" + Month.ToString() + "月";
            return StringDay;
        }
    }
}
