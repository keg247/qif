using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class LiabilityParser : BasicTransactionParser
    {
        public override void Yield(QifDom dom)
        {
            dom.LiabilityTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}