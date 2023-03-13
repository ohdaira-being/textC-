using TextFileProcessor;

// 問題17-1
// 「17.2：Template Methodパターン」で示したTextProcessorクラスを使い、テキストファイルの中の全角数字を
// すべて半角数字に置き換えて、置き換えた結果をコンソールに出力するプログラムを作ってください。

namespace Question17_1 {
    class Program {
        static void Main(string[] args) {
            TextProcessor.Run<ToHankakuProcessor>(args[0]);
        }
    }
}
