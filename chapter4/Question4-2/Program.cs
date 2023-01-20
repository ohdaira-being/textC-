using Question4_1;
using System;
using System.Linq;



//問題4.1で定義したYearMonthクラスを使って、次のコードを書いてください。
//本書で学んだイディオムが使えるところでは、イディオムを使ってください。

//1. YearMonthを要素に持つ配列を定義し、初期値として5つのYearMonthオブジェクトをセットしてください。

//2. この配列の要素（YearMonthオブジェクト）をすべて列挙し、その値をコンソールに出力してください。

//3. 配列の中の最初に見つかった21世紀のYearMonthオブジェクトを返すメソッドを書いてください。
//見つからなかった場合は、nullを返してください。foreach文を使って実装してください。

//4. 3.で作成したメソッドを呼び出し、最初に見つかった21世紀のデータを表示してください。
//見つからなければ、”21世紀のデータはありません”を表示してください。

//5. 配列に格納されているすべてのYearMonthの1か月後を求め、その結果を新たな配列に入れてください。
//その後、その配列の要素の内容（年月）を順に表示してください。
//LINQを使えるところはLINQを使って実装してみてください。

namespace Question4_2 {
    class Program {
        //3. の回答
        static YearMonth ChooseFirstYearMonth(YearMonth[] vYearMonths) {
            foreach (YearMonth wYearMonth in vYearMonths) {
                if (wYearMonth.Is21Century) {
                    return wYearMonth;
                }
            }
            return null;
        }

        static void Main(string[] args) {
            //1. の回答
            var wYearMonths = new YearMonth[] {
                new YearMonth(1000, 12),
                new YearMonth(2100, 12),
                new YearMonth(2001, 1),
                new YearMonth(2000, 12),
                new YearMonth(2101, 12),
            };

            //2. の回答
            foreach (YearMonth wYearMonth in wYearMonths) {
                Console.WriteLine(wYearMonth);
            }

            //4. の回答
            Console.WriteLine("ここから4の回答");
            Console.WriteLine(ChooseFirstYearMonth(wYearMonths)?.ToString() ?? "21世紀のデータはありません");

            //追加要望
            Console.WriteLine("追加要望の回答");
            Console.WriteLine(wYearMonths.FirstOrDefault(x => x.Is21Century == true)?.ToString()?? "21世紀のデータはありません");

            //5. の回答
            Console.WriteLine("ここから5の1つ目の回答");
            foreach (YearMonth wYearAddMonth in wYearMonths.Select(x => x.AddOneMonth())) {
                Console.WriteLine(wYearAddMonth.ToString());
            }
            Console.WriteLine("ここから5の2つ目の回答");
            foreach (YearMonth wYearAddMonth in wYearMonths.Select(x => x.AddOneMonth()).OrderBy(x => x.Year).ThenBy(x => x.Month)) {
                Console.WriteLine(wYearAddMonth);
            }
        }
    }
}
