namespace WispCalculator;
public struct spellSet
{
    public int _decrease;
    public int _increase;
    public int _chain;
    public int _phasing;
    public int _orbitpingpong;
    public int _spiral;
    public int count { get { return (_decrease + _increase + _chain + _phasing + _orbitpingpong + _spiral); } }
    public int lifetime { get { return ((-42) * _decrease + (75) * _increase + (-30) * _chain + (80) * _phasing + (25) * _orbitpingpong + (50) * _spiral); } }

    public override string ToString() => count > 0 ? $"decr[{_decrease}]  incr[{_increase}]  chain[{_chain}]  phase[{_phasing}]  orb/ping[{_orbitpingpong}] spir[{_spiral}]" : "Impossible";

    public string ToCsv() => count > 0 ? $"{_decrease}, {_increase}, {_chain}, {_phasing}, {_orbitpingpong}, {_spiral}, {count}" : "Impossible, Impossible, Impossible, Impossible, Impossible, Impossible, Impossible";
}
