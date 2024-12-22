namespace cstest.Models
{
public class DepositRequest
{
    public int AccountId { get; set; }
    public decimal Amount { get; set; }
    public int ToAccountId  { get; set; }
}
}