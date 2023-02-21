using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_1 {
    /// <summary>
    /// 従業員のコレクションクラス
    /// </summary>
    [DataContract(Name = "employeecollection"), XmlRoot("employees")]
    public class EmployeeCollection {

        /// <summary>
        /// 従業員集プロパティ
        /// </summary>
        [DataMember(Name = "employee")]
        [XmlElement(Type = typeof(Employee), ElementName = "employee")]
        public Employee[] Employees { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// プロパティへの代入をコンストラクタで行う場合、シリアル化のために空のコンストラクタが必要
        /// </summary>
        public EmployeeCollection() { }

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="vEmployees">vEmployeesコレクション</param>
        public EmployeeCollection(Employee[] vEmployees) {
            this.Employees = vEmployees;
        }
    }
}
