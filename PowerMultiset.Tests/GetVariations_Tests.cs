namespace NoP77svk.PowerMultisets.Tests;

using System.Collections.Generic;

using NoP77svk.PowerMultisets;

[TestFixture]
[TestOf(typeof(PowerMultiSetGenerator))]
public class GetVariations_Tests
{
    private readonly char[] _testElements = ['a', 'b', 'c', 'd', 'e'];

    [Test]
    public void GetVariations_ZeroTuple_Returns_EmptySet()
    {
        // Arrange
        int expectedResultsCount = 1;
        IList<IList<KeyValuePair<int, char>>> expectedResult = [[]];

        // Act
        var actualResult = PowerMultiSetGenerator.Vary(_testElements, 0)
            .Select(x => x.OrderBy(kvp => kvp.Key).ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetVariations_SingleElementTuple_Returns_SingleElementCollectionsOfAllElements()
    {
        // Arrange
        int expectedResultsCount = _testElements.Length;

        IList<IList<KeyValuePair<int, char>>> expectedResult = new List<IList<KeyValuePair<int, char>>>();
        for (int i = 0; i < _testElements.Length; i++)
        {
            KeyValuePair<int, char>[] expectedVariaton = [new(i, _testElements[i])];
            expectedResult.Add(expectedVariaton);
        }

        // Act
        var actualResult = PowerMultiSetGenerator.Vary(_testElements, 1)
            .Select(x => x.ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetVariations_DoubleElementTuple_Returns_ProperDoublesOfElements()
    {
        // Arrange
        int expectedResultsCount = _testElements.Length * (_testElements.Length - 1);

        IList<IList<KeyValuePair<int, char>>> expectedResult = new List<IList<KeyValuePair<int, char>>>();
        for (int i = 0; i < _testElements.Length; i++)
        {
            for (int j = 0; j < _testElements.Length; j++)
            {
                if (j == i)
                {
                    continue;
                }

                KeyValuePair<int, char>[] expectedVariaton = [new(i, _testElements[i]), new(j, _testElements[j])];
                expectedResult.Add(expectedVariaton);
            }
        }

        // Act
        var actualResult = PowerMultiSetGenerator.Vary(_testElements, 2)
            .Select(x => x.ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetVariations_FullLengthTuple_Returns_ProperAllElementsTuples()
    {
        // Arrange
        int expectedResultsCount = _testElements.Length.Factorial();

        IList<IList<KeyValuePair<int, char>>> expectedResult = new List<IList<KeyValuePair<int, char>>>();
        for (int a = 0; a < _testElements.Length; a++)
        {
            for (int b = 0; b < _testElements.Length; b++)
            {
                if (b == a)
                {
                    continue;
                }

                for (int c = 0; c < _testElements.Length; c++)
                {
                    if (c == a || c == b)
                    {
                        continue;
                    }

                    for (int d = 0; d < _testElements.Length; d++)
                    {
                        if (d == a || d == b || d == c)
                        {
                            continue;
                        }

                        for (int e = 0; e < _testElements.Length; e++)
                        {
                            if (e == a || e == b || e == c || e == d)
                            {
                                continue;
                            }

                            KeyValuePair<int, char>[] expectedVariaton = [
                                new(a, _testElements[a]),
                                new(b, _testElements[b]),
                                new(c, _testElements[c]),
                                new(d, _testElements[d]),
                                new(e, _testElements[e])
                            ];

                            expectedResult.Add(expectedVariaton);
                        }
                    }
                }
            }
        }

        // Act
        var actualResult = PowerMultiSetGenerator.Vary(_testElements, _testElements.Length)
            .Select(x => x.ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetVariations_FullLengthTuple_Returns_ActualPermutations()
    {
        // Arrange
        int expectedResultsCount = Factorial(_testElements.Length);
        IList<IList<KeyValuePair<int, char>>> expectedResult = PowerMultiSetGenerator.Permute(_testElements)
            .Select(x => x.ToArray())
            .ToArray();

        // Act
        var actualResult = PowerMultiSetGenerator.Vary(_testElements, _testElements.Length)
            .Select(x => x.ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    private static int Factorial(int value)
    {
        int result = 1;

        for (int i = 2; i <= value; i++)
        {
            result *= i;
        }

        return result;
    }
}
