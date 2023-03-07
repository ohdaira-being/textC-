using System;

namespace Question14_6 {

    // 日本（東京）の現地時間から、
    // 対応する協定世界時とシンガポールの現地時間を表示するコードを書いてください。

    class Program {
        static void Main(string[] args) {
            Console.WriteLine(
                $"シンガポールの現地時刻：{TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, TimeZoneInfo.Local.Id, "Singapore Standard Time"):yyyy/MM/dd HH:mm:ss}"
                );
            Console.ReadLine();
        }
    }
}
