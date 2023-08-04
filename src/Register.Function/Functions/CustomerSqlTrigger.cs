using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Sql;
using Microsoft.Extensions.Logging;
using Register.Function.Models;

namespace Register.Function.Functions;

public static class CustomerSqlTrigger
{
    [FunctionName("CustomerSqlTrigger")]
    public static Task RunAsync(
        [SqlTrigger("[dbo].[Customers]", "SqlConnectionString")]
        IReadOnlyList<SqlChange<Customer>> customersChanges,
        ILogger logger)
    {
        foreach (var customerChange in customersChanges)
        {
            var customerItem = customerChange.Item;
            logger.LogInformation($"Operação SQL: {customerChange.Operation}");
            logger.LogInformation($"Nome: {customerItem.Name} - Ativo: {customerItem.Active} - Id: {customerItem.Id}");
        }

        return Task.CompletedTask;
    }
}