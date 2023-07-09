using Keg247.Qif.Transactions;

namespace Keg247.Qif.Parsers
{
    class AssetParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AssetTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}