using System;
using System.Text.RegularExpressions;

namespace Question10_1 {
    //指定された文字列が携帯電話の電話番号かどうか判定するメソッドを定義してください。
    //電話番号は、必ずハイフン（‐）で区切られていなければなりません。
    //また、先頭3文字は"090"、"080"、"070"のいずれかとします。
    class Program {
        static void Main(string[] args) {
            string wSampleText = "070-1765-4761";
            if (IsPhoneNum(wSampleText)) {
                Console.WriteLine("これは、電話番号です。");
            } else {
                Console.WriteLine("これは、電話番号ではありません。");
            }
        }

        private static bool IsPhoneNum(string vText) {
            //正規表現を使って、電話番号を書く
            string wPattern = @"^(0[789]0)(-\d{4}-\d{4})$";
            return Regex.IsMatch(vText, wPattern);
        }
    }
}
