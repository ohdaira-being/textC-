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

        /// <summary>
        /// vFilePathを読み込み、全てのBallsportのプロパティを配列にして返すメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルのパス</param>
        /// <returns>読み込んだファイルの全てのBallSportのプロパティを配列化</returns>
        public static IEnumerable<BallSport> ReadXFileToBallsports(string vFilePath) {

            // ファイルが見つからないと例外になってしまう
            XDocument wXdoc = XDocument.Load(vFilePath);

            BallSport[] wReadedBallSports = wXdoc.Root.Elements()
                                            .Select(x => new BallSport(
                                                 (string)x.Element("name"),
                                                 (string)x.Element("name").Attribute("kanji"),
                                                 (int)x.Element("teammembers"),
                                                 (int)x.Element("firstplayed")
                                            )).ToArray();
            return wReadedBallSports;
        }

        // BallsportListに書き込む。
        /// <summary>
        /// vFilePathに追加で書き込むメソッド
        /// </summary>
        /// <param name="vBallSportData">追加するBallSport</param>
        /// <param name="vFilePath">書き込み先のファイルパス</param>
        public static void AddBallSport(BallSport vBallSportData, string vFilePath) {

            // BallSports.xmlファイルがなければ、作成する。
            if (!File.Exists(vFilePath)) {
                var wBallSports = new XElement("ballsports", "");
                XDocument wInitialData = new XDocument(wBallSports);
                wInitialData.Save(vFilePath);
            }

            XElement wAddData = new XElement(BallSport.ToXElement(vBallSportData));
            XDocument wXdoc = XDocument.Load(vFilePath);

            wXdoc.Root.Add(wAddData);
            wXdoc.Save(vFilePath);
        }

        static void Main(string[] args) {

            // BallSportのインスタンス生成
            var wBallSports = new BallSport[]{
            new BallSport("バスケットボール", "籠玉", 5, 1891),
            new BallSport("バレーボール", "排球", 6, 1895),
            new BallSport("ベースボール", "野球", 9, 1846),
            };

            // BallSportCollectionのインスタンス生成
            var wBallSportCollection = new BallSportCollection(wBallSports);

            // ファイルパス
            string wFilePath = "../../../../BallSports.xml";


            // BallSports.xmlファイルがなければ、作成する。
            Console.WriteLine("BallSports.xmlファイルを作成、または、初期状態に戻しますか？\nはい　→　Y\nいいえ　→　Y以外の任意のキー");
            if (Console.ReadLine() == "Y") {
                foreach (var wBallSport in wBallSportCollection.BallSports) {
                    AddBallSport(wBallSport, wFilePath);
                }
            }

            // BallSports.xmlファイルを読み込んでwBallsportListsに格納する。
            IEnumerable<BallSport> wReadedBallsports = ReadXFileToBallsports(wFilePath);

            // 1.の回答
            Console.WriteLine("\n問題1の回答（競技名とチームメンバー数の一覧）");
            foreach (var wBallSport in wReadedBallsports) {
                Console.WriteLine($"競技名：{wBallSport.Name}→{wBallSport.Teammembers}人");
            }

            // 2.の回答
            Console.WriteLine("\n問題2の回答（最初にプレイされた年の若い順）");
            foreach (var wBallSport in wReadedBallsports.OrderBy(x => (int)(x.Firstplayed))) {
                Console.WriteLine($"{wBallSport.KanjiName}");
            }

            // 3.の回答
            Console.WriteLine("\n問題3の回答（メンバー人数が最も多い競技名）");
            foreach (var wBallSport in wReadedBallsports) {
                if (!(wBallSport.Teammembers == wReadedBallsports.Max(x => x.Teammembers))) continue;
                Console.WriteLine(wBallSport.Name);
            }

            // 4.の回答
            Console.WriteLine("\nBallSports.xmlファイルにサッカーのデータを追加しますか？\nはい　→　Y\nいいえ　→　Y以外の任意のキー");
            if (Console.ReadLine() == "Y") {
                BallSport wSoccer = new BallSport("フットボール", "蹴球", 11, 1863);
                AddBallSport(wSoccer, wFilePath);
            }
        }
    }
}
