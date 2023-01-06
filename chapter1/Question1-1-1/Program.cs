using IdiomProduct;
using System;


//「1.1：クラス」で定義したProductクラス
namespace IdiomProduct {
    public class Product {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Price { get; private set; }
        //コンストラクタ
        public Product(int code, string name, int price) {
            this.Code = code;
            this.Name = name;
            this.Price = price;
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

namespace Question1_1_1 {
    class Program {
        static void Main(string[] arg) {
            //問題1.1
            //「1.1：クラス」で定義したProductクラスを使い、以下のコードを書いてください。
            //1.どら焼きオブジェクトを生成するコードを書いてください。この時の商品番号は"98"、商品価格は"210円"としてください。
            Product dorayaki = new Product(98, "どら焼き", 210);

            //2.どら焼きオブジェクトの消費税額を求め、コンソールに出力するコードを書いてください。
            int dorayakiTax = dorayaki.GetTax();
            Console.WriteLine(dorayakiTax);

            //3.Productクラスが属する名前空間を別の名前空間に変更し、Mainメソッドから呼び出すようにしてください。
            //ただし、MainメソッドのあるProgramクラスの名前空間はそのままとしてください。

            //Productクラスにnamespaceを追加し、別の名前空間に変更した。
            //そして、Productクラスの名前空間をusingに書いて、programクラスのMainメソッドから呼び出せるようにした。
        }
    }
}
