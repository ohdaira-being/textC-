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
        static YearMonth ChooseFirstYearMonth(YearMonth[] vYMArrays) {
            YearMonth FirstYearMonth = null;
            foreach (YearMonth YMArray in vYMArrays) {
                if (YMArray.Is21Century == 21) {
                    FirstYearMonth = YMArray;
                    break;
                }
            }
            return FirstYearMonth;
        }

        static void Main(string[] args) {
            //1. の回答
            var ArrayYearMonths = new YearMonth[] {
                new YearMonth(200, 2),
                new YearMonth(2010, 3),
                new YearMonth(2020, 4),
                new YearMonth(260, 6),
                new YearMonth(2090, 12),
            };

            //2. の回答
            foreach (YearMonth ArrayYearMonth in ArrayYearMonths) {
                Console.WriteLine(ArrayYearMonth);
            }

            //4. の回答
            Console.WriteLine("ここから4の回答");
            YearMonth wChooseYearMonth = ChooseFirstYearMonth(ArrayYearMonths);
            if (wChooseYearMonth == null) {
                Console.WriteLine("21世紀のデータはありません");
            } else {
                Console.WriteLine(wChooseYearMonth);
            }

            //5. の回答
            Console.WriteLine("ここから5の1つ目の回答");
            foreach (YearMonth wArrayYearAddMonth in ArrayYearMonths.Select(x => x.AddOneMonth())) {
                Console.WriteLine(wArrayYearAddMonth);
            }
            Console.WriteLine("ここから5の2つ目の回答");
            var wArrayYearAddMonths_Lists = ArrayYearMonths.OrderBy(x => x.Year).ThenBy(x => x.Month);
            foreach (YearMonth wArrayYearAddMonths_List in wArrayYearAddMonths_Lists) {
                Console.WriteLine(wArrayYearAddMonths_List);
            }
        }
    }
}
