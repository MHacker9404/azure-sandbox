using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace AzureFunctionTimer
{
  [StorageAccount("AzureWebJobsStorage")]
  public static class Function1
  {
    [FunctionName("AzureFunctionTimerTriggered")]
    public static void Run([TimerTrigger("*/15 * * * * *")] TimerInfo myTimer,
        [Queue("the-queue", Connection = "AzureWebJobsStorage")] out string qMessage,
        ILogger log)
    {
      log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
      qMessage = "Timer triggered";
    }
  }
}
