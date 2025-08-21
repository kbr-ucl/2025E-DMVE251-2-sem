using PriceCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PriceCalculator.Strategies.Implementations;

namespace PriceCalculator.Strategies
{
    public class DiscountStrategyFactory
    {
        private readonly Dictionary<CustomerType, IDiscountStrategy> _strategies;

        public DiscountStrategyFactory()
        {
            _strategies = new Dictionary<CustomerType, IDiscountStrategy>
            {
                { CustomerType.PublicOrNonProfit, new PublicOrNonProfitDiscount() },
                { CustomerType.Private, new PrivateCustomerDiscount() },
                { CustomerType.Business, new BusinessCustomerDiscount() }
            };
        }

        public IDiscountStrategy GetStrategy(CustomerType customerType)
        {
            return _strategies.TryGetValue(customerType, out var strategy) ? strategy : null;
        }
    }
}
