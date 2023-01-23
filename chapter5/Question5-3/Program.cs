using System;
using System.Linq;
using System.Text;

namespace Question5_3 {
    //"Jackdaws love my big sphix of quartz"という文字列があります。
    //この文字列に対して、以下の問題を解いてください。
    //1.　空白が何文字あるかカウントしてください。
    //2.　文字列中の"big"という部分文字列を"small"に置き換えてください。
    //3.　単語がいくつあるかカウントしてください。
    //4.　4文字以下の単語を列挙してください。
    //5.　空白で区切り、配列に格納した後、StringBuilderクラスを使い文字列を連結させ、
    //　　元の文字列と同じものを作り出してください。
    //　　元の文字列の中には、連続した空白は存在しないものとします。
    class Program {
        static void Main(string[] args) {
            string wInitialText = "Jackdaws love my big sphix of quartz";

            //1.　の回答
            Console.WriteLine(wInitialText.Count(x => x == ' '));

            //2. の回答
            Console.WriteLine(wInitialText.Replace("big", "small"));

            //3.　の回答
            string[] wInitialTextArray = wInitialText.Split(" ");
            Console.WriteLine(wInitialTextArray.Length);

            //4.　の回答
            foreach (string wFourLengthText in wInitialTextArray.Where(x => x.Length <= 4)) {
                Console.WriteLine(wFourLengthText);
            }

            //5.　の回答
            var wStringBuilder = new StringBuilder(50);
            foreach (string wText in wInitialTextArray) {
                wStringBuilder.Append(wText+" ");
            }
            Console.WriteLine(wStringBuilder);
        }
    }
}
