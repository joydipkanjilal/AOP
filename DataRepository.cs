namespace Autofac.Challenge.MethodExecutionDuration.Demo
{
    public class Employee
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
    }
    public class DataRepository: IDataRepository
    {
        private readonly List<Employee> employees = new List<Employee>{
                new Employee
                {
                    Id = 1, FirstName = "Alex", LastName = "Smith", Address = "Boston", Salary = 6500
                },
                new Employee
                {
                    Id = 2, FirstName = "Adrianna", LastName = "Keneley", Address = "London", Salary = 7500
                },
                new Employee
                {
                    Id = 3, FirstName = "Jose", LastName = "Campbell", Address = "New York", Salary = 5500
                },
                new Employee
                {
                    Id = 4, FirstName = "Robert", LastName = "Adams", Address = "San Francisco", Salary = 8000
                },
                new Employee
                {
                    Id = 5, FirstName = "David", LastName = "Hurst", Address = "Birmingham", Salary = 5500
                }
            };
        public List<Employee> GetEmployees() 
        { 
            return employees; 
        }
    }
}
