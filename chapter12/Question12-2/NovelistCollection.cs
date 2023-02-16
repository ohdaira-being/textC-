using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_2 {

    /// <summary>
    /// NovelistCollectionクラス
    /// </summary>
    [DataContract(Name = "novelistcollection")]
    [XmlRoot("novelists")]
    public class NovelistCollection {

        /// <summary>
        /// Novelistsプロパティ
        /// </summary>
        [XmlElement(Type = typeof(Novelist), ElementName = "novelist")]
        [DataMember(Name = "novelist")]
        //[XmlArray("novelistCollection")]
        //[XmlArrayItem("novelists", typeof(Novelist))]
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
