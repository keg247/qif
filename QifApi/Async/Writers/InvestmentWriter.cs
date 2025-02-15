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
using Keg247.Qif.Transactions;
using Keg247.Qif.Transactions.Fields;

namespace Keg247.Qif.Writers
{
    using System.Threading.Tasks;
    static partial class InvestmentWriter
    {
        internal static async Task WriteAsync(TextWriter writer, ICollection<InvestmentTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                await (writer.WriteLineAsync(Headers.Investment)).ConfigureAwait(true);

                foreach (InvestmentTransaction item in list)
                {
                    if (!string.IsNullOrEmpty(item.AccountForTransfer))
                    {
                        await (writer.WriteAsync(InvestmentAccountFields.AccountForTransfer)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.AccountForTransfer)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.Action))
                    {
                        await (writer.WriteAsync(InvestmentAccountFields.Action)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Action)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(InvestmentAccountFields.AmountTransferred)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.AmountTransferred.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.ClearedStatus))
                    {
                        await (writer.WriteAsync(InvestmentAccountFields.ClearedStatus)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.ClearedStatus)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(InvestmentAccountFields.Commission)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.Commission.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    await (writer.WriteAsync(InvestmentAccountFields.Date)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.Date.ToString("d"))).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.Memo))
                    {
                        await (writer.WriteAsync(InvestmentAccountFields.Memo)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Memo)).ConfigureAwait(true);
                    }
                    await (writer.WriteAsync(InvestmentAccountFields.Price)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.Price.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    await (writer.WriteAsync(InvestmentAccountFields.Quantity)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.Quantity.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.Security))
                    {
                        await (writer.WriteAsync(InvestmentAccountFields.Security)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Security)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.TextFirstLine))
                    {
                        await (writer.WriteAsync(InvestmentAccountFields.TextFirstLine)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.TextFirstLine)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(InvestmentAccountFields.TransactionAmount)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.TransactionAmount.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    await (writer.WriteLineAsync(InformationFields.EndOfEntry)).ConfigureAwait(true);
                }
            }
        }
    }
}