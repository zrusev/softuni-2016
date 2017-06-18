using System.IO;

namespace Problem_4.Copy_Binary
{
    using System;
    using System.Collections.Generic;

    public class Copy_Binary
    {
        public static void Main()
        {

            using (var source = new FileStream(@"..\..\file.bin", FileMode.Open))
            {
                using (var destination = new FileStream("result.bin", FileMode.Create))
                {
                    byte[] buffer = new byte[source.Length];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                        {
                            break;
                        }

                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}
