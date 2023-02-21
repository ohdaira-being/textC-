using System.Xml.Linq;

namespace Question11_1 {

    /// <summary>
    /// BallSportクラス
    /// </summary>
    public class BallSport {

        /// <summary>
        /// 競技名プロパティ
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 競技名の漢字名称プロパティ
        /// </summary>
        public string KanjiName { get; set; }

        /// <summary>
        /// チーム人数プロパティ
        /// </summary>
        public int MemberCount { get; set; }

        /// <summary>
        /// 最初にプレイした年プロパティ
        /// </summary>
        public int FirstPlayed { get; set; }

        /// <summary>
        /// BallSportのコンストラクタ
        /// </summary>
        /// <param name="vName">競技名</param>
        /// <param name="vKanjiName">競技名の漢字名称</param>
        /// <param name="vMemberCount">チーム人数</param>
        /// <param name="vFirstPlayed">最初にプレイした年</param>
        public BallSport(string vName, string vKanjiName, int vMemberCount, int vFirstPlayed) {
            this.Name = vName;
            this.KanjiName = vKanjiName;
            this.MemberCount = vMemberCount;
            this.FirstPlayed = vFirstPlayed;
        }

        /// <summary>
        /// XElement型にして返すメソッド
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXElement() => new XElement("ballsport",
                new XElement("name", this.Name, new XAttribute("kanji", this.KanjiName)),
                new XElement("teammembers", this.MemberCount),
                new XElement("firstplayed", this.FirstPlayed)
                );
    }
}
