using DndServer.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace DndServer.API.Controllers;

/// <summary>
///     Контроллер изображений для мнемосхем
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;

    /// <summary>
    ///     Конструктор
    /// </summary>
    public UploadController(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    /// <summary>
    ///     Загрузить изображение
    /// </summary>
    /// <param name="upload">Файл изображения</param>
    [Authorize]
    [HttpPost]
    public Task<int> UploadFile(IFormFile upload)
    {
        return _uploadService.UploadImage(upload);
    }

    /// <summary>
    ///     Получение изображения по Id
    /// </summary>
    /// <param name="fileId">Id файла изображения </param>
    [HttpGet("{fileId}")]
    public FileContentResult GetFile(int fileId)
    {
        var (image, file) = _uploadService.GetImage(fileId);
        var contentType = GetMimeType(file.FileName);

        return File(image, contentType);
    }

    private string GetMimeType(string fileName)
    {
        var mimeType = "application/unknown";
        var ext = Path.GetExtension(fileName).ToLower();
        var regKey = Registry.ClassesRoot.OpenSubKey(ext);
        if (regKey != null && regKey.GetValue("Content Type") != null)
        {
            mimeType = regKey.GetValue("Content Type").ToString();
        }

        return mimeType;
    }
}