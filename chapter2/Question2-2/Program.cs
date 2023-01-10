using System;
//「2.1：距離換算プログラム」のコードを参考に、インチからメートルへの変換表を1インチ刻みで
//コンソールに出力するプログラムを書いてください。
//このときのインチの範囲は、1インチから10インチまでとしてください。
//1インチは0.0254メートルです。

namespace Question2_2 {
    class Program {
        static void Main(string[] args) {
            for(int inch = 0;inch <= 10;inch++){
                double meter = inch * 0.0254;
                Console.WriteLine("{0}ft = {1:0.0000}m",inch, meter);
            }
            Console.WriteLine("Hello World!");
        }
    }
}
