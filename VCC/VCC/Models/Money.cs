using System.Text.Json.Serialization;

namespace VCC.Models
{
    public class Money
    {
        public Money()
        {
        }

        [JsonConstructor]
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override string ToString()
            => (Currency == Currency.UsDollars ? "$" : "£") + Amount;

        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }

    public enum Currency
    {
        UsDollars,
        PoundsSterling
    }
}
