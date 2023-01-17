using System;

namespace Question1_1_3 {
    class Program {
        //2.Studentクラスのインスタンスを生成するコードを書いてください。
        //この時、全てのプロパティに値を設定してください。
        static void Main(string[] args) {
            Student wStudent = new Student ("大平", new DateTime(1900, 11, 19),100, 20) ;

            //3.2で生成したインスタンスの各プロパティの値をコンソールに出力するコードを書いてください。
            Console.WriteLine($"{wStudent.Name}は、{wStudent.Birthday}生まれで{wStudent.Grade}学年の{wStudent.ClassNumber}組です。");

            //4.2で生成したインスタンスをPerson型およびobject型の変数に代入できることを確認してください。

            //Person型、object型、それぞれの変数を生成し、その変数に2で生成したインスタンスが代入できるかを確認する。
            Person wPerson = new Person();//Person型の変数を生成
            wPerson = wStudent;//Person型の変数に2で生成したインスタンスを代入
            Console.WriteLine($"{wPerson.Name}は、{wPerson.Birthday}生まれ");
            //正常に表示されたので、Person型の変数に代入できることが確認できた。
            object wObject = wStudent;//object型の変数を生成し、2で生成したインスタンスを代入
            if(wObject == wStudent){ 
                Console.WriteLine("object型に代入出来ました");
            }
            //コンソールで「object型に代入出来ました」と表示されたので、object型に代入できることが確認できた。
        }
    }
}
