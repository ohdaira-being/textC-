using System;
using System.Globalization;

namespace Question8_3 {
    class Program {
        //ある処理時間を計測するTimeWatchクラスを定義してください。

        static void Main(string[] args) {
            TimeWatch wTimeWatch = new TimeWatch();
            //計測開始
            wTimeWatch.Start();

            //処理（問題２にミリ秒表示を追加したコード）
            Console.WriteLine(DateTime.Now.ToString("yyyy/M/d HH:mm:ss:fff"));
            Console.WriteLine(DateTime.Now.ToString("yyyy年MM月dd日 HH時mm分ss秒fffミリ秒"));
            var wCulture = new CultureInfo("ja-JP");
            wCulture.DateTimeFormat.Calendar = new JapaneseCalendar();
            Console.WriteLine(
                DateTime.Now.ToString
                ($"ggyy年{DateTime.Now.Month,2}月{DateTime.Now.Day,2}日（dddd）（{DateTime.Now.Millisecond}）", wCulture)
                );

            //計測終了
            TimeSpan wElapsedTime = wTimeWatch.Stop();
            Console.WriteLine($"処理時間は、{wElapsedTime.TotalMilliseconds}ミリ秒でした。");
        }
    }
}

