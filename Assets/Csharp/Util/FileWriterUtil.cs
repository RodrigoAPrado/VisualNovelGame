using System;
using System.IO;
using UnityEngine;

namespace Csharp.Util
{
    public class FileWriterUtil
    {
        private const bool IsEncrypted = false;
        private const string ResourcesPath = "Assets/Resources/";
        private const string CustomPath = "Custom/";

        public static void WriteFile(string filePath, string fileName, string fileContent)
        {
            if (IsEncrypted)
            {
                WriteFileEncrypted(filePath, fileName, fileContent);
            }
            else
            {
                WriteFileNotEncrypted(filePath, fileName, fileContent);
            }
        }

        private static void WriteFileEncrypted(string filePath, string fileName, string fileContent)
        {
            throw new NotImplementedException();
        }

        private static void WriteFileNotEncrypted(string filePath, string fileName, string fileContent)
        {
            try
            {
                File.WriteAllText(ResourcesPath + filePath + CustomPath + fileName, fileContent);
                Debug.Log($"File {fileName} saved successfuly");
            }
            catch (IOException e)
            {
                Debug.Log(e.Message);
            }
        }
    }
}