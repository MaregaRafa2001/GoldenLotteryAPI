//using GoldenLotteryAPI.Core;
//using Google.Apis.Auth.OAuth2;
//using Google.Apis.Drive.v3;
//using Google.Apis.Services;
//using Google.Apis.Util.Store;
//using Microsoft.AspNetCore.Hosting.Server;
//using Org.BouncyCastle.Tls;
//using System.IO;

//namespace GoldenLotteryAPI.BusinessObjects.Core
//{
//    public class GoogleDriveHandlerBLL
//    {
//        public string UploadFile(IFormFile file, string folderId)
//        {
//            UserCredential credential;

//            string credentialPath = Directory.GetCurrentDirectory() + "/client_secret.json";
//            using (var stream = new FileStream(credentialPath, FileMode.Open, System.IO.FileAccess.Read))
//            {
//                string credPath = Directory.GetCurrentDirectory();
//                credPath = Path.Combine(credPath, ".credentials\\meucurso.json");

//                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
//                    GoogleClientSecrets.Load(stream).Secrets,
//                    ,
//                    "user",
//                    CancellationToken.None,
//                    new FileDataStore(credPath, true)).Result;
//            }

//            // Create Drive API service.
//            var service = new DriveService(new BaseClientService.Initializer()
//            {
//                HttpClientInitializer = credential,
//                ApplicationName = "GoldenLottery",
//            });

//            var fileMetadata = new Google.Apis.Drive.v3.Data.File()
//            {
//                Name = file.FileName,
//                Parents = new List<string>
//                {
//                    folderId
//                }
//            };

//            FilesResource.CreateMediaUpload request;
//            Google.Apis.Upload.IUploadProgress progress;

//            using (var stream = file.OpenReadStream())
//            {
//                request = service.Files.Create(fileMetadata, stream, file.ContentType);
//                request.Fields = "id";
//                progress = request.Upload();
//            }

//            var response = request.ResponseBody;

//            if (response != null)
//                model.GoogleDriveId = response.Id;
//            else
//                throw new System.Exception(progress.Status.ToString(), progress.Exception);

//            return response.Id;
//            return "";
//        }
//    }
//}
