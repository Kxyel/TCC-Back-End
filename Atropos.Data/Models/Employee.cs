namespace Atropos.Data.Models
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Genre { get; set; }
        public long Salary { get; set; }
        public string Department { get; set; }
        public long Phone { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ChangeDate { get; set; }
        public bool IsActive { get; set; }
    }
}
