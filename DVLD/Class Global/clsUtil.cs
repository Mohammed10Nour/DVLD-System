using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Class_Global
{
    internal class clsUtil
    {
        private static bool _IsFolderExist(string FolderPath)
        {
            try
            {
                if (!Directory.Exists(FolderPath))
                {
                    return false;
                }
            }
            catch (IOException Iox)
            {
                MessageBox.Show(Iox.Message);
            }
            return true;
        }
        private static void _CreateNewFolder(string FolderPath)
        {
            try
            {
                Directory.CreateDirectory(FolderPath);
            }

            catch (IOException Iox)
            {
                MessageBox.Show(Iox.Message);
            }
            
        }
        private static string NewGuid()
        {
            Guid newGuid = Guid.NewGuid();
            return newGuid.ToString();
        }
        private static string _RenameImage(string SourceImagePath)
        {
            FileInfo fi = new FileInfo(SourceImagePath);
            string ex = fi.Extension;
            return ex + NewGuid();
        }
        public static bool CopyImageToTheFolder(ref string SourceImagePath)
        {
            string DestinationFolder = @"C:\DVLD-People-Images\";
            if (!_IsFolderExist (DestinationFolder ))
            {
                _CreateNewFolder(DestinationFolder);
            }
            string DestinationFile = DestinationFolder + _RenameImage(SourceImagePath);
            try
            {
                File.Copy(SourceImagePath, DestinationFile, true);
            }
            catch(IOException Iox)
            {
                MessageBox.Show(Iox.Message);
            }
            SourceImagePath = DestinationFile;
            return true;
        }
    }
}
