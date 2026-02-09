namespace NoP77svk.PowerMultiset.Tests;

using System.Collections.Generic;

using NoP77svk.PowerMultiset;

[TestFixture]
[TestOf(typeof(PowerSetGenerator))]
public class GetCombinations_Tests
{
    private readonly char[] _testElements = ['a', 'b', 'c', 'd', 'e'];

    [Test]
    public void GetCombinations_SingleElementTuple_Returns_SingleElementCollectionsOfAllElements()
    {
        // Arrange
        int expectedResultsCount = _testElements.Length.BinomialCoefficient(1);

        IList<IList<KeyValuePair<int, char>>> expectedResult = new List<IList<KeyValuePair<int, char>>>();
        for (int i = 0; i < _testElements.Length; i++)
        {
            KeyValuePair<int, char>[] expectedVariaton = [new(i, _testElements[i])];
            expectedResult.Add(expectedVariaton);
        }

        // Act
        var actualResult = PowerSetGenerator.Combine(_testElements, 1)
            .Select(x => x.OrderBy(kvp => kvp.Key).ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetCombinations_DoubleElementTuple_Returns_ProperDoublesOfElements()
    {
        // Arrange
        int expectedResultsCount = _testElements.Length.BinomialCoefficient(2);

        IList<IList<KeyValuePair<int, char>>> expectedResult = new List<IList<KeyValuePair<int, char>>>();
        for (int i = 0; i < _testElements.Length - 1; i++)
        {
            for (int j = i + 1; j < _testElements.Length; j++)
            {
                KeyValuePair<int, char>[] expectedCombination = [new(i, _testElements[i]), new(j, _testElements[j])];
                expectedResult.Add(expectedCombination);
            }
        }

        // Act
        var actualResult = PowerSetGenerator.Combine(_testElements, 2)
            .Select(x => x.OrderBy(kvp => kvp.Key).ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetCombinations_FullLengthTuple_Returns_ProperAllElementsTuples()
    {
        // Arrange
        int expectedResultsCount = 1;

        IList<IList<KeyValuePair<int, char>>> expectedResult = new List<IList<KeyValuePair<int, char>>>();
        for (int a = 0; a < _testElements.Length; a++)
        {
            for (int b = a + 1; b < _testElements.Length; b++)
            {
                if (b == a)
                {
                    continue;
                }

                for (int c = b + 1; c < _testElements.Length; c++)
                {
                    if (c == a || c == b)
                    {
                        continue;
                    }

                    for (int d = c + 1; d < _testElements.Length; d++)
                    {
                        if (d == a || d == b || d == c)
                        {
                            continue;
                        }

                        for (int e = d + 1; e < _testElements.Length; e++)
                        {
                            if (e == a || e == b || e == c || e == d)
                            {
                                continue;
                            }

                            KeyValuePair<int, char>[] expectedCombination = [
                                new(a, _testElements[a]),
                                new(b, _testElements[b]),
                                new(c, _testElements[c]),
                                new(d, _testElements[d]),
                                new(e, _testElements[e])
                            ];

                            expectedResult.Add(expectedCombination);
                        }
                    }
                }
            }
        }

        // Act
        var actualResult = PowerSetGenerator.Combine(_testElements, _testElements.Length)
            .Select(x => x.OrderBy(kvp => kvp.Key).ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }

    [Test]
    public void GetCombinations_FullLengthTuple_Returns_TheInputInArbitraryOrder()
    {
        // Arrange
        int expectedResultsCount = 1;
        IList<IList<KeyValuePair<int, char>>> expectedResult = [_testElements.Select((v, i) => new KeyValuePair<int, char>(i, v)).ToArray()];

        // Act
        var actualResult = PowerSetGenerator.Combine(_testElements, _testElements.Length)
            .Select(x => x.OrderBy(kvp => kvp.Key).ToArray())
            .ToArray();

        // Assert
        Assert.That(actualResult.Length, Is.EqualTo(expectedResultsCount));
        Assert.That(actualResult, Is.EquivalentTo(expectedResult));
    }
}
