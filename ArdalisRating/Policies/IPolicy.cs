using OneOf;
using OneOf.Types;

namespace ArdalisRating.Policies
{
    internal interface IPolicy
    {
        OneOf<decimal, None> GetRating();
    }
}