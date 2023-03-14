using System.Configuration;

namespace Question14_3 {
    /// <summary>
    /// 追跡オプションクラス
    /// </summary>
    public class TraceOption : ConfigurationElement {
        /// <summary>
        /// 追跡可否プロパティ
        /// </summary>
        [ConfigurationProperty("enabled")]
        public bool Enabled {
            get { return (bool)this["enabled"]; }
        }
        /// <summary>
        /// ファイルパスプロパティ
        /// </summary>
        [ConfigurationProperty("filePath")]
        public string FilePath {
            get { return (string)this["filePath"]; }
        }
        /// <summary>
        /// バッファサイズプロパティ
        /// </summary>
        [ConfigurationProperty("bufferSize")]
        public int BufferSize {
            get { return (int)this["bufferSize"]; }
        }
    }
}
