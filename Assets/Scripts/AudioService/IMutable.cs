public interface IMutable
{
    bool IsMuted { get; }

    void SetMuteValue(bool isMuted);
}
