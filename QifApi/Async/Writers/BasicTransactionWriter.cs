﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by AsyncGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Hazzik.Qif.Transactions;
using Hazzik.Qif.Transactions.Fields;

namespace Hazzik.Qif.Writers
{
    using System.Threading.Tasks;
    static partial class BasicTransactionWriter
    {
        internal static async Task WriteAsync(TextWriter writer, string type, ICollection<BasicTransaction> list)
        {
            if ((list != null) && (list.Count > 0))
            {
                await (writer.WriteLineAsync(type)).ConfigureAwait(true);

                foreach (var item in list)
                {
                    await (writer.WriteAsync(NonInvestmentAccountFields.Date)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.Date.ToString("d"))).ConfigureAwait(true);

                    foreach (string address in item.Address)
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.Address)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(address)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(NonInvestmentAccountFields.Amount)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.Amount.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.Category))
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.Category)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Category)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.ClearedStatus)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.ClearedStatus)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.Memo)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Memo)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.Number))
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.Number)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Number)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.Payee))
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.Payee)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Payee)).ConfigureAwait(true);
                    }

                    foreach (int i in item.SplitCategories.Keys)
                    {
                        await (writer.WriteAsync(NonInvestmentAccountFields.SplitCategory)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.SplitCategories[i])).ConfigureAwait(true);
                        await (writer.WriteAsync(NonInvestmentAccountFields.SplitAmount)).ConfigureAwait(true);
                        writer.WriteLine(item.SplitAmounts[i]);

                        string value;
                        if (item.SplitMemos.TryGetValue(i, out value))
                        {
                            await (writer.WriteAsync(NonInvestmentAccountFields.SplitMemo)).ConfigureAwait(true);
                            await (writer.WriteLineAsync(value)).ConfigureAwait(true);
                        }
                    }

                    await (writer.WriteLineAsync(InformationFields.EndOfEntry)).ConfigureAwait(true);
                }
            }
        }
    }
}