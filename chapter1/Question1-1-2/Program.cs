using System;


namespace Question1_1_2 {
    //MyClassとMyStruct
    //クラス
    class MyClass {
        public int X { get; set; }
        public int Y { get; set; }

        public MyClass(int x, int y) {
            this.X = x;
            this.Y = y;
        }
    }
    //構造体
    struct MyStruct {
        public int X { get; set; }
        public int Y { get; set; }

        public MyStruct(int x, int y) {
            this.X = x;
            this.Y = y;
        }
    }
    class Program {
        static void Main(string[] args) {

            //「1.2：構造体」で定義した、MyClassとMyStructの二つを使い、以下のコードを書いてください。

            //1.MyClassとMyStructの二つの型を引数に取るメソッドPrintObjectsを定義してください。
            //PrintObjectsメソッドでは、二つのオブジェクトの内容（プロパティの値）をコンソールに表示するようにしてください。
            //なお、PrintObjectsメソッドは、Programクラスのメソッドとして定義してください。
            int PrintObjects(MyClass a, MyStruct b) {
                Console.WriteLine("myClassの2倍：({0},{1})", a.X * 2, a.Y * 2);
                Console.WriteLine("myStructの2倍：({0},{1})", b.X * 2, b.Y * 2);
                return 0;
            }

            //2.Mainメソッドで、PrintObjectsメソッドを呼び出すコードを書いてください。
            //MyClass、MyStructオブジェクトの値は、自由に決めて構いません。
            MyClass myClass = new MyClass(2, 3);
            MyStruct myStruct = new MyStruct(2, 3);
            PrintObjects(myClass, myStruct);

            //3.PrintObjectsメソッド内で、それぞれのプロパティの値を2倍に変更するコード追加してください。
            //Mainメソッドでは、PrintObjects呼び出しの後に、MyClass、MyStructオブジェクトのプロパティの値をコンソールに表示するコードを加えてください。
            Console.WriteLine("myClass：({0},{1})", myClass.X, myClass.Y);
            Console.WriteLine("myStruct：({0},{1})", myStruct.X, myStruct.Y);

            //4.上のコードを実行し、結果を確認してください。
            //そして、どうしてそのような結果になったのか、理由を説明してください。

                //結果は
                //myClassの2倍：(4,6)
                //myStructの2倍：(4, 6)
                //myClass：(2, 3)
                //myStruct：(2, 3)
                //となった。
                //クラスも構造体も同じ処理を行った。
                //また、値の代入を行っていないため、同じ結果となった。
        }
    }
}
