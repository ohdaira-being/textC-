using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Question11_1 {

    //chapter11で作成したXMLファイルに対して、1～4のコードを書いてください。
    //1.XMLファイルを読み込み、競技名とチームメンバー数の一覧を表示してください。
    //2.最初にプレイされた年の若い順に漢字の競技名を表示してください。
    //3.メンバー人数が最も多い競技名を表示してください。
    //4.サッカーの情報を追加して、新たなXMLファイルに出力してください。ファイル名は特に問いません。

    class Program {
        static void Main(string[] args) {

            string wFilePath = "../../../../BallSports.xml";

            // BallSports.xmlファイルがなければ、作成する。
            Console.WriteLine("BallSports.xmlファイルを作成、または、初期状態に戻しますか？\nはい　→　Y\nいいえ　→　Y以外の任意のキー");
            if (Console.ReadLine() == "Y") BallsportList.CreateBallSports(wFilePath);

            // BallSports.xmlファイルがなければ、強制終了させる。
            if (!File.Exists(wFilePath)) {
                Console.WriteLine("参照するファイルがないので、終了しました。");
                return;
            }

            // BallSports.xmlファイルを読み込んでwBallsportListsに格納する。
            IEnumerable<BallsportList> wBallsportLists = BallsportList.ReadBallsportLists(wFilePath);

            // 1.の回答
            Console.WriteLine("\n問題1の回答（競技名とチームメンバー数の一覧）");
            foreach (var wXList in wBallsportLists) {
                Console.WriteLine($"競技名：{wXList.Name}→{wXList.Teammembers}人");
            }

            // 2.の回答
            Console.WriteLine("\n問題2の回答（最初にプレイされた年の若い順）");
            foreach (var wXList in wBallsportLists.OrderBy(x => (int)(x.Firstplayed))) {
                Console.WriteLine($"{wXList.KanjiName}");
            }

            // 3.の回答
            Console.WriteLine("\n問題3の回答（メンバー人数が最も多い競技名）");
            foreach (var wXList in wBallsportLists) {
                if (!(wXList.Teammembers == wBallsportLists.Max(x => x.Teammembers))) continue;
                Console.WriteLine(wXList.Name);
            }

            // 4.の回答
            Console.WriteLine("\nBallSports.xmlファイルにサッカーのデータを追加しますか？\nはい　→　Y\nいいえ　→　Y以外の任意のキー");
            if (Console.ReadLine() == "Y") {
                string[] wSoccerData = { "ballsport", "フットボール", "蹴球", "11", "1863" };
                BallsportList.AddBallSport(wSoccerData, wFilePath);
            }
        }
    }
}
