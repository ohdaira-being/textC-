using System;

namespace Question5_2 {
    //コンソールから入力した数字文字列をint型に変換した後、カンマ付きの数字文字列に変換してください。
    //入力した文字列は、int.TryParseメソッドで数値に変換してください。
    class Program {
        static void Main(string[] args) {
            if (!int.TryParse(Console.ReadLine(), out int wInputNumber)) {
                Console.WriteLine("数字文字列を入力してください");
            } else {
                Console.WriteLine(String.Format("{0,10:#,0}", wInputNumber));
            }
        }
    }
}
