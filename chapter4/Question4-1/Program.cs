using System;

//以下の順にTearMonthクラスを定義してください。
//本書で学んだイディオムが使えるところでは、イディオムを使ってください。

//1. 年（Year）と月（Month）の2つのプロパティを持つクラスYearMonthを定義してください。
//このとき、2つのプロパティは読み取り専用にし、値はコンストラクタで指定できるようにしてください。
//なお、引数で渡される月の値は1から12の範囲にあるものと仮定してかまいません。

//2. YearMonthクラスに、Is21Centuryプロパティを追加してください。
//2001年から2100年までが21世紀です。この処理では加減剰余を行わないでください。

//3. YearMonthクラスに、1ヶ月後を求めるAddOneMonthメソッドを追加してください。
//このとき、自分自身のプロパティは変更せずに、新たなYearMonthオブジェクトを生成しその値を返してください。
//12月のときの処理に注意してください。
//public YearMonth AddOneMonth(){
//    ここを実装する。
//}

//4. ToStringメソッドをオーバーライドしてください。
//結果は、”2017年8月”といった形式にしてください。
//public override string ToString(){
//    ここを実装する。
//}

namespace Question4_1 {
    class Program {
        static void Main(string[] args) {
            //各問題は、YearMonthクラスで実装しました。
            //以下、確認用
            YearMonth wYearMonth = new YearMonth(2000, 4);
            Console.WriteLine(wYearMonth);//2000年4月と出力
            Console.WriteLine(wYearMonth.AddOneMonth());//2000年5月と出力
        }
    }
}
