using Hazzik.Qif.Transactions;

namespace Hazzik.Qif.Parsers
{
    class BankParser : BasicTransactionParser
    {
        public override void Yield(QifDocument document)
        {
            document.BankTransactions.Add(Item);
            Item = new BasicTransaction();
        }
    }
}