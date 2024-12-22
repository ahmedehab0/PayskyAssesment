namespace cstest.Models
{
    public class Account
    {
        public int Id { get; set; }
        public required string AccountNumber { get; set; }
        public decimal Balance { get; set; }
        public required string AccountType { get; set; }


        // Collection of transactions where this account is the source account
        public ICollection<Transaction> SourceTransactions { get; set; } = new List<Transaction>();

        // Collection of transactions where this account is the destination account
        public ICollection<Transaction> DestinationTransactions { get; set; } = new List<Transaction>();
    }
}
