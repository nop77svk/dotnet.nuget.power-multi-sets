namespace NoP77svk.CombiGen.Tests;

internal static class CombiMath
{
    internal static int BinomialCoefficient(this int above, int below)
    {
        int result = 1;

        for (int belowElement = 1; belowElement <= below; belowElement++)
        {
            result = result * above / belowElement;
            above--;
        }

        return result;
    }

    internal static long BinomialCoefficient(this long above, long below)
    {
        long result = 1;

        for (long belowElement = 1; belowElement <= below; belowElement++)
        {
            result = result * above / belowElement;
            above--;
        }

        return result;
    }

    internal static int Factorial(this int value)
    {
        int result = 1;

        for (int i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }

    internal static long Factorial(this long value)
    {
        long result = 1;

        for (long i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
