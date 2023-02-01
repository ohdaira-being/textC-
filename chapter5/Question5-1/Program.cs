using System;
using System.Globalization;

namespace Question5_1 {
    //コンソールから入力した2つの文字列が等しいか調べるコードを書いてください。
    //このとき、大文字、小文字の違いは無視するようにしてください。
    //コンソールからの入力は、Console.ReadLineメソッドを利用してください。
    class Program {
        static void Main(string[] args) {
            var wCultureInfo = new CultureInfo("ja-JP");

            if (String.Compare(Console.ReadLine(), Console.ReadLine(), wCultureInfo,
                CompareOptions.IgnoreCase | CompareOptions.IgnoreKanaType | CompareOptions.IgnoreWidth) == 0) {
                Console.WriteLine("一致しています。");
            } else {
                Console.WriteLine("一致していません。");
            }
        }
    }
}
