﻿namespace FileTypeChecker.Web.Attributes
{
    using FileTypeChecker.Extensions;
    using FileTypeChecker.Types;
    using Microsoft.AspNetCore.Http;
    using System.ComponentModel.DataAnnotations;
    using System.IO;

    public class ForbidExecutableFileAttribute : FileTypeValidationBaseAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!(value is IFormFile file))
            {
                return ValidationResult.Success;
            }

            using var stream = new MemoryStream();
            file.CopyTo(stream);

            if (!FileTypeValidator.IsTypeRecognizable(stream))
            {
                return new ValidationResult(this.UnsupportedFileErrorMessage);
            }

            if (stream.Is<Executable>() || stream.Is<ExecutableAndLinkableFormat>())
            {
                return new ValidationResult(this.ErrorMessage ?? this.InvalidFileTypeErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}