using System;

namespace Core.Application.DTO
{
    public record DocumentDTO
    (
        Guid Id,
        Guid? LandTitleId,
        string FileName,
        string ContentType,
        long Size,
        DateTimeOffset UploadedAt,
        string Description
    );
}
