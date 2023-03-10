using System;
using System.Reflection;
using System.Diagnostics;

namespace Question14_2 {

    // 自分自身のファイルバージョンとアセンブリバージョンを表示する
    // コンソールアプリケーションを作成してください。

    class Program {
        static void Main(string[] args) {
            // アセンブリバージョンの表示
            Assembly wAssembly = Assembly.GetExecutingAssembly();
            Console.WriteLine(wAssembly.GetName().Version);
            // ファイルバージョンの表示
            Console.WriteLine(FileVersionInfo.GetVersionInfo(wAssembly.Location).FileVersion);
            Console.ReadLine();
        }
    }
}
