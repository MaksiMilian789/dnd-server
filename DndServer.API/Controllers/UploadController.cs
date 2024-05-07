using DndServer.Application.Shared.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

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
    public PhysicalFileResult GetFile(int fileId)
    {
        var (path, file) = _uploadService.GetImage(fileId);
        var provider = new FileExtensionContentTypeProvider();
        if (!provider.TryGetContentType(file.FileName, out var contentType))
        {
            contentType = "application/octet-stream";
        }

        return PhysicalFile(path, contentType);
    }
}