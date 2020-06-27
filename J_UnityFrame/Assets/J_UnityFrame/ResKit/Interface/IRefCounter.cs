
public interface IRefCounter
{
    int RefCount { get; }

    void Retain();

    void Release();
}

