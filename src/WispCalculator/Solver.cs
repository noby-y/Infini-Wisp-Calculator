namespace WispCalculator;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
internal static class Solver
{
    private const int c_maxPermutations = 64;
    public static spellSet[,] Filter(int minLifetime, int maxLifetime, int maxMods)
    {
        spellSet[,] wispList = new spellSet[maxLifetime + 1, c_maxPermutations];
        for (int lifetime = minLifetime; lifetime < maxLifetime + 1; lifetime++)
        {
            List<spellSet> results = new List<spellSet>();

            Parallel.For(0, maxMods, decrease =>
            {
                for (int increase = 0; increase <= maxMods; increase++)

                    for (int chain = 0; chain <= maxMods; chain++)

                        for (int phasing = 0; phasing <= maxMods; phasing++)

                            for (int orbitpingpong = 0; orbitpingpong <= maxMods; orbitpingpong++)

                                for (int spiral = 0; spiral <= maxMods; spiral++)

                                    if (lifetime - 42 * decrease + 75 * increase - 30 * chain + 80 * phasing + 25 * orbitpingpong + 50 * spiral == -1)
                                        lock (results)
                                        {
                                            results.Add(new() { _decrease = decrease, _increase = increase, _chain = chain, _phasing = phasing, _orbitpingpong = orbitpingpong, _spiral = spiral });
                                        }
            });

            // FILTERING RESULTS

            for (int s = 0; s < c_maxPermutations; s++)
            {
                BitArray bArr = new BitArray(new int[] { s });
                bool[] bits = new bool[bArr.Length];
                bArr.CopyTo(bits, 0);

                int[] decreaseRange = new int[] { bits[0] ? 1 : 0, bits[0] ? maxMods : 0 };
                int[] increaseRange = new int[] { bits[1] ? 1 : 0, bits[1] ? maxMods : 0 };
                int[] chainRange = new int[] { bits[2] ? 1 : 0, bits[2] ? maxMods : 0 };
                int[] phasingRange = new int[] { bits[3] ? 1 : 0, bits[3] ? maxMods : 0 };
                int[] orbitpingpongRange = new int[] { bits[4] ? 1 : 0, bits[4] ? maxMods : 0 };
                int[] spiralRange = new int[] { bits[5] ? 1 : 0, bits[5] ? maxMods : 0 };

                try
                {
                    spellSet finalSet = results.Where(set =>
                    set._decrease >= decreaseRange[0] && set._decrease <= decreaseRange[1] &&
                    set._increase >= increaseRange[0] && set._increase <= increaseRange[1] &&
                    set._chain >= chainRange[0] && set._chain <= chainRange[1] &&
                    set._phasing >= phasingRange[0] && set._phasing <= phasingRange[1] &&
                    set._orbitpingpong >= orbitpingpongRange[0] && set._orbitpingpong <= orbitpingpongRange[1] &&
                    set._spiral >= spiralRange[0] && set._spiral <= spiralRange[1]
                    ).MinBy(set => set.count);

                    wispList[lifetime, s] = finalSet;
                }
                catch { }
            }
        }
        return wispList;
    }
}
