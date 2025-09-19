// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Identity;

Console.WriteLine("Azure Blob Storage exercise\n");

DefaultAzureCredentialOptions options = new()
{
    ExcludeEnvironmentCredential = true,
    ExcludeManagedIdentityCredential = true
};

await ProcessAsync();

Console.WriteLine("\nPress enter to exit the sample application.");
Console.ReadLine();

async Task ProcessAsync()
{
    // CREATE A BLOB STORAGE CLIENT
    string accountName = "storageacct17453"; // 🔑 USE YOUR ACTUAL ACCOUNT NAME HERE
    DefaultAzureCredential credential = new DefaultAzureCredential(options);
    string blobServiceEndpoint = $"https://{accountName}.blob.core.windows.net";
    BlobServiceClient blobServiceClient = new BlobServiceClient(new Uri(blobServiceEndpoint), credential);

    // CREATE A CONTAINER
    string containerName = "wtblob" + Guid.NewGuid().ToString();
    Console.WriteLine("Creating container: " + containerName);
    BlobContainerClient containerClient = await blobServiceClient.CreateBlobContainerAsync(containerName);
    Console.WriteLine("Container created successfully.");

    // CREATE A LOCAL FILE
    string localPath = "./data/";
    string fileName = "wtfile" + Guid.NewGuid().ToString() + ".txt";
    string localFilePath = Path.Combine(localPath, fileName);
    await File.WriteAllTextAsync(localFilePath, "Hello, World!");

    // UPLOAD FILE
    BlobClient blobClient = containerClient.GetBlobClient(fileName);
    using (FileStream uploadFileStream = File.OpenRead(localFilePath))
    {
        await blobClient.UploadAsync(uploadFileStream, overwrite: true);
    }
    Console.WriteLine("File uploaded.");

    // LIST BLOBS
    Console.WriteLine("Listing blobs:");
    await foreach (BlobItem blobItem in containerClient.GetBlobsAsync())
    {
        Console.WriteLine("\t" + blobItem.Name);
    }

    // DOWNLOAD FILE
    string downloadFilePath = localFilePath.Replace(".txt", "DOWNLOADED.txt");
    BlobDownloadInfo download = await blobClient.DownloadAsync();
    using (FileStream downloadFileStream = File.OpenWrite(downloadFilePath))
    {
        await download.Content.CopyToAsync(downloadFileStream);
    }
    Console.WriteLine($"Blob downloaded to: {downloadFilePath}");
}
