using System;
using System.Linq;

namespace Question6_1 {
    //次のような配列が定義されています。
    //var numbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 }
    //この配列に対して、以下のコードを書いてください。
    //1.最大値を求め、結果を出力してください。
    //2.最後から2つの要素を取り出して表示してください。
    //3.それぞれの数値を文字列に変換し、結果を出力してください。
    //4.数の小さい順に並べ、先頭から3つを取り出し、結果を表示してください。
    //5.重複を排除した後、10より大きい値がいくつあるのかカウントし、結果を出力してください。

    class Program {
        static void Main(string[] args) {
            var wNumbers = new int[] { 5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35 };

            //1.　の回答
            Console.WriteLine(wNumbers.Max());

            //2. の回答
            foreach (int wNumber in wNumbers.Reverse().Take(2).ToArray()) {
                Console.WriteLine(wNumber);
            }

            //3. の回答
            Console.WriteLine(String.Join(" ", wNumbers.Select(x => x.ToString())));

            //追加
            foreach (var wStrNum in wNumbers.Select(x => x.ToString())) {
                Console.WriteLine($"{wStrNum.PadLeft(4, '0')}");
            }

            //4. の回答
            Console.WriteLine(String.Join(" ", wNumbers.OrderBy(x => x).Take(3)));

            //5. の回答
            Console.WriteLine(wNumbers.Distinct().Count(x => x > 10));
        }
    }
}
