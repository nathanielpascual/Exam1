using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
namespace ExamWH.Controllers
{
    public class FileHandler
    {
        public StreamReader ExtractFile(string path)
        {
            return new StreamReader(File.OpenRead(path));
        }
    }
}