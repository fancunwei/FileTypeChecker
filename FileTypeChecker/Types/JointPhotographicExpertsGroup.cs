﻿namespace FileTypeChecker.Types
{
    using FileTypeChecker.Abstracts;

    public class JointPhotographicExpertsGroup : FileType, IFileType
    {
        public const string TypeName = "JPEG";
        public const string TypeExtension = "jpg";
        private static readonly byte[] magicBytes = new byte[] { 0xFF, 0xD8, 0xFF };

        public JointPhotographicExpertsGroup() : base(TypeName, TypeExtension, magicBytes)
        {
        }
    }
}
