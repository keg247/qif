using Keg247.Qif.Transactions;
using Keg247.Qif.Transactions.Fields;

namespace Keg247.Qif.Parsers
{
    class AccountListParser : IParser
    {
        private AccountListTransaction item = new AccountListTransaction();

        public void Yield(QifDocument document)
        {
            document.AccountListTransactions.Add(item);
            item = new AccountListTransaction();
        }

        public void ParseLine(string line)
        {
            var value = line.Substring(1);
            switch (line[0])
            {
                case AccountInformationFields.AccountType:
                    item.Type = value;
                    break;
                case AccountInformationFields.CreditLimit:
                    item.CreditLimit = Common.GetDecimal(value);
                    break;
                case AccountInformationFields.Description:
                    item.Description = value;
                    break;
                case AccountInformationFields.Name:
                    item.Name = value;
                    break;
                case AccountInformationFields.StatementBalance:
                    item.StatementBalance = Common.GetDecimal(value);
                    break;
                case AccountInformationFields.StatementBalanceDate:
                    item.StatementBalanceDate = Common.GetDateTime(value);
                    break;
            }
        }
    }
}