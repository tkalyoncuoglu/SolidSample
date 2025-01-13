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
    internal class Life(ILogger logger, DateTime dateOfBirth, decimal amount, bool isSmoker) : IPolicy
    {
        public DateTime DateOfBirth { get; init; } = dateOfBirth;

        public decimal Amount { get; init; } = amount;

        public bool IsSmoker { get; init; } = isSmoker;

        public ILogger Logger { get; init; } = logger;
        public OneOf<decimal, None> GetRating()
        {
            Logger.Log("Rating LIFE policy...");
            Logger.Log("Validating policy.");
            if (DateOfBirth == DateTime.MinValue)
            {
                Logger.Log("Life policy must include Date of Birth.");
                return new None();
            }
            if (DateOfBirth < DateTime.Today.AddYears(-100))
            {
                Logger.Log("Centenarians are not eligible for coverage.");
                return new None();
            }
            if (Amount == 0)
            {
                Logger.Log("Life policy must include an Amount.");
                return new None();
            }
            int age = DateTime.Today.Year - DateOfBirth.Year;
            if (DateOfBirth.Month == DateTime.Today.Month &&
                DateTime.Today.Day < DateOfBirth.Day ||
                DateTime.Today.Month < DateOfBirth.Month)
            {
                age--;
            }
            decimal baseRate = Amount * age / 200;
            if (IsSmoker)
            {
                return baseRate * 2;
            }
            return baseRate;
            

        }
    }
}
