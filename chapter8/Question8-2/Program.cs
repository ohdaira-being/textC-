using System;

namespace Question8_2 {
    class Program {

        //p.215「8.5.1：次の指定曜日を求める」のメソッドを参考に、次の週の指定曜日を求めるメソッドを定義してください。
        /// <summary>
        /// 次の週の指定曜日を求めるメソッド
        /// </summary>
        /// <param name="vDate">今日の日付</param>
        /// <param name="vDayOfWeek">指定曜日</param>
        /// <returns>次週の指定曜日の日にち</returns>
        public static DateTime NextDayOfWeek(DateTime vDate, DayOfWeek vDayOfWeek) {
            int wElapsedDays = (7 - (int)vDate.DayOfWeek) + (int)vDayOfWeek;
            return vDate.AddDays(wElapsedDays);
        }

        static void Main(string[] args) {
            //NextWeekDayメソッドの利用
            Console.WriteLine($"来週の金曜日は、{NextDayOfWeek(DateTime.Today, DayOfWeek.Friday).ToString("D")}");
        }
    }
}
