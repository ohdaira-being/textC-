using System;

// 問題17-2
// 「17.3：Strategyパターン」で示した距離換算プログラムに機能を追加し、マイルとキロメートルも扱えるようにしてください。

namespace Question17_2 {
    class Program {
        static void Main(string[] args) {
            while (true) {
                ConverterBase wFrom = GetConverter("変換元の単位を入力してください");
                ConverterBase wTo = GetConverter("変換先の単位を入力してください");
                double wDistance = GetDistance(wFrom);

                var wConverter = new DistanceConverter(wFrom, wTo);
                double wResult = wConverter.Convert(wDistance);
                Console.WriteLine($"{wDistance}{wFrom.UnitName}は、{wResult:0.000}{wTo.UnitName}です\n");
            }
        }
        static double GetDistance(ConverterBase vFrom) {
            double? wValue = null;
            do {
                Console.WriteLine($"変換したい距離（単位：{vFrom.UnitName}）を入力してください。");
                string wLine = Console.ReadLine();
                double temp;
                wValue = double.TryParse(wLine, out temp) ? (double?)temp : null;
            } while (wValue == null);
            return wValue.Value;
        }
        static ConverterBase GetConverter(string vMsg) {
            ConverterBase wConverter = null;
            do {
                Console.WriteLine(vMsg + " => ");
                string wUnit = Console.ReadLine();
                wConverter = ConverterFactory.GetInstance(wUnit);
            } while (wConverter == null);
            return wConverter;
        }
    }
}
