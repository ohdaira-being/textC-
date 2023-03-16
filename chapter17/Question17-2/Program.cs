using System;

// 問題17-2
// 「17.3：Strategyパターン」で示した距離換算プログラムに機能を追加し、マイルとキロメートルも扱えるようにしてください。

namespace Question17_2 {
    class Program {
        static void Main(string[] args) {
            while (true) {
                ConverterBase wFrom = GetConverter("変換元の単位をカタカナor英単語で入力してください。");
                ConverterBase wTo = GetConverter("変換先の単位をカタカナor英単語で入力してください。");
                double wDistance = GetDistance(wFrom);

                var wConverter = new DistanceConverter(wFrom, wTo);
                double wResult = wConverter.Convert(wDistance);
                Console.WriteLine($"{wDistance}{wFrom.UnitName}は、{wResult:0.000}{wTo.UnitName}です。\n");
            }
        }

        static double GetDistance(ConverterBase vFrom) {
            double? wValue = null;
            while (wValue == null) {
                Console.WriteLine($"変換したい距離（単位：{vFrom.UnitName}）を半角数字で入力してください。");
                string wLine = Console.ReadLine();
                if (double.TryParse(wLine, out double temp)) {
                    wValue = (double?)temp;
                } else {
                    Console.WriteLine("半角数字で入力してください。【再入力】\n");
                }
            };
            return wValue.Value;
        }

        static ConverterBase GetConverter(string vMessage) {
            ConverterBase wConverter = null;
            while (wConverter == null) {
                Console.WriteLine($"次の行に、{vMessage}");
                string wUnit = Console.ReadLine();
                wConverter = ConverterFactory.GetInstance(wUnit);
                if (wConverter == null) Console.WriteLine("入力された単位名は登録されていません。【再入力】\n");
            };
            return wConverter;
        }
    }
}
