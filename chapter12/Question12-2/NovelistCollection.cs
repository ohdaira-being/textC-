using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_2 {

    /// <summary>
    /// 小説家集クラス
    /// </summary>
    [DataContract(Name = "novelistcollection")]
    [XmlRoot("novelists")]
    public class NovelistCollection {

        /// <summary>
        /// 小説家集プロパティ
        /// </summary>
        [XmlElement(Type = typeof(Novelist), ElementName = "novelist")]
        [DataMember(Name = "novelist")]
        public Novelist[] Novelists { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// </summary>
        public NovelistCollection() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vNovelist">Novelistコレクション</param>
        public NovelistCollection(Novelist[] vNovelist) {
            this.Novelists = vNovelist;
        }
    }
}
