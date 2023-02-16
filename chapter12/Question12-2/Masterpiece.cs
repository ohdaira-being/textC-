using System.Xml.Serialization;

namespace Question12_2 {

    /// <summary>
    /// Masterpiecesクラス
    /// </summary>
    [XmlRoot("masterpiece")]
    public class Masterpiece {

        /// <summary>
        /// Titleプロパティ
        /// </summary>
        [XmlElement(ElementName ="title")]
        public string Title { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// </summary>
        public Masterpiece() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vTitle">タイトル名</param>
        public Masterpiece(string vTitle) {
            this.Title = vTitle;
        }
    }
}
