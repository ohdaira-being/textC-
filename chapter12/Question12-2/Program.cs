using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;
using System.Linq;

namespace Question12_2 {

    // 1. XmlSerializerクラスを使って、テキストのXMLファイルを逆シリアル化し、Novelistオブジェクトを作成してください。
    // Novelistクラスには、必要ならば適切な属性を付加してください。

    // 2. 上記のNovelistオブジェクトの内容を以下のようなJSONファイルにシリアル化するコードを書いてください。

    public class Program {
        static void Main(string[] args) {

            // Masterpiecesクラスのインスタンス生成
            Masterpiece[] wMasterpieces = new Masterpiece[]{
                new Masterpiece("2001年宇宙の旅"),
                new Masterpiece("幼少期の終り")
            };

            // Novelistクラスのインスタンス生成
            Novelist[] wNovelists = new Novelist[]{
                new Novelist("アーサー・C・クラーク",new DateTime(1917,12,16),wMasterpieces)
            };

            // NovelistCollectionクラスのインスタンス生成
            var wNovelistCollection = new NovelistCollection(wNovelists);

            // 改行、インデントを設定する
            var wXmlSettings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };

            // 問題2-1 XMLファイルのファイルパス
            string wXmlFilePath = @"../../../../Novelist.xml";

            // 問題2-1 XML形式でシリアル化するコード（テキストのファイルを生成）
            using (var wWriter = XmlWriter.Create(wXmlFilePath, wXmlSettings)) {
                var wSerializer = new XmlSerializer(wNovelistCollection.GetType());
                wSerializer.Serialize(wWriter, wNovelistCollection);
            }

            // 問題2-1 XMLファイルを逆シリアル化し、Novelistオブジェクトを作成するコード
            // Novelistオブジェクトを格納する変数を宣言
            NovelistCollection wDeserializedXml = new NovelistCollection();
            // 逆シリアル化し、変数にNovelistオブジェクトを格納する
            using (var wReader = XmlReader.Create(wXmlFilePath)) {
                var wSerializer = new XmlSerializer(typeof(NovelistCollection));
                wDeserializedXml = wSerializer.Deserialize(wReader) as NovelistCollection;
            }

            // 問題2-2 XMLファイルのファイルパス
            string wJsonFilePath = @"../../../../Novelist.json";

            // 問題2-2 形式を揃えるための条件
            var wJsonSettings = new DataContractJsonSerializerSettings {
                UseSimpleDictionaryFormat = true,
                DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ")
            };

            // 問題2-2 JSON形式でシリアル化するコード
            using (var wStream = new FileStream(wJsonFilePath, FileMode.Create, FileAccess.Write)) {
                var wSerializer = new DataContractJsonSerializer(wDeserializedXml.GetType(), wJsonSettings);
                wSerializer.WriteObject(wStream, wDeserializedXml);
            }
        }
    }
}
