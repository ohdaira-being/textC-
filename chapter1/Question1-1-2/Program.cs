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
        //「1.2：構造体」で定義した、MyClassとMyStructの二つを使い、以下のコードを書いてください。

        //1.MyClassとMyStructの二つの型を引数に取るメソッドPrintObjectsを定義してください。
        //PrintObjectsメソッドでは、二つのオブジェクトの内容（プロパティの値）をコンソールに表示するようにしてください。
        //なお、PrintObjectsメソッドは、Programクラスのメソッドとして定義してください。
        static void PrintObjects(MyClass vClass, MyStruct vStruct) {
            Console.WriteLine("myClass：({0},{1})", vClass.X, vClass.Y);
            Console.WriteLine("myStruct：({0},{1})", vStruct.X, vStruct.Y);
            vClass.X *= 2;
            vClass.Y *= 2;
            vStruct.X *= 2;
            vStruct.Y *= 2;
        }
        static void Main(string[] args) {

            //2.Mainメソッドで、PrintObjectsメソッドを呼び出すコードを書いてください。
            //MyClass、MyStructオブジェクトの値は、自由に決めて構いません。
            MyClass myClass = new MyClass(2, 3);
            MyStruct myStruct = new MyStruct(2, 3);
            Program.PrintObjects(myClass, myStruct);

            //3.PrintObjectsメソッド内で、それぞれのプロパティの値を2倍に変更するコード追加してください。
            //Mainメソッドでは、PrintObjects呼び出しの後に、MyClass、MyStructオブジェクトのプロパティの値をコンソールに表示するコードを加えてください。
            Console.WriteLine("myClass：({0},{1})", myClass.X, myClass.Y);
            Console.WriteLine("myStruct：({0},{1})", myStruct.X, myStruct.Y);

            //4.上のコードを実行し、結果を確認してください。
            //そして、どうしてそのような結果になったのか、理由を説明してください。

            //結果は
            //myClass：(2, 3)
            //myStruct：(2, 3)
            //myClass：(4, 6)
            //myStruct：(2, 3)
            //となった。
            //myClassの値だけが変わった。
            //myClassはclassで定義したので参照型、myStructはStructで定義したので値型。
            //参照型は、変数に値の保存先へのアクセス方法を保存し、保存先の値を参照して表すため、2倍した時に保存先の値が2倍される。
            //そのため、PrintObjectsメソッドを呼び出して2倍にした後に値を表示すると2倍になった。
            //しかし、値型は変数に値が保存されるため、同じ変数を使う度に値をコピーしている。
            //そのため、PrintObjectsメソッド内で2倍にした変数ではなく、同じMainメソッド内の値が表示された。
        }
    }
}
