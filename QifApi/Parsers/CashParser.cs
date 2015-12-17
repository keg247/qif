using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    class CashParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.CashTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}