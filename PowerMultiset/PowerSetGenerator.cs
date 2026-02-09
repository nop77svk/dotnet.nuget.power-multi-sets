namespace NoP77svk.PowerMultiset
{
    public static class PowerSetGenerator
    {
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Permute<T>(this IEnumerable<T> values)
            => Permute(values.ToArray());

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Permute<T>(this IList<T> values)
            => values.GeneratePowerSet(values.Count, true);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Combine<T>(this IEnumerable<T> values, int tupleSize)
            => Combine(values.ToArray(), tupleSize);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Combine<T>(this IList<T> values, int tupleSize)
            => values.GeneratePowerSet(tupleSize, false);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Vary<T>(this IEnumerable<T> values, int tupleSize)
            => Vary(values.ToArray(), tupleSize);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Vary<T>(this IList<T> values, int tupleSize)
            => values.GeneratePowerSet(tupleSize, true);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerSet<T>(this IList<T> values, int tupleSize, bool elementOrderMatters)
            => InternalGeneratePowerSetTuples(
                values: values,
                tupleSize: tupleSize,
                usedInputIndices: new Stack<int>(),
                startIndex: 0,
                elementOrderMatters: elementOrderMatters
            );

        private static IEnumerable<IEnumerable<KeyValuePair<int, T>>> InternalGeneratePowerSetTuples<T>(IList<T> values, int tupleSize, Stack<int> usedInputIndices, int startIndex, bool elementOrderMatters)
        {
            if (tupleSize <= 0)
            {
                var resultTuple = usedInputIndices
                    .Select(i => new KeyValuePair<int, T>(i, values[i]));

                yield return resultTuple;
                yield break;
            }

            if (startIndex >= values.Count)
            {
                yield break;
            }

            HashSet<int> usedInputIndicesIndexed = usedInputIndices.ToHashSet();

            for (int i = startIndex; i < values.Count; i++)
            {
                if (usedInputIndicesIndexed.Contains(i))
                {
                    continue;
                }

                usedInputIndices.Push(i);
                int newStartIndex = elementOrderMatters ? 0 : i + 1;
                var tuplesWithOneMoreElement = InternalGeneratePowerSetTuples(values, tupleSize - 1, usedInputIndices, newStartIndex, elementOrderMatters);

                foreach (var resultTuple in tuplesWithOneMoreElement)
                {
                    yield return resultTuple;
                }

                usedInputIndices.Pop();
            }
        }
    }
}
