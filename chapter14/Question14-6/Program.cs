using System;

namespace Question14_6 {

    // 日本（東京）の現地時間から、
    // 対応する協定世界時とシンガポールの現地時間を表示するコードを書いてください。

    class Program {
        static void Main(string[] args) {
            var wJapanTime = DateTimeOffset.Now;
            DateTimeOffset wUtcTime = wJapanTime.ToUniversalTime();
            Console.WriteLine($"協定世界時：{wUtcTime:yyyy/MM/dd HH:mm:ss}");

            TimeZoneInfo wSingapore = TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time");
            Console.WriteLine(
                $"シンガポールの現地時刻：{(DateTimeOffset.Now.ToUniversalTime() + wSingapore.BaseUtcOffset):yyyy/MM/dd HH:mm:ss}"
                );

            Console.ReadLine();
        }
    }
}
