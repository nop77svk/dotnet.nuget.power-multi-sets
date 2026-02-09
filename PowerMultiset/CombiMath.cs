namespace NoP77svk.PowerMultiset;

public static class CombiMath
{
    /// <summary>
    /// Calculate binomial coefficient (N over M)
    /// </summary>
    /// <param name="above">The "N" (above) part</param>
    /// <param name="below">The "M" (below) part</param>
    /// <returns>The binomial coefficient of N over M</returns>
    public static int Over(this int above, int below)
    {
        int result = 1;

        for (int belowElement = 1; belowElement <= below; belowElement++)
        {
            result = result * above / belowElement;
            above--;
        }

        return result;
    }

    /// <summary>
    /// Calculate binomial coefficient (N over M)
    /// </summary>
    /// <param name="above">The "N" (above) part</param>
    /// <param name="below">The "M" (below) part</param>
    /// <returns>The binomial coefficient of N over M</returns>
    public static long Over(this long above, long below)
    {
        long result = 1;

        for (long belowElement = 1; belowElement <= below; belowElement++)
        {
            result = result * above / belowElement;
            above--;
        }

        return result;
    }

    /// <summary>
    /// Calculate factorial of value
    /// </summary>
    /// <param name="value">The input value to be calculated upon</param>
    /// <returns>The factorial of the input value</returns>
    public static int Factorial(this int value)
    {
        int result = 1;

        for (int i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }

    /// <summary>
    /// Calculate factorial of value
    /// </summary>
    /// <param name="value">The input value to be calculated upon</param>
    /// <returns>The factorial of the input value</returns>
    public static long Factorial(this long value)
    {
        long result = 1;

        for (long i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
