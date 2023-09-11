namespace AspNetCoreWebApi6.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Code { get; set; }
        public int Salary { get; set; }
        public int? SuperVisorId { get; set; }
    }
}
