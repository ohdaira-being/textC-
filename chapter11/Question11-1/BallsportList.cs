using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Question11_1 {
    class BallsportList {

        /// <summary>
        /// 競技名プロパティ
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 競技名の漢字名称プロパティ
        /// </summary>
        public string KanjiName { get; set; }

        /// <summary>
        /// チーム人数プロパティ
        /// </summary>
        public int Teammembers { get; set; }

        /// <summary>
        /// 最初にプレイした年プロパティ
        /// </summary>
        public int Firstplayed { get; set; }

        /// <summary>
        /// 問題11.1で使用するXMLファイルを作成するメソッド
        /// </summary>
        /// <param name="vFilePath">作成先のファイルパス</param>
        public static void CreateBallSports(string vFilePath) {
            var wBallSports = new XElement("ballSports",
                new XElement("ballsport",
                    new XElement("name", "バスケットボール", new XAttribute("kanji", "籠玉")),
                    new XElement("teammembers", "5"),
                    new XElement("firstplayed", "1891")
                ),
                new XElement("ballsport",
                    new XElement("name", "バレーボール", new XAttribute("kanji", "排球")),
                    new XElement("teammembers", "6"),
                    new XElement("firstplayed", "1895")
                ),
                new XElement("ballsport",
                    new XElement("name", "ベースボール", new XAttribute("kanji", "野球")),
                    new XElement("teammembers", "9"),
                    new XElement("firstplayed", "1846")
                )
            );
            var wXdoc = new XDocument(wBallSports);
            wXdoc.Save(vFilePath);
        }

        /// <summary>
        /// vFilePathを読み込み、配列にして返すメソッド
        /// </summary>
        /// <param name="vFilePath">ファイルのパス</param>
        /// <returns>配列化された読み込み内容</returns>
        public static IEnumerable<BallsportList> ReadBallsportLists(string vFilePath) {
            // ファイルが見つからないと例外になってしまう
            XDocument wXdoc = XDocument.Load(vFilePath);
            IEnumerable<BallsportList> wBallSportLists = wXdoc.Root.Elements()
                                            .Select(x => new BallsportList {
                                                Name = (string)x.Element("name"),
                                                KanjiName = (string)x.Element("name").Attribute("kanji"),
                                                Teammembers = (int)x.Element("teammembers"),
                                                Firstplayed = (int)x.Element("firstplayed")
                                            });
            return wBallSportLists.ToArray();
        }

        // BallsportListに書き込む。
        /// <summary>
        /// vFilePathに追加で書き込むメソッド
        /// </summary>
        /// <param name="vBallSportData">追加内容</param>
        /// <param name="vFilePath">書き込み先のファイルパス</param>
        public static void AddBallSport(string[] vBallSportData, string vFilePath) {

            XElement wAddData = new XElement(vBallSportData[0],
                       new XElement("name", vBallSportData[1], new XAttribute("kanji", vBallSportData[2])),
                       new XElement("teammembers", vBallSportData[3]),
                       new XElement("firstplayed", vBallSportData[4])
            );
            XDocument wXdoc = XDocument.Load(vFilePath);

            wXdoc.Root.Add(wAddData);
            wXdoc.Save(vFilePath);
        }
    }
}
