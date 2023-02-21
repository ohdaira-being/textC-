using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace Question11_1 {

    //chapter11で作成したXMLファイルに対して、1～4のコードを書いてください。
    //1.XMLファイルを読み込み、競技名とチームメンバー数の一覧を表示してください。
    //2.最初にプレイされた年の若い順に漢字の競技名を表示してください。
    //3.メンバー人数が最も多い競技名を表示してください。
    //4.サッカーの情報を追加して、新たなXMLファイルに出力してください。ファイル名は特に問いません。

    class Program {
        private static IEnumerable<BallSport> ReadBallSportsFile(string vFilePath) {
            // ファイルが見つからないと例外になってしまう
            XDocument wXdoc = XDocument.Load(vFilePath);
            BallSport[] wBallSports = wXdoc.Root.Elements()
                                            .Select(x => new BallSport(
                                                 (string)x.Element("name"),
                                                 (string)x.Element("name").Attribute("kanji"),
                                                 (int)x.Element("teammembers"),
                                                 (int)x.Element("firstplayed")
                                            )).ToArray();
            return wBallSports;
        }

        private static void AddBallSport(BallSport vBallSportData, string vFilePath) {
            // BallSports.xmlファイルがなければ、作成する。
            if (!File.Exists(vFilePath)) {
                var wBallSports = new XElement("ballsports", "");
                XDocument wInitialData = new XDocument(wBallSports);
                wInitialData.Save(vFilePath);
            }

            XElement wAddData = new XElement(vBallSportData.ToXElement());
            XDocument wXdoc = XDocument.Load(vFilePath);

            wXdoc.Root.Add(wAddData);
            wXdoc.Save(vFilePath);
        }

        static void Main(string[] args) {
            var wBallSports = new BallSport[] {
                new BallSport("バスケットボール", "籠玉", 5, 1891),
                new BallSport("バレーボール", "排球", 6, 1895),
                new BallSport("ベースボール", "野球", 9, 1846),
            };

            string wFilePath = "../../../../BallSports.xml";

            // BallSports.xmlファイルがなければ、作成する。
            Console.WriteLine("BallSports.xmlファイルを作成、または、初期状態に戻しますか？\nはい　→　Y\nいいえ　→　Y以外の任意のキー");
            if (Console.ReadLine() == "Y") {
                foreach (var wBallSport in wBallSports) {
                    AddBallSport(wBallSport, wFilePath);
                }
            }

            IEnumerable<BallSport> wFileBallSports = ReadBallSportsFile(wFilePath);

            // 1.の回答
            Console.WriteLine("\n問題1の回答（競技名とチームメンバー数の一覧）");
            foreach (var wBallSport in wFileBallSports) {
                Console.WriteLine($"競技名：{wBallSport.Name}→{wBallSport.MemberCount}人");
            }

            // 2.の回答
            Console.WriteLine("\n問題2の回答（最初にプレイされた年の若い順）");
            foreach (var wBallSport in wFileBallSports.OrderBy(x => (int)(x.FirstPlayed))) {
                Console.WriteLine($"{wBallSport.KanjiName}");
            }

            // 3.の回答
            Console.WriteLine("\n問題3の回答（メンバー人数が最も多い競技名）");
            int wMaxCount = wFileBallSports.Max(x => x.MemberCount);
            foreach (var wBallSport in wFileBallSports.Where(x => x.MemberCount == wMaxCount)) {
                Console.WriteLine(wBallSport.Name);
            }

            // 4.の回答
            Console.WriteLine("\nBallSports.xmlファイルにサッカーのデータを追加しますか？\nはい　→　Y\nいいえ　→　Y以外の任意のキー");
            if (Console.ReadLine() == "Y") {
                AddBallSport(new BallSport("フットボール", "蹴球", 11, 1863), wFilePath);
            }
        }
    }
}
