using System;
using System.Linq;
using System.Xml.Linq;

namespace Question11_1 {

    //chapter11で作成したXMLファイルに対して、1～4のコードを書いてください。
    //1.XMLファイルを読み込み、競技名とチームメンバー数の一覧を表示してください。
    //2.最初にプレイされた年の若い順に漢字の競技名を表示してください。
    //3.メンバー人数が最も多い競技名を表示してください。
    //4.サッカーの情報を追加して、新たなXMLファイルに出力してください。ファイル名は特に問いません。

    class Program {
        static void Main(string[] args) {
            XDocument wXdoc = XDocument.Load("../../../../BallSports.xml");//ファイルが見つからないと例外になってしまう

            //1.の回答
            foreach (XElement wXlist in wXdoc.Root.Elements()) {
                Console.WriteLine($"競技名：{wXlist.Element("name").Value}→{wXlist.Element("teammenbers").Value}人");
            }

            //2.の回答
            foreach (XElement wXListOrderByFirstplayed in wXdoc.Root.Elements().OrderBy(x => (int)(x.Element("firstplayed")))) {
                Console.WriteLine($"{wXListOrderByFirstplayed.Element("name").Attribute("kanji").Value}");
            }

            //3.の回答
            foreach (XElement wXMaxMenberSport in wXdoc.Root.Elements().OrderByDescending(x => (int)(x.Element("teammenbers"))).Take(1)) {
                Console.WriteLine(wXMaxMenberSport.Element("name").Value);
            }

            //4.の回答
            XElement wSoccerElement = new XElement("ballsport",
                       new XElement("name", "フットボール", new XAttribute("kanji", "蹴球")),
                       new XElement("teammenbers", "11"),
                       new XElement("firstplayed", "1863")
            );
            wXdoc.Root.Add(wSoccerElement);
            wXdoc.Save("../../../../BallSports.xml");
        }
    }
}
