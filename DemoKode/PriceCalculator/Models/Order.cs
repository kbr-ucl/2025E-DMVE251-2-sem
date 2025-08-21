using System.Collections.Generic;
namespace PriceCalculator.Models;

public class Order
{
    public Customer Customer { get; set; }
    public List<CartItem> Items { get; set; } = new();
}