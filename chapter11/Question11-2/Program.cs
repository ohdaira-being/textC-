using System.Collections.Generic;
using System.IO;
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

            // ファイルから読み込んだタグ名とタグ要素をペアとして、ディクショナリwDictに格納する
            Dictionary<string, string> wDict = wXdoc.Root.Elements().Select(x => new {
                Key = x.Element("kanji").Value,
                Value = x.Element("yomi").Value
            }).ToDictionary(x => x.Key, x => x.Value);

            // ディクショナリwDictのキーと値から作成したXMLデータをwXNewDocに格納する
            XElement wXNewDoc = new XElement("difficultkanji",
                wDict.Select(x => new XElement("word",
                    new XAttribute("kanji", x.Key),
                    new XAttribute("yomi", x.Value)
                ))
            );

            // 保存
            wXNewDoc.Save("../../../../NewSample11-2.xml");


            // 追加
            string vFilePath = "../../../../NewSample11-3.xml";

            XDocument wXnewdoca = XDocument.Load(vFilePath);
            foreach (var item in wDict) {
                var wWord = new XElement("word");
                wWord.SetAttributeValue("kanji", item.Key);
                wWord.SetAttributeValue("yomi", item.Value);

                wXnewdoca.Root.Add(new XElement("difficultkanji", wWord));
                wXnewdoca.Save(vFilePath);
            }

            //var wWord = new XElement("word");
            //string ddd = "../../../../NewSample11-3.xml";

            //wWord.SetAttributeValue("kanji", "鬼灯");
            //wWord.SetAttributeValue("yomi", "ほおずき");
            //XDocument.Load(ddd).Root.Add("difficultkanji", wWord);
            //XDocument.Load(ddd).Save(ddd);

            //wWord.SetAttributeValue("kanji", "暖簾");
            //wWord.SetAttributeValue("yomi", "のれん");
            //new XElement("difficultkanji", wWord).Save("../../../../NewSample11-3.xml");

            //wWord.SetAttributeValue("kanji", "杜撰");
            //wWord.SetAttributeValue("yomi", "ずさん");
            //new XElement("difficultkanji", wWord).Save("../../../../NewSample11-3.xml");

            //wWord.SetAttributeValue("kanji", "坩堝");
            //wWord.SetAttributeValue("yomi", "るつぼ");
            //new XElement("difficultkanji", wWord).Save("../../../../NewSample11-3.xml");
        }
    }
}
