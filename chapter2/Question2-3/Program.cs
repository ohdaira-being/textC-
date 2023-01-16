using System;
//「2.2：売上集計プログラム」で作成したプログラムを変更し、商品カテゴリ別の
//売上高を求めるプログラムを作成してください。

namespace Question2_3 {
    class Program {
        static void Main(string[] args) {
            var wSales = new SalesCounter("sales.csv");

            //店舗別集計
            var wAmountPerStore = wSales.GetPerStoreSales();
            foreach (var obj in wAmountPerStore) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }

            //商品カテゴリ別集計
            var wAmountPerProductCategory = wSales.GetPerProductCategorySales();
            foreach (var obj in wAmountPerProductCategory) {
                Console.WriteLine($"{obj.Key}{obj.Value}");
            }
        }
    }
}
