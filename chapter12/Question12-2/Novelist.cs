using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_2 {

    /// <summary>
    /// 小説家クラス
    /// </summary>
    [XmlRoot("novelist")]
    [DataContract(Name = "novelist")]
    public class Novelist {

        /// <summary>
        /// 小説家の名前プロパティ
        /// </summary>
        [DataMember(Name = "name")]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 小説家の誕生日プロパティ
        /// </summary>
        [DataMember(Name = "birth")]
        [XmlElement(ElementName = "birth")]
        public DateTime Birth { get; set; }

        /// <summary>
        /// 小説家の名作集プロパティ
        /// </summary>
        [DataMember(Name = "masterpieces")]
        [XmlArray("masterpieces")]
        [XmlArrayItem("masterpiece", typeof(Masterpiece))]
        public Masterpiece[] Masterpieces { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// </summary>
        public Novelist() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vName">名前</param>
        /// <param name="vBirth">誕生日</param>
        /// <param name="vMasterpieces">代表作</param>
        public Novelist(string vName, DateTime vBirth, Masterpiece[] vMasterpieces) {
            this.Name = vName;
            this.Birth = vBirth;
            this.Masterpieces = vMasterpieces;
        }
    }
}
