using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_1 {

    /// <summary>
    /// Employeeクラス
    /// </summary>
    [DataContract(Name = "employee")]
    public class Employee {

        /// <summary>
        /// Idプロパティ
        /// </summary>
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// Nameプロパティ
        /// </summary>
        [DataMember(Name = "name")]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// HireDateプロパティ
        /// </summary>
        [DataMember(Name = "hiredate")]
        [XmlElement(ElementName = "hiredate")]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// コンストラクタ（引数なしでオーバーロード）
        /// プロパティへの代入をコンストラクタで行う場合、シリアル化のために空のコンストラクタが必要
        /// </summary>
        public Employee() { }

        /// <summary>
        /// コンストラクタ（引数2つでオーバーロード）
        /// </summary>
        /// <param name="vId">Id</param>
        /// <param name="vName">Name</param>
        /// <param name="vHireDate">HireDate</param>
        public Employee(int vId, string vName, DateTime vHireDate) {
            this.Id = vId;
            this.Name = vName;
            this.HireDate = vHireDate;
        }
    }
}
