using Microsoft.AspNetCore.Mvc;

namespace GoldenLotteryAPI.Controllers
{
    [Route("[controller]")]
    public class UploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public UploadController(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        [HttpPost]
        [Route("Upload")]
        public IActionResult UploadFile([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Arquivo inválido");
            }

            try
            {
                // Lógica para gerar um nome de arquivo único
                var uniqueFileName = Guid.NewGuid().ToString() + "_" + file.FileName;

                // Caminho completo do arquivo no servidor
                var filePath = Path.Combine(_hostingEnvironment.ContentRootPath, "uploads", uniqueFileName);

                // Salva o arquivo no servidor
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Armazena o caminho do arquivo na TempData
                HttpContext.Items["file"] = filePath;

                // Retorne o caminho do arquivo ou outra informação necessária
                return Ok(new { filePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro interno do servidor: {ex.Message}");
            }
        }
    }
}
