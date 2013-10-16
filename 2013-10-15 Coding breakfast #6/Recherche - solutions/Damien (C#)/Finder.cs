using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RechercheIndexee
{
    public class Finder
    {
        public static int FindIn(params int[] array)
        {
            if (array == null || array.Length == 0)
                throw new ArgumentNullException("array", "Le tableau ne peut pas être vide");
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == i)
                    return i;
            }
            return -1;
        }
    }
}
