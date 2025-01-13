using ArdalisRating.Logger;
using ArdalisRating.Policies;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OneOf;
using OneOf.Types;
using System;
using System.IO;

namespace ArdalisRating
{
    /// <summary>
    /// The RatingEngine reads the policy application details from a file and produces a numeric 
    /// rating value based on the details.
    /// </summary>
    public class RatingEngine(ILogger logger)
    {
        public ILogger Logger { get; init; } = logger;
        public decimal Rating { get; set; }
        public void Rate()
        {
            Logger.Log("Starting rate.");

            Logger.Log("Loading policy.");

            var policy = PolicyCreator.Create(logger);

            var rating = policy.Match(p => p.GetRating(), n => n );

            rating.Switch(n => Rating = n, _ =>
            {
                Logger.Log("Unknown policy type");

            });
            Logger.Log("Rating completed.");
        }
    }
}
