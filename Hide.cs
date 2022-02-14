using System;
using System.IO;

namespace HideFiles
{
    internal class Program
    {
        static void Main(string[] argomenti)
        {
            int fileNascosti = 0, directoryNascoste = 0;

            for (int i = 0; i < argomenti.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(argomenti[i]);
                if (directory.Exists)
                {
                    FileInfo[] fleInfo = directory.GetFiles();

                    for (int FLE = 0; FLE < fleInfo.Length; FLE++)
                    {
                        if (fleInfo[FLE].Name.StartsWith('.'))
                        {
                            fleInfo[FLE].Attributes |= FileAttributes.Hidden;
                            fileNascosti++;
                        }
                    }

                    DirectoryInfo[] dirInfo = directory.GetDirectories();

                    for (int DIR = 0; DIR < dirInfo.Length; DIR++)
                    {
                        if (dirInfo[DIR].Name.StartsWith('.'))
                        {
                            dirInfo[DIR].Attributes |= FileAttributes.Hidden;
                            directoryNascoste++;
                        }
                    }
                }

                Console.WriteLine("Nascosti " + fileNascosti + " file e " + directoryNascoste
                    + " directory nella cartella \"" + argomenti[i] + '\"');
            }
        }
    }
}
