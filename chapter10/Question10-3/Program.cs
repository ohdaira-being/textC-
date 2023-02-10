using System;
using System.Text.RegularExpressions;

namespace Question10_3 {
    //以下の文字配列から、単語"time"が含まれる文字列を取り出し、timeの開始位置をすべて出力してください。
    //大文字・小文字の区別なく検索してください。
    class Program {
        static void Main(string[] args) {
            //以下の文字配列texts
            var wTexts = new[]{
                "Time is money.",
                "What time is it?",
                "It will take time.",
                "We reorganized the timetable.",
            };
            string wPattern = @"\b[Tt]ime\b";
            foreach (string wText in wTexts) {
                if (Regex.IsMatch(wText, wPattern)) {
                    Console.WriteLine(wText);
                    foreach (Match wMatchedWord in Regex.Matches(wText, wPattern)) {
                        Console.WriteLine($"開始位置：{wMatchedWord.Index,3}");
                    }
                }
            }
        }
    }
}
