using System;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace Question12_1 {

    /// <summary>
    /// 従業員クラス
    /// </summary>
    [DataContract(Name = "employee")]
    public class Employee {

        /// <summary>
        /// 従業員のIdプロパティ
        /// </summary>
        [XmlElement(ElementName = "id")]
        public int Id { get; set; }

        /// <summary>
        /// 従業員の名前プロパティ
        /// </summary>
        [DataMember(Name = "name")]
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// 従業員の採用日プロパティ
        /// </summary>
        [DataMember(Name = "hiredate")]
        [XmlElement(ElementName = "hiredate")]
        public DateTime HireDate { get; set; }

        /// <summary>
        /// 空のコンストラクタ
        /// プロパティへの代入をコンストラクタで行う場合、シリアル化のために空のコンストラクタが必要
        /// </summary>
        public Employee() { }

        /// <summary>
        /// コンストラクタ
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
