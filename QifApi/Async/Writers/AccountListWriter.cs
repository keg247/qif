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
    static partial class AccountListWriter
    {
        internal static async Task WriteAsync(TextWriter writer, ICollection<AccountListTransaction> list)
        {
            if (list != null && list.Count > 0)
            {
                await (writer.WriteLineAsync(Headers.AccountList)).ConfigureAwait(true);

                foreach (var item in list)
                {
                    if (!string.IsNullOrEmpty(item.Type))
                    {
                        await (writer.WriteAsync(AccountInformationFields.AccountType)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Type)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(AccountInformationFields.CreditLimit)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.CreditLimit.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    if (!string.IsNullOrEmpty(item.Description))
                    {
                        await (writer.WriteAsync(AccountInformationFields.Description)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Description)).ConfigureAwait(true);
                    }

                    if (!string.IsNullOrEmpty(item.Name))
                    {
                        await (writer.WriteAsync(AccountInformationFields.Name)).ConfigureAwait(true);
                        await (writer.WriteLineAsync(item.Name)).ConfigureAwait(true);
                    }

                    await (writer.WriteAsync(AccountInformationFields.StatementBalance)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.StatementBalance.ToString(CultureInfo.CurrentCulture))).ConfigureAwait(true);

                    await (writer.WriteAsync(AccountInformationFields.StatementBalanceDate)).ConfigureAwait(true);
                    await (writer.WriteLineAsync(item.StatementBalanceDate.ToString("d"))).ConfigureAwait(true);

                    await (writer.WriteLineAsync(InformationFields.EndOfEntry)).ConfigureAwait(true);
                }
            }
        }
    }
}