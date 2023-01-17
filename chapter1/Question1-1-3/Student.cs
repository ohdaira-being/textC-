using System;

namespace Question1_1_3 {
    //1.Personクラスを継承し、Studentクラスを定義してください。
    //Studentには、2つのプロパティ、Grade（学年）とClassNumber（組）を追加してください。
    //2つのプロパティとも型はintとします。
    class Student : Person {
        public int Grade { get; set; }
        public int ClassNumber { get; set; }
        public Student(string vName, DateTime vBirthday, int vGrade, int vClassNumber) {
            this.Name = vName;
            this.Birthday = vBirthday;
            this.Grade = vGrade;
            this.ClassNumber = vClassNumber;
        }
    }
}
