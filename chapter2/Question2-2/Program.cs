using System;
//「2.1：距離換算プログラム」のコードを参考に、インチからメートルへの変換表を1インチ刻みで
//コンソールに出力するプログラムを書いてください。
//このときのインチの範囲は、1インチから10インチまでとしてください。
//1インチは0.0254メートルです。

namespace Question2_2 {
    class Program {
        static void PrintInchToMeterList(int vStart, int vStop) {
            for (int inch = vStart; inch <= vStop; inch++) {
                double wMeter = inch * 0.0254;
                Console.WriteLine($"{inch}inch = {wMeter:0.0000}m");
            }
        }
        static void Main(string[] args) {
            PrintInchToMeterList(1, 10);
        }
    }
}
