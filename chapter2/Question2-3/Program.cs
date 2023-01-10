using System;
//「2.2：売上集計プログラム」で作成したプログラムを変更し、商品カテゴリ別の
//売上高を求めるプログラムを作成してください。

namespace Question2_3 {
    class Program {
        static void Main(string[] args) {
            var sales = new SalesCounter("sales.csv");

            //店舗別集計
            var amountPerStore = sales.GetPerStoreSales();
            foreach (var obj in amountPerStore) {
                Console.WriteLine("{0}{1}", obj.Key, obj.Value);
            }

            //商品カテゴリ別集計
            var amountPerProductCategory = sales.GetPerProductCategorySales();
            foreach (var obj in amountPerProductCategory) {
                Console.WriteLine("{0}{1}", obj.Key, obj.Value);
            }
        }
    }
}
