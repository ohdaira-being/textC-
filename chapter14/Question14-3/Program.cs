using System;
using System.Configuration;

namespace Question14_3 {

    // 本文で示したmyAppSettings要素に以下のセクションを追加し、
    // プログラムから参照できるようにしてください。

    //<CalendarOption StringFormat = "yyyy年MM月dd日(ddd)"
    //    Minimum="1900/1/1"
    //    Maximum="2100/12/31"
    //    MondayIsFirstDay="True" />

    class Program {
        static void Main(string[] args) {
            var wMyAppSettings = ConfigurationManager.GetSection("myAppSettings") as MyAppSettings;
            TraceOption wTraceOption = wMyAppSettings.TraceOption;
            Console.WriteLine(wTraceOption.BufferSize);
            Console.WriteLine(wTraceOption.Enabled);
            Console.WriteLine(wTraceOption.FilePath);

            CalendarOption wCalendarOption = wMyAppSettings.CalendarOption;
            Console.WriteLine(wCalendarOption.StringFormat);
            Console.WriteLine(wCalendarOption.Minimum);
            Console.WriteLine(wCalendarOption.Maximum);
            Console.WriteLine(wCalendarOption.MondayIsFirstDay);

            Console.ReadLine();
        }
    }
}
