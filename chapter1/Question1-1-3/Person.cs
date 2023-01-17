using System;

namespace Question1_1_3 {
    //「1.6:継承」で示したPersonクラス
    public class Person {
        public string Name { get; set; }
        public DateTime Birthday { get; set; }
        public int GetAge() {
            DateTime wToday = DateTime.Today;
            int wAge = wToday.Year - Birthday.Year;
            if (wToday < Birthday.AddYears(wAge)) {
                wAge--;
            }
            return wAge;
        }
    }
}
