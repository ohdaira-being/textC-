using System;
using System.Globalization;

namespace Question8_1 {
    class Program {

        //現在の日時を以下のような3種類の書式でコンソールに出力してください。
        //2019/1/15 19:48
        //2019年01月15日 19時48分32秒
        //平成31年 1月15日（火曜日）

        static void Main(string[] args) {
            var wNow = DateTime.Now;
            Console.WriteLine(wNow.ToString("yyyy/M/d HH:mm"));
            Console.WriteLine(wNow.ToString("yyyy年MM月dd日 HH時mm分ss秒"));

            var wCulture = new CultureInfo("ja-JP");
            wCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
            var wDayOfWeek = wCulture.DateTimeFormat.GetDayName(wNow.DayOfWeek);
            Console.WriteLine(wNow.ToString($"ggyy年{wNow.Month,2}月{wNow.Day,2}日（{wDayOfWeek}）", wCulture));
        }
    }
}
