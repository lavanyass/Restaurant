namespace LashaRestaurant.Models.Employee.Get
{
    public partial class EmployeeBankAccount
    {
        public int EmployeeBankAccountId { get; set; }
        public int EmployeeId { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
        public string RoutingNumber { get; set; }
    }
}
