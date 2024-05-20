﻿using DndServer.Application.Shared.Models;
using Microsoft.AspNetCore.Http;

namespace DndServer.Application.Shared.Interfaces;

public interface IUploadService
{
    public (byte[] bytes, UploadedFile file) GetImage(int fileId);
    public Task<int> UploadImage(IFormFile upload);
}