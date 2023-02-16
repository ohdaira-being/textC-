using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Xml;
using System.Xml.Serialization;

namespace Question12_1 {

    // 1. Employeeクラスが定義されています。
    // このオブジェクトをXMLにシリアル化するコードと逆シリアル化するコードを、XmlSerializerクラスを使って書いてください。
    // この時、XMLの要素名（タグ名）は全て小文字にしてください。

    // 2. 複数のEmployeeオブジェクトが配列に格納されているとします。
    // この配列をDataContractSerializerクラスを使って、XMLファイルにシリアル化してください。

    // 3. 2.で作成したファイルを読み込み、逆シリアル化してください。

    // 4. 複数のEmployeeオブジェクトが配列に格納されているとします。
    // この配列をDataContractJsonSerializerを使って、JSONファイルに出力してください。
    // この時、シリアル化対象にIdは含めないでください。

    public class Program {
        static void Main(string[] args) {

            // Employeeクラスのインスタンス生成
            var wEmployee = new Employee[] {
                new Employee(00917, "大平", new DateTime(2022, 4, 1)),
                new Employee(00999, "高松", new DateTime(2022,4,1))
            };

            // EmployeeCollectionクラスのインスタンス生成
            var wEmployeeCollection = new EmployeeCollection(wEmployee);

            // 改行、インデントを設定する
            var wXmlSettings = new XmlWriterSettings {
                Encoding = new System.Text.UTF8Encoding(false),
                Indent = true,
                IndentChars = " ",
            };

            // 問題1-1 保存先のファイルパス
            string wFilePath1 = @"../../../../Employee1.xml";

            // 問題12-1 シリアル化するコード
            using (var wWriter = XmlWriter.Create(wFilePath1, wXmlSettings)) {
                var wSerializer = new XmlSerializer(wEmployeeCollection.GetType());
                wSerializer.Serialize(wWriter, wEmployeeCollection);
            }

            // 問題1-1 逆シリアル化するコード
            using (var wReader = XmlReader.Create(wFilePath1)) {
                var wSerializer = new XmlSerializer(typeof(EmployeeCollection));
                foreach (Employee wLoadedEmployee in (wSerializer.Deserialize(wReader) as EmployeeCollection).Employees) {
                    Console.WriteLine(
                        $"[Id={wLoadedEmployee.Id},Name={wLoadedEmployee.Name},HireDate={wLoadedEmployee.HireDate.ToString("D")}]"
                        );
                }
            }

            // 問題1-2 保存先のファイルパス
            string wFilePath2 = @"../../../../Employee2.xml";

            // 問題1-2 シリアル化するコード
            using (var wWriter = XmlWriter.Create(wFilePath2, wXmlSettings)) {
                var wSerializer = new DataContractSerializer(wEmployeeCollection.GetType());
                wSerializer.WriteObject(wWriter, wEmployeeCollection);
            }

            // 問題1-3 逆シリアル化するコード
            using (var wReader = XmlReader.Create(wFilePath2)) {
                var wSerializer = new DataContractSerializer(typeof(EmployeeCollection));
                foreach (Employee wLoadedEmployee in (wSerializer.ReadObject(wReader) as EmployeeCollection).Employees) {
                    Console.WriteLine(
                        $"[Id：{wLoadedEmployee.Id},Name：{wLoadedEmployee.Name},HireDate：{wLoadedEmployee.HireDate.ToString("D")}]"
                        );
                }
            }

            // 問題1-4 保存先のファイルパス
            string wFilePath3 = @"../../../../Employee3.json";

            // 問題1-4 JSON形式でシリアル化するコード
            using (var wStream = new FileStream(wFilePath3, FileMode.Create, FileAccess.Write)) {
                var wSerializer = new DataContractJsonSerializer(wEmployeeCollection.GetType());
                wSerializer.WriteObject(wStream, wEmployeeCollection);
            }
        }
    }
}
