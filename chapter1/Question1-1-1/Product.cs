//「1.1：クラス」で定義したProductクラス
namespace IdiomProduct {
    public class Product {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        //コンストラクタ
        public Product(int vCode, string vName, int vPrice) {
            this.Code = vCode;
            this.Name = vName;
            this.Price = vPrice;
        }

        //消費税額を求める
        public int GetTax() {
            return (int)(Price * 0.08);
        }

        //税込み価格を求める
        public int GetPriceIncludingTax() {
            return Price + GetTax();
        }
    }
}
