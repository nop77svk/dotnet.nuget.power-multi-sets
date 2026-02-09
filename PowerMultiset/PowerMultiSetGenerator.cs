namespace NoP77svk.PowerMultiset
{
    public static class PowerMultiSetGenerator
    {
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Permute<T>(this IEnumerable<T> values)
            => Permute(values.ToArray());

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Permute<T>(this IList<T> values)
            => values.GeneratePowerMultiSet(values.Count, true);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Combine<T>(this IEnumerable<T> values, int tupleSize)
            => Combine(values.ToArray(), tupleSize);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Combine<T>(this IList<T> values, int tupleSize)
            => values.GeneratePowerMultiSet(tupleSize, false);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Vary<T>(this IEnumerable<T> values, int tupleSize)
            => Vary(values.ToArray(), tupleSize);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Vary<T>(this IList<T> values, int tupleSize)
            => values.GeneratePowerMultiSet(tupleSize, true);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerMultiSet<T>(this IEnumerable<T> values, bool elementOrderMatters)
            => GeneratePowerMultiSet(values.ToArray(), elementOrderMatters);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerMultiSet<T>(this IList<T> values, bool elementOrderMatters)
        {
            var result = Enumerable.Empty<IEnumerable<KeyValuePair<int, T>>>();

            for (int i = 0; i <= values.Count; i++)
            {
                var singleTupleSizeResult = values.GeneratePowerMultiSet(i, elementOrderMatters);
                result = result.Concat(singleTupleSizeResult);
            }

            return result;
        }

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerMultiSet<T>(this IEnumerable<T> values, int tupleSize, bool elementOrderMatters)
            => GeneratePowerMultiSet(values.ToArray(), tupleSize, elementOrderMatters);

        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerMultiSet<T>(this IList<T> values, int tupleSize, bool elementOrderMatters)
            => InternalGeneratePowerMultiSet(
                values: values,
                tupleSize: tupleSize,
                usedInputIndices: new Stack<int>(),
                startIndex: 0,
                elementOrderMatters: elementOrderMatters
            );

        private static IEnumerable<IEnumerable<KeyValuePair<int, T>>> InternalGeneratePowerMultiSet<T>(IList<T> values, int tupleSize, Stack<int> usedInputIndices, int startIndex, bool elementOrderMatters)
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
                var tuplesWithOneMoreElement = InternalGeneratePowerMultiSet(values, tupleSize - 1, usedInputIndices, newStartIndex, elementOrderMatters);

                foreach (var resultTuple in tuplesWithOneMoreElement)
                {
                    yield return resultTuple;
                }

                usedInputIndices.Pop();
            }
        }
    }
}
