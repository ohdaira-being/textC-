using System.Configuration;

namespace Question14_3 {
    /// <summary>
    /// configファイルを取得するクラス
    /// </summary>
    public class MyAppSettings : ConfigurationSection {

        /// <summary>
        /// TraceOptionプロパティ
        /// </summary>
        [ConfigurationProperty("traceOption")]
        public TraceOption TraceOption {
            get { return (TraceOption)this["traceOption"]; }
            set { this["traceOption"] = value; }
        }

        /// <summary>
        /// CalendarOptionプロパティ
        /// </summary>
        [ConfigurationProperty("CalendarOption")]
        public CalendarOption CalendarOption {
            get { return (CalendarOption)this["CalendarOption"]; }
            set { this["CalendarOption"] = value; }
        }
    }
}
