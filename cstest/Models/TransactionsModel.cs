namespace cstest.Models;
 public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public int SourceAccountId { get; set; }  // This is for the "primary" account involved in the transaction
        public int? DestinationAccountId { get; set; }  // This is for the "secondary" account involved in the transaction

        public required string Type { get; set; }
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        public Account SourceAccount { get; set; } = null!;
        public Account DestinationAccount { get; set; } = null!;
    }