using ArdalisRating.Logger;
using OneOf;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Policies
{
    internal class Land(ILogger logger, decimal bondAmount, decimal valuation) : IPolicy
    {
        public decimal BondAmount { get; init; } = bondAmount;

        public decimal Valuation { get; init; } = valuation;

        public ILogger Logger { get; init; } = logger;
        public OneOf<decimal, None> GetRating()
        {
            Logger.Log("Rating LAND policy...");
            Logger.Log("Validating policy.");
            if (BondAmount == 0 || Valuation == 0)
            {
                Console.WriteLine("Land policy must specify Bond Amount and Valuation.");
                return new None();
            }
            if (BondAmount < 0.8m * Valuation)
            {
                Console.WriteLine("Insufficient bond amount.");
                return new None();
            }
            return BondAmount * 0.05m;
           
        }
    }
}
