//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Options;
//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
//using ProyectoMaestro.Helpers.Azure;
//using System.Text.Json;
//using Microsoft.Extensions.Configuration;
//using static Data.ConciliacionCasetasRepository;
//using System.Security.Claims;
//using Microsoft.AspNetCore.Authorization;
//using Data;

//namespace ProyectoMaestro.Controllers.Catalogos
//{
//    [Authorize]
//    [Route("api/[controller]")]
//    [ApiController]
//    public class BlobStorageController : ControllerBase
//    {
//        private readonly IConciliacionCasetasRepository _repository;
//        private readonly IOptions<AzureConfig> config;
//        IConfiguration _iconfiguration;

//        public BlobStorageController(IConfiguration iconfiguration, IConciliacionCasetasRepository repository, IOptions<AzureConfig> config)
//        {
//            this.config = config;
//            _iconfiguration = iconfiguration;
//            _repository = repository;

//        }
//        [HttpGet("ListFiles")]
//        public async Task<List<string>> ListFiles()
//        {
//            List<string> blobs = new List<string>();
//            try
//            {
//                //var claimsIdentity = User.Identity as ClaimsIdentity;
//                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
//                //var usuario = await _repository.ObtenerUsuario360NoTracking(claimid.Value);

//                if (CloudStorageAccount.TryParse(config.Value.AzureBlobConnection, out CloudStorageAccount storageAccount))
//                {
//                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
//                    CloudBlobContainer container = blobClient.GetContainerReference(config.Value.AzureBlobContainer);
//                    BlobResultSegment resultSegment = await container.ListBlobsSegmentedAsync(null);
//                    foreach (IListBlobItem item in resultSegment.Results)
//                    {
//                        if (item.GetType() == typeof(CloudBlockBlob))
//                        {
//                            CloudBlockBlob blob = (CloudBlockBlob)item;
//                            blobs.Add(blob.Name);
//                        }
//                        else if (item.GetType() == typeof(CloudPageBlob))
//                        {
//                            CloudPageBlob blob = (CloudPageBlob)item;
//                            blobs.Add(blob.Name);
//                        }
//                        else if (item.GetType() == typeof(CloudBlobDirectory))
//                        {
//                            CloudBlobDirectory dir = (CloudBlobDirectory)item;
//                            blobs.Add(dir.Uri.ToString());
//                        }
//                    }
//                }
//            }
//            catch
//            {
//            }
//            return blobs;
//        }

//        [HttpPost("InsertFile")]
//        public async Task<ActionResult> InsertFileWebHook([FromForm] IFormFile asset, [FromForm] string jsonConfiguracion)
//        {
//            try
//            {
//                //var claimsIdentity = User.Identity as ClaimsIdentity;
//                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
//                //var usuario = await _repository.ObtenerUsuario360NoTracking(claimid.Value);

//                if (asset == null)
//                {
//                    return BadRequest(new RespuestaBd() { BValido = false, IntError = 1, Mensaje = "No se pudo procesar el archivo." });
//                }
               
//                AzureFileProperties propiedades = JsonSerializer.Deserialize<AzureFileProperties>(jsonConfiguracion);

//                var azureBlobConnection = _iconfiguration.GetSection("AzureConfig").GetSection("AzureBlobConnection").Value;
//                var azureBlobContainer = _iconfiguration.GetSection("AzureConfig").GetSection("AzureBlobContainer").Value;

//                if (CloudStorageAccount.TryParse(azureBlobConnection, out CloudStorageAccount storageAccount))
//                {
//                    string archivo = "";
//                    if (!string.IsNullOrEmpty(propiedades.NombreArchivo))
//                    {
//                        //archivo = propiedades.NombreArchivo + "." + propiedades.Extension;
//                        archivo = propiedades.NombreArchivo;
//                    }
//                    else
//                    {
//                        archivo = asset.FileName;
//                    }
//                    CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
//                    CloudBlobContainer container = blobClient.GetContainerReference(azureBlobContainer);
//                    CloudBlockBlob blockBlob = container.GetBlockBlobReference(archivo);
//                    await blockBlob.UploadFromStreamAsync(asset.OpenReadStream());
//                    return Ok(new RespuestaBd() { BValido = true, IntError = 0, Mensaje = archivo });
//                }
//                else
//                {
//                    return BadRequest(new RespuestaBd() { BValido = false, IntError = 1, Mensaje = "No se pudo procesar el archivo." });
//                }
//            }
//            catch
//            {
//                return BadRequest(new RespuestaBd() { BValido = false, IntError = 1, Mensaje = "Error inesperado. No es posible continuar." });
//            }
//        }



//        [HttpGet("DownloadFile/{fileName}")]
//        public async Task<IActionResult> DownloadFile(string fileName)
//        {
//            MemoryStream ms = new MemoryStream();
//            var azureBlobConnection = _iconfiguration.GetSection("AzureConfig").GetSection("AzureBlobConnection").Value;
//            var azureBlobContainer = _iconfiguration.GetSection("AzureConfig").GetSection("AzureBlobContainer").Value;

//            if (CloudStorageAccount.TryParse(azureBlobConnection, out CloudStorageAccount storageAccount))
//            {
//                //var claimsIdentity = User.Identity as ClaimsIdentity;
//                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
//                //var usuario = await _repository.ObtenerUsuario360NoTracking(claimid.Value);

//                CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
//                CloudBlobContainer container = BlobClient.GetContainerReference(azureBlobContainer);
//                if (await container.ExistsAsync())
//                {
//                    CloudBlob file = container.GetBlobReference(fileName);
//                    if (await file.ExistsAsync())
//                    {
//                        await file.FetchAttributesAsync();//Fetch blob's properties
//                        byte[] arr = new byte[file.Properties.Length];
//                        await file.DownloadToByteArrayAsync(arr, 0);
//                        var azureBase64 = Convert.ToBase64String(arr);
//                        return Ok(new RespuestaBd() { BValido = true, IntError = 0, Mensaje = azureBase64 });
//                    }
//                    else
//                    {
//                        return BadRequest("File does not exist");
//                    }
//                }
//                else
//                {
//                    return BadRequest("Container does not exist");
//                }
//            }
//            else
//            {
//                return BadRequest("Error opening storage");
//            }
//        }

//        [Route("DeleteFile/{fileName}")]
//        [HttpGet]
//        public async Task<bool> DeleteFile(string fileName)
//        {
//            try
//            {
//                //var claimsIdentity = User.Identity as ClaimsIdentity;
//                //var claimid = claimsIdentity.FindFirst("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier");
//                //var usuario = await _repository.ObtenerUsuario360NoTracking(claimid.Value);

//                if (CloudStorageAccount.TryParse(config.Value.AzureBlobConnection, out CloudStorageAccount storageAccount))
//                {
//                    CloudBlobClient BlobClient = storageAccount.CreateCloudBlobClient();
//                    CloudBlobContainer container = BlobClient.GetContainerReference(config.Value.AzureBlobContainer);
//                    if (await container.ExistsAsync())
//                    {
//                        CloudBlob file = container.GetBlobReference(fileName);
//                        if (await file.ExistsAsync())
//                        {
//                            await file.DeleteAsync();
//                        }
//                    }
//                }
//                return true;
//            }
//            catch
//            {
//                return false;
//            }
//        }
//    }
//}