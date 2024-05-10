using DndServer.Application.Interfaces;
using DndServer.Application.Interfaces.Upload;
using DndServer.Application.Shared.Interfaces;
using DndServer.Application.Shared.Models;
using DndServer.Domain.Shared;
using Microsoft.AspNetCore.Http;

namespace DndServer.Application.Shared;

public class UploadService : IUploadService
{
    private readonly string[] _acceptedFileTypes = { ".jpg", ".jpeg", ".png" };
    private readonly string _uploadsPath = AppDomain.CurrentDomain.BaseDirectory + "\\files";

    private readonly IUnitOfWork _unitOfWork;
    private readonly IUploadRepository _uploadRepository;

    public UploadService(IUnitOfWork unitOfWork, IUploadRepository uploadRepository)
    {
        _unitOfWork = unitOfWork;
        _uploadRepository = uploadRepository;
    }

    public Task<int> UploadImage(IFormFile upload)
    {
        if (upload.Length == 0)
        {
            throw new Exception();
        }

        // TODO: Move max file size to config
        if (upload.Length > 10 * 1024 * 1024)
        {
            throw new Exception();
        }

        if (_acceptedFileTypes.All(s => s != Path.GetExtension(upload.FileName)?.ToLower()))
        {
            throw new Exception();
        }

        if (!Directory.Exists(_uploadsPath))
        {
            Directory.CreateDirectory(_uploadsPath);
        }

        var fileId = Guid.NewGuid();
        var fileName = fileId + Path.GetExtension(upload.FileName);
        var filePath = Path.Combine(_uploadsPath, fileName);
        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            upload.CopyTo(stream);
        }

        var uploadedFile = new Image(fileName);
        _uploadRepository.Create(uploadedFile);
        _unitOfWork.SaveChanges();

        var id = _uploadRepository.Get(x => x.Path == fileName).FirstOrDefault();

        if (id == null)
        {
            throw new Exception();
        }

        return Task.FromResult(id.Id);
    }

    public (string path, UploadedFile file) GetImage(int fileId)
    {
        var file = _uploadRepository.Get(x => x.Id == fileId).FirstOrDefault();
        if (file == null)
        {
            throw new Exception();
        }

        var image = new UploadedFile
        {
            Id = file.Id,
            FileName = file.Path
        };

        var physicalPath = Path.Combine(_uploadsPath, image.FileName);
        return (physicalPath, image);
    }
}