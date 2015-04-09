using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class CashParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.CashTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}