using System;

namespace Question1_1_3 {
    //「1.6:継承」で示したPersonクラス
    public class Person {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GetAge() {
            DateTime today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            if (today < Birthday.AddYears(age)) {
                age--;
            }
            return age;
        }
    }

    //1.Personクラスを継承し、Studentクラスを定義してください。
    //Studentには、2つのプロパティ、Grade（学年）とClassNumber（組）を追加してください。
    //2つのプロパティとも型はintとします。
    class Student : Person {
        public int Grade { get; set; }
        public int ClassNumber { get; set; }
        public Student(string vName, DateTime vBirthday, int vGrade, int vClassNumber){ 
            this.Name = vName;
            this.Birthday = vBirthday;
            this.Grade = vGrade;
            this.ClassNumber = vClassNumber;
        }
    }

    class Program {
        //2.Studentクラスのインスタンスを生成するコードを書いてください。
        //この時、全てのプロパティに値を設定してください。
        static void Main(string[] args) {
            Student student = new Student ("大平", new DateTime(1900, 11, 19),100, 20) ;

            //3.2で生成したインスタンスの各プロパティの値をコンソールに出力するコードを書いてください。
            Console.WriteLine($"{student.Name}は、{student.Birthday}生まれで{student.Grade}学年の{student.ClassNumber}組です。");

            //4.2で生成したインスタンスをPerson型およびobject型の変数に代入できることを確認してください。
            int age = student.GetAge();
            Console.WriteLine(age);
            //122と表示された。
            //studentの変数がPersonで定義したメソッド内の変数に代入できることが確認できた。
            //また、Console.WriteLineで表示されたので、object型にも代入できることが確認できた。
        }
    }
}
