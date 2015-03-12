using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class AssetParser : BasicTransactionParser
    {
        public override void Yield(QifDom dom)
        {
            dom.AssetTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}