using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Question2_3 {
    /// <summary>
    /// 売上集計クラス
    /// </summary>
    class SalesCounter {
        private IEnumerable<Sale> F_sales;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vFilePath">読み込むファイルのパス</param>
        public SalesCounter(string vFilePath) {
            F_sales = ReadSales(vFilePath);
        }

        /// <summary>
        /// 売上データを読み込み、Saleオブジェクトのリストを返す
        /// </summary>
        /// <param name="vFilePath"></param>
        /// <returns>wSales</returns>
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

        /// <summary>
        /// 店舗別売上を求める
        /// </summary>
        /// <returns>wDict</returns>
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

        /// <summary>
        /// 商品カテゴリ別の売上を求める
        /// </summary>
        /// <returns>wDict</returns>
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
