using SQLite;

namespace TestMaui.Models
{
    public class EmpModel
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; } 
        public bool IsPermanent { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }
}