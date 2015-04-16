using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
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