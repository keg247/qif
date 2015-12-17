using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    static class InvestmentWriter
    {
        internal static void Write(TextWriter writer, ICollection<InvestmentTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                writer.WriteLine(Headers.Investment);

                foreach (InvestmentTransaction item in list)
                {
                    if (!string.IsNullOrEmpty(item.AccountForTransfer))
                    {
                        writer.Write(InvestmentAccountFields.AccountForTransfer);
                        writer.WriteLine(item.AccountForTransfer);
                    }

                    if (!string.IsNullOrEmpty(item.Action))
                    {
                        writer.Write(InvestmentAccountFields.Action);
                        writer.WriteLine(item.Action);
                    }

                    writer.Write(InvestmentAccountFields.AmountTransferred);
                    writer.WriteLine(item.AmountTransferred.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.Write(InvestmentAccountFields.ClearedStatus);
                        writer.WriteLine(item.ClearedStatus);
                    }

                    writer.Write(InvestmentAccountFields.Commission);
                    writer.WriteLine(item.Commission.ToString(CultureInfo.CurrentCulture));

                    writer.Write(InvestmentAccountFields.Date);
                    writer.WriteLine(item.Date.ToString("d"));

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.Write(InvestmentAccountFields.Memo);
                        writer.WriteLine(item.Memo);
                    }
                    writer.Write(InvestmentAccountFields.Price);
                    writer.WriteLine(item.Price.ToString(CultureInfo.CurrentCulture));

                    writer.Write(InvestmentAccountFields.Quantity);
                    writer.WriteLine(item.Quantity.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Security))
                    {
                        writer.Write(InvestmentAccountFields.Security);
                        writer.WriteLine(item.Security);
                    }

                    if (!string.IsNullOrEmpty(item.TextFirstLine))
                    {
                        writer.Write(InvestmentAccountFields.TextFirstLine);
                        writer.WriteLine(item.TextFirstLine);
                    }

                    writer.Write(InvestmentAccountFields.TransactionAmount);
                    writer.WriteLine(item.TransactionAmount.ToString(CultureInfo.CurrentCulture));

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}