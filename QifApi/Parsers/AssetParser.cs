using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class AssetParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.AssetTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}