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
            Version wAssemblyVersion = wAssembly.GetName().Version;
            Console.WriteLine(wAssemblyVersion);

            // ファイルバージョンの表示
            string wLocation = wAssembly.Location;
            var wFileVersion = FileVersionInfo.GetVersionInfo(wLocation);
            Console.WriteLine(wFileVersion.FileVersion);

            Console.ReadLine();
        }
    }
}
