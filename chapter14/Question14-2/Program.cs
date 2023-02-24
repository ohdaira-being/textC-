using System;
using System.Reflection;
using System.Diagnostics;

namespace Question14_2 {

    // 自分自身のファイルバージョンとアセンブリバージョンを表示する
    // コンソールアプリケーションを作成してください。

    class Program {
        static void Main(string[] args) {
            // アセンブリバージョンの表示
            var wAssembly = Assembly.GetExecutingAssembly();
            var wAssemblyVersion = wAssembly.GetName().Version;
            Console.WriteLine(
                $"{wAssemblyVersion.Major}.{wAssemblyVersion.Minor}." +
                $"{wAssemblyVersion.Build}.{wAssemblyVersion.Revision}"
                );

            // ファイルバージョンの表示
            string wLocation = wAssembly.Location;
            var wFileVersion = FileVersionInfo.GetVersionInfo(wLocation);
            Console.WriteLine(
                $"{wFileVersion.FileMajorPart}.{wFileVersion.FileMinorPart}." +
                $"{wFileVersion.FileBuildPart}.{wFileVersion.FilePrivatePart}"
                );

            Console.ReadLine();
        }
    }
}
