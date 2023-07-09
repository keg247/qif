namespace Keg247.Qif
{
    interface IParser
    {
        void Yield(QifDocument document);
        void ParseLine(string line);
    }
}