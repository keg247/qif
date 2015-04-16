namespace Hazzik.Qif
{
    internal interface IParser
    {
        void Yield(QifDocument document);
        void ParseLine(string line);
    }
}