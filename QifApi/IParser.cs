namespace QifApi
{
    internal interface IParser
    {
        void Yield(QifDocument document);
        void ParseLine(string line);
    }
}