using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_1 {
    /// <summary>
    /// EmployeeCollectionクラス
    /// </summary>
    [DataContract(Name = "employeecollection"), XmlRoot("employees")]
    public class EmployeeCollection {

        /// <summary>
        /// Employeesプロパティ
        /// </summary>
        [DataMember(Name = "employee")]
        [XmlElement(Type = typeof(Employee), ElementName = "employee")]
        public Employee[] Employees { get; set; }

        /// <summary>
        /// コンストラクタ
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
