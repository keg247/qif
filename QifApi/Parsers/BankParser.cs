using QifApi.Transactions;

namespace QifApi.Parsers
{
    internal class BankParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.BankTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}