using System;
//「2.2：売上集計プログラム」で作成したプログラムを変更し、商品カテゴリ別の
//売上高を求めるプログラムを作成してください。

namespace Question2_3 {
    class Program {
        static void Main(string[] args) {
            var wSales = new SalesCounter("sales.csv");

            //店舗別集計
            var wAmountPerStores = wSales.GetPerStoreSales();
            foreach (var wAmountPerStore in wAmountPerStores) {
                Console.WriteLine($"{wAmountPerStore.Key}{wAmountPerStore.Value}");
            }

            //商品カテゴリ別集計
            var wAmountPerProductCategories = wSales.GetPerProductCategorySales();
            foreach (var wAmountPerProductCategory in wAmountPerProductCategories) {
                Console.WriteLine($"{wAmountPerProductCategory.Key}{wAmountPerProductCategory.Value}");
            }
        }
    }
}
