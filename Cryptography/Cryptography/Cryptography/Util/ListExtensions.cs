using System;
using System.Collections.Generic;


namespace Cryptography.Util {
    static class ListExtensions {
        public static T Random<T>(this List<T> obj) {
            Random rand = new Random();
            return obj[rand.Next(obj.Count)];
        }
    }
}
