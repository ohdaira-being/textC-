namespace Question4_1 {
    /// <summary>
    /// YearMonthクラス
    /// </summary>
    public class YearMonth {
        //1. の回答
        /// <summary>
        /// 年を表すプロパティ
        /// </summary>
        public int Year { get; }
        /// <summary>
        /// 月を表すプロパティ
        /// </summary>
        public int Month { get; }

        //2. の回答
        /// <summary>
        /// 21世紀を表すプロパティ
        /// </summary>
        public bool Is21Century {
            get {
                return 2001 <= Year && Year <= 2100;
            }
        }

        /// <summary>
        /// YearMonthのコンストラクタ
        /// </summary>
        /// <param name="vYear">vYear</param>
        /// <param name="vMonth">vMonth</param>
        public YearMonth(int vYear, int vMonth) {
            this.Year = vYear;
            this.Month = vMonth;
        }

        //3. の回答
        /// <summary>
        /// 1ヶ月後のYearMonthを求める
        /// </summary>
        /// <returns>YearMonth型の1ヶ月後の年月</returns>
        public YearMonth AddOneMonth() {
            int wNextMonth = this.Month;
            int wNextYear = this.Year;
            if (wNextMonth == 12) {
                wNextMonth = 1;
                wNextYear++;
            } else {
                wNextMonth++;
            }
            YearMonth wYearAddOneMonth = new YearMonth(wNextYear, wNextMonth);
            return wYearAddOneMonth;
        }

        //4. の回答
        public override string ToString() {
            return this.Year + "年" + this.Month + "月";
        }
    }
}
