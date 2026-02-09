namespace NoP77svk.PowerMultiset
{
    public static class PowerMultiSetGenerator
    {
        /// <summary>
        /// Generate all permutations for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of permutations of the input multiset. Each permutation is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Permute<T>(this IEnumerable<T> values)
            => Permute(values.ToArray());

        /// <summary>
        /// Generate all permutations for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of permutations of the input multiset. Each permutation is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Permute<T>(this IList<T> values)
            => values.GenerateSubMultiSet(values.Count, true);

        /// <summary>
        /// Generate all <paramref name="tupleSize"/>-element long combinations for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <param name="tupleSize">The target unordered tuple(s) size.</param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of combinations of the input multiset. Each combination is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Combine<T>(this IEnumerable<T> values, int tupleSize)
            => Combine(values.ToArray(), tupleSize);

        /// <summary>
        /// Generate all <paramref name="tupleSize"/>-element long combinations for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <param name="tupleSize">The target unordered tuple(s) size.</param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of combinations of the input multiset. Each combination is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Combine<T>(this IList<T> values, int tupleSize)
            => values.GenerateSubMultiSet(tupleSize, false);

        /// <summary>
        /// Generate all <paramref name="tupleSize"/>-element long variations for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <param name="tupleSize">The target unordered tuple(s) size.</param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of variations of the input multiset. Each variation is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Vary<T>(this IEnumerable<T> values, int tupleSize)
            => Vary(values.ToArray(), tupleSize);

        /// <summary>
        /// Generate all <paramref name="tupleSize"/>-element long variations for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <param name="tupleSize">The target unordered tuple(s) size.</param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of variations of the input multiset. Each variation is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> Vary<T>(this IList<T> values, int tupleSize)
            => values.GenerateSubMultiSet(tupleSize, true);

        /// <summary>
        /// Generate all sub-multi-sets (e.g. variations or combinations of all possible tuple sizes) for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <param name="elementOrderMatters"><list type="bullet">
        ///     <item><c>true</c> = each resulting multiset is a variation from the input <paramref name="values"/> multiset,</item>
        ///     <item><c>false</c> = each resulting multiset is a combination from the input <paramref name="values"/> multiset,</item>
        /// </list></param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of all possible submultisets of the input multiset. Each variation is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerMultiSet<T>(this IEnumerable<T> values, bool elementOrderMatters)
            => GeneratePowerMultiSet(values.ToArray(), elementOrderMatters);

        /// <summary>
        /// Generate all sub-multi-sets (e.g. variations or combinations of all possible tuple sizes) for the given multiset <paramref name="values"/>.
        /// </summary>
        /// <param name="values">The input multiset.</param>
        /// <param name="elementOrderMatters"><list type="bullet">
        ///     <item><c>true</c> = each resulting multiset is a variation from the input <paramref name="values"/> multiset,</item>
        ///     <item><c>false</c> = each resulting multiset is a combination from the input <paramref name="values"/> multiset,</item>
        /// </list></param>
        /// <typeparam name="T">The element type of the input multiset.</typeparam>
        /// <returns>
        ///     <para>Enumerable of all possible submultisets of the input multiset. Each variation is a collection of key/value pairs where <list type="bullet">
        ///         <item>key = the index of the original <paramref name="values"/> multiset element,</item>
        ///         <item>value = the original <paramref name="values"/> multiset element</item>
        ///     </list></para>
        /// </returns>
        public static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GeneratePowerMultiSet<T>(this IList<T> values, bool elementOrderMatters)
        {
            var result = Enumerable.Empty<IEnumerable<KeyValuePair<int, T>>>();

            for (int i = 0; i <= values.Count; i++)
            {
                var singleTupleSizeResult = values.GenerateSubMultiSet(i, elementOrderMatters);
                result = result.Concat(singleTupleSizeResult);
            }

            return result;
        }

        private static IEnumerable<IEnumerable<KeyValuePair<int, T>>> GenerateSubMultiSet<T>(this IList<T> values, int tupleSize, bool elementOrderMatters)
            => InternalGenerateSubMultiSet(
                values: values,
                tupleSize: tupleSize,
                usedInputIndices: new Stack<int>(),
                startIndex: 0,
                elementOrderMatters: elementOrderMatters
            );

        private static IEnumerable<IEnumerable<KeyValuePair<int, T>>> InternalGenerateSubMultiSet<T>(IList<T> values, int tupleSize, Stack<int> usedInputIndices, int startIndex, bool elementOrderMatters)
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
                var tuplesWithOneMoreElement = InternalGenerateSubMultiSet(values, tupleSize - 1, usedInputIndices, newStartIndex, elementOrderMatters);

                foreach (var resultTuple in tuplesWithOneMoreElement)
                {
                    yield return resultTuple;
                }

                usedInputIndices.Pop();
            }
        }
    }
}
