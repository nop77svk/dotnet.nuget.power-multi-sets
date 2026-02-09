namespace NoP77svk.CombiGen
{
    public static class CombiGenerator
    {
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GetPermutations<T>(this IEnumerable<T> values)
            => GetPermutations(values.ToArray());

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GetPermutations<T>(this IList<T> values)
            => GetVariations(values, values.Count);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GetCombinations<T>(this IEnumerable<T> values, int tupleSize)
            => GetCombinations(values.ToArray(), tupleSize);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GetCombinations<T>(this IList<T> values, int tupleSize)
            => throw new NotImplementedException();

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GetVariations<T>(this IEnumerable<T> values, int tupleSize)
            => GetVariations(values.ToArray(), tupleSize);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GetVariations<T>(this IList<T> values, int tupleSize)
            => InternalGetVariations(values, tupleSize, new Stack<int>(), () => 0);

        private static IEnumerable<IEnumerable<KeyValuePair<int, T>>> InternalGetVariations<T>(IList<T> values, int tupleSize, Stack<int> usedInputIndices, Func<int> startIndexSelector)
        {
            if (tupleSize <= 0)
            {
                var variation = usedInputIndices
                    .Select(i => new KeyValuePair<int, T>(i, values[i]));

                yield return variation;
                yield break;
            }

            HashSet<int> usedInputIndicesIndexed = usedInputIndices.ToHashSet();

            int startIndex = startIndexSelector();
            for (int i = startIndex; i < values.Count; i++)
            {
                if (usedInputIndicesIndexed.Contains(i))
                {
                    continue;
                }

                usedInputIndices.Push(i);
                var oneMoreElementVariations = InternalGetVariations(values, tupleSize - 1, usedInputIndices, startIndexSelector);

                foreach (var variation in oneMoreElementVariations)
                {
                    yield return variation;
                }

                usedInputIndices.Pop();
            }
        }
    }
}
