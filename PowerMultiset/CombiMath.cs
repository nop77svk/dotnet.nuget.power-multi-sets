namespace NoP77svk.PowerMultiset;

public static class CombiMath
{
    public static int BinomialCoefficient(this int above, int below)
    {
        int result = 1;

        for (int belowElement = 1; belowElement <= below; belowElement++)
        {
            result = result * above / belowElement;
            above--;
        }

        return result;
    }

    public static long BinomialCoefficient(this long above, long below)
    {
        long result = 1;

        for (long belowElement = 1; belowElement <= below; belowElement++)
        {
            result = result * above / belowElement;
            above--;
        }

        return result;
    }

    public static int Factorial(this int value)
    {
        int result = 1;

        for (int i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }

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
