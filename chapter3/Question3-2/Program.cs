using System;
using System.Collections.Generic;
using System.Linq;

//問題3-2
//以下のリストが定義してあります。
//var name = new List<string>{
//    "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
//};
//このリストに対して、ラムダ式を使い、次のコードを書いてください。

//1. コンソールから入力した都市名が何番目に格納されているかList<T>のFindIndexメソッドを使って調べ、
//その結果をコンソールに出力してください。
//見つからなかったら、-1を出力してください。
//なお、コンソールからの入力には、Console.ReadLineメソッドを利用してください。
//var line = Console.ReadLine();

//2. LINQのCountメソッドを使い、小文字の'o'が含まれている都市名がいくつあるかカウントし、
//その結果をコンソールに出力してください。

//3. LINQのWhereメソッドを使い、小文字の'o'が含まれている都市名を抽出し、配列に格納してください。
//その後、配列の各要素をコンソールに出力してください。

//4. LINQのWhereメソッドとSelectメソッドを使い、'B'で始まる都市名の文字数を抽出し、
//その文字数をコンソールに出力してください。都市名を表示する必要は、ありません。
namespace Question3_2 {
    class Program {
        static void Main(string[] args) {
            var wNames = new List<string>{
                "Tokyo", "New Delhi", "Bangkok", "London", "Paris", "Berlin", "Canberra", "Hong Kong",
            };
            //1. の回答
            var wLine = Console.ReadLine();
            int wIndex = wNames.FindIndex(s => s == wLine);
            if (wIndex > 0) {
                Console.WriteLine(wIndex);
            }

            //2. の回答
            Console.WriteLine(wNames.Count(s => s.Contains('o')));

            //3. の回答
            foreach (string s in wNames.Where(s => s.Contains('o')).ToArray()) {
                Console.WriteLine(s);
            }

            //4. の回答
            foreach (int s in wNames.Where(s => s[0] == 'B').Select(s => s.Length)) {
                Console.WriteLine(s);
            }
        }
    }
}
