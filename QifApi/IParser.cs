namespace QifApi
{
    internal interface IParser
    {
        void Yield(QifDom dom);
        void ParseLine(string line);
    }
}