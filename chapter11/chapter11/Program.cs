using System;
using System.Linq;
using System.Xml.Linq;

namespace chapter11 {
    class Program {
        static void Main(string[] args) {
            //問題11.1で使用するXMLファイルを作成する。
            XElement ballSports = new XElement("ballSports",
                new XElement("ballsport",
                    new XElement("name", "バスケットボール", new XAttribute("kanji", "籠玉")),
                    new XElement("teammenbers", "5"),
                    new XElement("firstplayed", "1891")
                ),
                new XElement("ballsport",
                    new XElement("name", "バレーボール", new XAttribute("kanji", "排球")),
                    new XElement("teammenbers", "6"),
                    new XElement("firstplayed", "1895")
                ),
                new XElement("ballsport",
                    new XElement("name", "ベースボール", new XAttribute("kanji", "野球")),
                    new XElement("teammenbers", "9"),
                    new XElement("firstplayed", "1846")
                )
            );
            var xdoc = new XDocument(ballSports);
            xdoc.Save("../../../../BallSports.xml");
        }
    }
}
