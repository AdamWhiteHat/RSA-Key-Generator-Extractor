using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CertificateKeyGenerator
{
    public class FileDialogs
    {
        private class SaveLastDirectory
        {
            public string LastBrowseDirectory { get; set; }
            public string LastSaveDirectory { get; set; }
            public string LastOpenDirectory { get; set; }
        }

        private static SaveLastDirectory Save = new SaveLastDirectory();
        private static string DefaultFileName = "PrivateKeys.{0}.Output.txt";

        public static string BrowseDialog()
        {
            using (FolderBrowserDialog browseForFolder = new FolderBrowserDialog())
            {
                browseForFolder.Description = "Select search folder";
                browseForFolder.RootFolder = Environment.SpecialFolder.MyComputer;
                browseForFolder.SelectedPath = Save.LastBrowseDirectory;
                if (browseForFolder.ShowDialog() == DialogResult.OK)
                {
                    Save.LastBrowseDirectory = browseForFolder.SelectedPath;
                    return browseForFolder.SelectedPath;
                }
            }
            return null;
        }

        public static string SaveDialog()
        {
            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Select output file";
                saveDialog.OverwritePrompt = false;
                saveDialog.InitialDirectory = Save.LastSaveDirectory;
                saveDialog.FileName = string.Format(DefaultFileName, (DateTime.UtcNow.Ticks % 997));
                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    Save.LastSaveDirectory = Path.GetDirectoryName(saveDialog.FileName);
                    return saveDialog.FileName;
                }
            }
            return null;
        }

        public static string OpenDialog()
        {
            using (OpenFileDialog openDialog = new OpenFileDialog())
            {
                openDialog.Title = "Select file to open";
                openDialog.InitialDirectory = Save.LastOpenDirectory;
                if (openDialog.ShowDialog() == DialogResult.OK)
                {
                    Save.LastOpenDirectory = Path.GetDirectoryName(openDialog.FileName);
                    return openDialog.FileName;
                }
            }
            return null;
        }
    }
}
