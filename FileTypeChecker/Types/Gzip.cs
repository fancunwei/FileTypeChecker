﻿namespace FileTypeChecker.Types
{
    using FileTypeChecker.Abstracts;

    public class Gzip : FileType, IFileType
    {
        public const string TypeName = "GZIP compressed file";
        public const string TypeExtension = "gz";
        private static readonly byte[][] magicBytesJaggedArray = { new byte[] { 0x1F, 0x8B, 8 }, new byte[] { 0x75, 0x73, 0x74, 0x61, 0x72 } };

        public Gzip() : base(TypeName, TypeExtension, magicBytesJaggedArray)
        {
        }
    }
}
