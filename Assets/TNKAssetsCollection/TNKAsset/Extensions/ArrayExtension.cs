using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyAsset.Extensions
{
    public static class ArrayExtensions
    {
        public static T GetRandomItem<T>(this IList<T> list)
        {
            if (list == null || list.Count <= 0)
                return default;
            
            return list[Random.Range(0, list.Count)];
        }


        public static IEnumerable<T> GetRandomItems<T>(this IList<T> list)
        {
            return list.GetRandomItems(Random.Range(0, list.Count));
        }

        public static IEnumerable<T> GetRandomItems<T>(this IList<T> list, int count)
        {
            int numToChoose = count;

            for (int numLeft = list.Count; numLeft > 0; numLeft--)
            {
                float prob = numToChoose / (float)numLeft;

                if (Random.value <= prob)
                {
                    numToChoose--;

                    yield return list[numLeft - 1];

                    if (numToChoose == 0)
                        break;
                }
            }
        }
    }
}
