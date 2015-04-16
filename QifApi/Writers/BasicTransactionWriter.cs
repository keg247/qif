using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    internal static class BasicTransactionWriter
    {
        internal static void Write(TextWriter writer, string type, ICollection<BasicTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                writer.WriteLine(type);

                foreach (var item in list)
                {
                    writer.Write(NonInvestmentAccountFields.Date);
                    writer.WriteLine(item.Date.ToString("d"));

                    foreach (string address in item.Address)
                    {
                        writer.Write(NonInvestmentAccountFields.Address);
                        writer.WriteLine(address);
                    }

                    writer.Write(NonInvestmentAccountFields.Amount);
                    writer.WriteLine(item.Amount.ToString(CultureInfo.CurrentCulture));

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        writer.Write(NonInvestmentAccountFields.Category);
                        writer.WriteLine(item.Category);
                    }

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        writer.Write(NonInvestmentAccountFields.ClearedStatus);
                        writer.WriteLine(item.ClearedStatus);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        writer.Write(NonInvestmentAccountFields.Memo);
                        writer.WriteLine(item.Memo);
                    }

                    if (!string.IsNullOrEmpty(item.Number))
                    {
                        writer.Write(NonInvestmentAccountFields.Number);
                        writer.WriteLine(item.Number);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        writer.Write(NonInvestmentAccountFields.Payee);
                        writer.WriteLine(item.Payee);
                    }

                    foreach (int i in item.SplitCategories.Keys)
                    {
                        writer.Write(NonInvestmentAccountFields.SplitCategory);
                        writer.WriteLine(item.SplitCategories[i]);
                        writer.Write(NonInvestmentAccountFields.SplitAmount);
                        writer.WriteLine(item.SplitAmounts[i]);

                        string value;
                        if (item.SplitMemos.TryGetValue(i, out value))
                        {
                            writer.Write(NonInvestmentAccountFields.SplitMemo);
                            writer.WriteLine(value);
                        }
                    }

                    writer.WriteLine(InformationFields.EndOfEntry);
                }
            }
        }
    }
}