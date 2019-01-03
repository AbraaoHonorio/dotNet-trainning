﻿using System.IO;
using System.IO.Compression;
using Microsoft.AspNetCore.ResponseCompression;

namespace TesteStore.Infra.Providers
{
    public class BrotliCompressionProvider : ICompressionProvider
    {
        public string EncodingName => "br";
        public bool SupportsFlush => true;

        public Stream CreateStream(Stream outputStream) => new BrotliStream(outputStream, CompressionLevel.Optimal, true);
    }
}
