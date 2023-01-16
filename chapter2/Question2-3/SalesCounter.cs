using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Question2_3 {
    //売上集計クラス
    class SalesCounter {
        private IEnumerable<Sale> F_sales;

        //コンストラクタ
        public SalesCounter(string vFilePath) {
            F_sales = ReadSales(vFilePath);
        }

        //売上データを読み込み、Saleオブジェクトのリストを返す
        private static IEnumerable<Sale> ReadSales(string vFilePath) {
            var wSales = new List<Sale>();
            var wLines = File.ReadAllLines(vFilePath);
            foreach (var line in wLines) {
                var wItems = line.Split('、');
                var wSale = new Sale {
                    ShopName = wItems[0],
                    ProductCategory = wItems[1],
                    Amount = int.Parse(wItems[2])
                };
                wSales.Add(wSale);
            }
            return wSales;
        }

        //店舗別売上を求める
        public IDictionary<string, int> GetPerStoreSales() {
            var wDict = new Dictionary<string, int>();
            foreach (var sale in F_sales) {
                if (wDict.ContainsKey(sale.ShopName))
                    wDict[sale.ShopName] += sale.Amount;
                else
                    wDict[sale.ShopName] = sale.Amount;
            }
            return wDict;
        }

        //商品カテゴリ別の売上を求める
        public IDictionary<string, int> GetPerProductCategorySales() {
            var wDict = new Dictionary<string, int>();
            foreach (var sale in F_sales) {
                if (wDict.ContainsKey(sale.ProductCategory))
                    wDict[sale.ProductCategory] += sale.Amount;
                else
                    wDict[sale.ProductCategory] = sale.Amount;
            }
            return wDict;
        }
    }
}
