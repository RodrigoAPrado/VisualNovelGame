using System;
using System.IO;
using UnityEngine;
using Csharp.Enum;

namespace Csharp.Util
{
    public static class FileReaderUtil
    {
        private const bool IsEncrypted = false;
        private const string ResourcesPath = "Assets/Resources/";
        private const string DefaultPath = "Default/";
        private const string CustomPath = "Custom/";
        
        public static string ReadFile(string filePath, string fileName)
        {
            return IsEncrypted ? ReadFileEncrypted(filePath, fileName) : ReadFileNotEncrypted(filePath, fileName);
        }

        public static string ReadFile(string filePath, string fileName, FilePathType filePathType) {
            return IsEncrypted ? ReadFileEncrypted(filePath, fileName, filePathType) : ReadFileNotEncrypted(filePath, fileName, filePathType);    
        }

        private static string ReadFileEncrypted(string filePath, string fileName)
        {
            throw new NotImplementedException();
        }

        private static string ReadFileEncrypted(string filePath, string fileName, FilePathType filePathType)
        {
            throw new NotImplementedException();
        }

        private static string ReadFileNotEncrypted(string filePath, string fileName)
        {
            string fileText;
            
            try
            {
                fileText = File.ReadAllText(buildFilePath(filePath, fileName, FilePathType.Custom));
                Debug.Log($"Custom {fileName} file has been read.");
            }
            catch (IOException)
            {
                try{
                    Debug.Log($"Custom {fileName} file not found. Reading default.");
                    fileText = File.ReadAllText(buildFilePath(filePath, fileName, FilePathType.Default));
                } catch(IOException e) {
                    Debug.Log(e);
                    Debug.Log($"Default {fileName} file not found. Returning empty.");  
                    fileText = ""; 
                }
                
            }
            return fileText;
        }
        private static string ReadFileNotEncrypted(string filePath, string fileName, FilePathType filePathType) 
        {
            string fileText;

            try 
            { 
                fileText = File.ReadAllText(buildFilePath(filePath, fileName, FilePathType.Absolute));
                Debug.Log($"Custom {fileName} file has been read.");
            } catch (IOException e) {
                throw new Exception($"File named {fileName} with specified path {filePath} was not found.");
            }    

            return fileText;
        }

        private static string buildFilePath(string filePath, string fileName, FilePathType filePathType) {
            switch(filePathType) {
                case FilePathType.Default:
                    return string.Concat(ResourcesPath, filePath, DefaultPath, fileName);
                case FilePathType.Custom:
                    return string.Concat(ResourcesPath, filePath, CustomPath, fileName);
                case FilePathType.Absolute:
                    return string.Concat(ResourcesPath, filePath, fileName);
                default:
                    throw new Exception($"Unknown file path type {filePathType.ToString()}");
            }
        }
    }
}