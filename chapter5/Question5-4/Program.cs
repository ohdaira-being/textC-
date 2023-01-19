using System;
using System.Text;

namespace Question5_4 {
    //"Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886"という文字列から以下の出力を得る
    // コンソールアプリケーションを作成してください。
    //　　作家　：谷崎潤一郎
    //    代表作：春琴抄
    //    誕生年：1886
    class Program {
        static void Main(string[] args) {
            StringBuilder wInitialText = new StringBuilder("Novelist=谷崎潤一郎;BestWork=春琴抄;Born=1886");
            Console.WriteLine(
                wInitialText
                .Replace(";", "\n")
                .Replace("=", ":")
                .Replace("Novelist", "作家")
                .Replace("BestWork", "代表作")
                .Replace("Born", "誕生年")
                .ToString()
                );

        }
    }
}
