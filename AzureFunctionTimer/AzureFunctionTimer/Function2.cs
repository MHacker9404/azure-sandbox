using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunctionTimer
{
  [StorageAccount("AzureWebJobsStorage")]
  public static class Function2
  {
    [FunctionName("AzureFunctionQueueTriggered")]
    public static void Run([QueueTrigger("the-queue", Connection = "AzureWebJobsStorage")] string myQueueItem,
        [Blob("the-blobs/{queueTrigger}", FileAccess.Read, Connection = "AzureWebJobsStorage")] Stream myPic,
            ILogger log)
    {
      log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
      if (myPic != null)
      {
        if (myQueueItem.ToUpper().Contains("SECURITY"))
        {
          log.LogInformation($"Security Image found picSize: {myPic.Length} bytes");
        }
        else
        {
          log.LogInformation($"New Image found picSize: {myPic.Length} bytes");
        }
      }
    }
  }
}
