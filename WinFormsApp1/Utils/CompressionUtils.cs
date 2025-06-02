using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;

namespace Utils
{
    public static class CompressionUtils
    {
        /// <summary>
        /// Decompress all valid zlib blocks found in the byte stream and concatenate them.
        /// </summary>
        public static byte[] DecompressMultipleZlibBlocks(byte[] data)
        {
            var output = new MemoryStream();
            int blockCount = 0;

            for (int i = 0; i < data.Length - 2; i++)
            {
                if (data[i] == 0x78 && (data[i + 1] == 0x01 || data[i + 1] == 0x9C || data[i + 1] == 0xDA))
                {
                    try
                    {
                        byte[] decompressed = DecompressZlib(data, i);
                        if (decompressed.Length > 0)
                        {
                            output.Write(decompressed, 0, decompressed.Length);
                            blockCount++;
                        }

                        // Skip ahead to avoid reprocessing same block
                        i += 1;
                    }
                    catch
                    {
                        // Ignore failed block
                    }
                }
            }

            if (blockCount == 0)
                throw new InvalidDataException("No supported zlib block could be decompressed from the FastFile.");

            Console.WriteLine($"Decompressed {blockCount} zlib blocks.");
            return output.ToArray();
        }

        /// <summary>
        /// Decompress a single zlib block at a specific offset.
        /// </summary>
        public static byte[] DecompressZlib(byte[] input, int offset)
        {
            using var ms = new MemoryStream(input, offset, input.Length - offset);
            using var zlib = new ZLibStream(ms, CompressionMode.Decompress);
            using var result = new MemoryStream();
            zlib.CopyTo(result);
            return result.ToArray();
        }
    }
}
