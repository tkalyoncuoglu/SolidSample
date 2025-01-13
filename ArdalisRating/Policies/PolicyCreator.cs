using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OneOf.Types;
using OneOf;
using ArdalisRating.Logger;

namespace ArdalisRating.Policies
{
    internal class PolicyCreator
    {
        public static OneOf<IPolicy, None> Create(ILogger logger)
        {
            // load policy - open file policy.json
            string policyJson = File.ReadAllText("policy.json");

            var policy = JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());

            switch (policy.Type)
            {
                case PolicyType.Auto: return new Auto(logger, policy.Make, policy.Deductible);
                case PolicyType.Land: return new Land(logger, policy.BondAmount, policy.Valuation);
                case PolicyType.Life: return new Life(logger, policy.DateOfBirth, policy.Amount, policy.IsSmoker);
                default: return new None();
            }
        }
    }
}
