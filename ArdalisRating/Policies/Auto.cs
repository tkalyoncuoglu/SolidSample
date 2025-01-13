using ArdalisRating.Logger;
using OneOf;
using OneOf.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ArdalisRating.Policies
{
    internal class Auto(ILogger logger, string make, decimal deductible) : IPolicy
    {
        public string Make { get; init; } = make;

        public decimal Deductible { get; init; } = deductible;

        private ILogger Logger { get; init; } = logger;



        public OneOf<decimal, None> GetRating()
        {

            Logger.Log("Rating AUTO policy...");
            Logger.Log("Validating policy.");
            if (String.IsNullOrEmpty(Make))
            {
                Console.WriteLine("Auto policy must specify Make");
                return new None();
            }
            if (Make == "BMW")
            {
                if (Deductible < 500)
                {
                    return 1000m;
                }

            }
            return 900m;
        }
    }
}
