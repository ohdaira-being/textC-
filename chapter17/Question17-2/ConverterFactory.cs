using System.Linq;

namespace Question17_2 {

    /// <summary>
    /// 距離変換に必要なインスタンスを生成クラス
    /// </summary>
    static class ConverterFactory {
        private static ConverterBase[] FConverters = new ConverterBase[] {
            new MeterConverter(),
            new FeetConverter(),
            new YardConverter(),
            new InchConverter(),
            new KiloMeterConverter(),
            new MileConverter(),
        };

        /// <summary>
        /// どの単位か判別して、そのインスタンスを生成する
        /// 登録している単位ではない場合、nullを返す
        /// </summary>
        /// <param name="vName">単位名</param>
        /// <returns>生成したインスタンス</returns>
        public static ConverterBase GetInstance(string vName) => FConverters.FirstOrDefault(x => x.IsMyUnit(vName));
    }
}
