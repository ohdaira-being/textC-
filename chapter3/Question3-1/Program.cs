using System;
using System.Collections.Generic;
using System.Linq;
//問題3-1
//以下のリストが定義してあります。
//var number = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
//このリストに対して、ラムダ式を使い、次のコードを書いてください。

//1. List<T>のExistsメソッドを使い、8か9で割り切れる数字があるかどうかを調べ、
//その結果をコンソールに出力してください。

//2.　List<T>のForEachメソッドを使い、各要素を2.0で割った値をコンソールに出力してください。

//3. LINQのWhereメソッドを使い、値が50以上の要素を列挙し、その結果をコンソールに出力してください。

//4. LINQのSelectメソッドを使い、それぞれの値を2倍にし、その結果をList<int>に格納してください。
//その後、List<int>の各要素をコンソールに出力してください。

namespace Question3_1 {
    class Program {
        static void Main(string[] args) {
            //1.の回答
            var wNumbers = new List<int> { 12, 87, 94, 14, 53, 20, 40, 35, 76, 91, 31, 17, 48 };
            Console.WriteLine(wNumbers.Exists(x => x % 8 == 0 || x % 9 == 0));

            //2.の回答
            wNumbers.ForEach(x => Console.WriteLine(x / 2.0));

            //3. の回答
            foreach (int wNumber in wNumbers.Where(x => x >= 50)) {
                Console.WriteLine(wNumber);
            }

            //4. の回答
            foreach (int wNumber in wNumbers.Select(x => x * 2)) {
                Console.WriteLine(wNumber);
            }
        }
    }
}
