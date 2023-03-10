using System;
using System.Configuration;

namespace Question14_3 {
    /// <summary>
    /// カレンダーオプションクラス
    /// </summary>
    public class CalendarOption : ConfigurationElement {
        /// <summary>
        /// フォーマットプロパティ
        /// </summary>
        [ConfigurationProperty("StringFormat")]
        public string StringFormat => (string)this["StringFormat"];
        /// <summary>
        /// カレンダーの下限プロパティ
        /// </summary>
        [ConfigurationProperty("Minimum")]
        public DateTime Minimum => (DateTime)this["Minimum"];
        /// <summary>
        /// カレンダーの上限プロパティ
        /// </summary>
        [ConfigurationProperty("Maximum")]
        public DateTime Maximum => (DateTime)this["Maximum"];
        /// <summary>
        /// 月曜日が最初かどうかを判定するプロパティ
        /// </summary>
        [ConfigurationProperty("MondayIsFirstDay")]
        public bool MondayIsFirstDay => (bool)this["MondayIsFirstDay"];
    }
}
