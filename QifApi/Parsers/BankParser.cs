using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class BankParser : BasicTransactionParser
    {
        public override void Yield(QifDom dom)
        {
            dom.BankTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}