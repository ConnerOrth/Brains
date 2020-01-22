using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Brains.Infrastructure.Helpers
{
    public sealed class CryptoRandom
    {
        private static readonly Random random;

        static CryptoRandom()
        {
            using (RNGCryptoServiceProvider rngProvider = new RNGCryptoServiceProvider())
            {
                byte[] randomBytes = new byte[4];
                rngProvider.GetBytes(randomBytes);
                int randomSeed = BitConverter.ToInt32(randomBytes);
                int hash = rngProvider.GetHashCode();
                random = new Random(randomSeed);
                Console.WriteLine($"hash of random:{random.GetHashCode()}");
                Console.WriteLine($"seed of random:{randomSeed}");
            }
        }

        public static double RandomValue =>
            ((.92 * random.NextDouble()) + .1307) * (random.Next(2) == 0 ? -1 : 1);
        public static double SmallRandomValue =>
            ((.00092 * random.NextDouble()) + .0001307) * (random.Next(2) == 0 ? -1 : 1);
    }

}
