public struct Clock
{
    public readonly float Seconds;

    public Clock(float seconds)
    {
        Seconds = seconds;
    }

    public Clock(float tempo, float beats)
    {
        var secPerBeat = 60 / tempo;
        Seconds = beats * secPerBeat;
    }

    public static Clock operator +(Clock a, Clock b)
    {
        return new Clock(a.Seconds + b.Seconds);
    }

    public static Clock operator -(Clock a, Clock b)
    {
        return new Clock(a.Seconds - b.Seconds);
    }

    public override bool Equals(object other)
    {
        return this == (Clock)other;
    }

    public static bool operator ==(Clock a, Clock b)
    {
        return a.Seconds == b.Seconds;
    }

    public static bool operator !=(Clock a, Clock b)
    {
        return !(a == b);
    }

    public static bool operator <(Clock a, Clock b)
    {
        return a.Seconds < b.Seconds;
    }

    public static bool operator >(Clock a, Clock b)
    {
        return b < a;
    }

    public static bool operator <=(Clock a, Clock b)
    {
        return a.Seconds <= b.Seconds;
    }

    public static bool operator >=(Clock a, Clock b)
    {
        return b <= a;
    }

    public override int GetHashCode()
    {
        return Seconds.GetHashCode();
    }
}
