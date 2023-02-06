using System.Linq;
using System.Xml.Linq;

namespace Question11_2 {
    //Sample11-2.xmlを次の形式に変換し、別のファイルに保存してください。
    //<? xml version="1.0" encoding="utf-8"?>
    //<difficultkanji>
    //    <word kanji = "鬼灯" yomi="ほおずき" />
    //    <word kanji = "暖簾" yomi="のれん" />
    //    <word kanji = "杜撰" yomi="ずさん" />
    //    <word kanji = "坩堝" yomi="るつぼ" />
    //</difficultkanji>
    class Program {
        static void Main(string[] args) {
            var wXdoc = XDocument.Load("../../../../Sample11-2.xml");
            var wPairs = wXdoc.Root.Elements().Select(x => new {
                Key = x.Element("kanji").Value,
                Value = x.Element("yomi").Value
            });
            var wDict = wPairs.ToDictionary(x => x.Key, x => x.Value);
            var wXNewDoc = new XElement("difficultkanji",
                wDict.Select(x => new XElement("word",
                    new XAttribute("kanji", x.Key),
                    new XAttribute("yomi", x.Value)
                ))
            );
            wXNewDoc.Save("../../../../NewSample11-2.xml");
        }
    }
}
