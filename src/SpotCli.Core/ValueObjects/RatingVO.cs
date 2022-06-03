using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpotCli.Core.ValueObjects;
public class RatingVO
{
    private const int MIN_RATING = 1;
    private const int MAX_RATING = 5;
    public RatingVO(int value)
    {
        if (!IsValidRating(value))
        {
            throw new Exception($"Invalid rating. Value must be between {MIN_RATING} and {MAX_RATING}."); // todo more specific exception object
        }
        Value = value;
    }

    public int Value { get; init; }

    private bool IsValidRating(int rating)
    {
        if(rating < MIN_RATING || rating > MAX_RATING)
        {
            return false;
        }
        return true;
    }
}
