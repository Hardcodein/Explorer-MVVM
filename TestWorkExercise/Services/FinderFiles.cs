

using Shell32;

namespace TestWorkExercise;

 public static class FinderFiles
{
    public static bool IsFile(this string path)
    {
        return !string.IsNullOrEmpty(path) && System.IO.File.Exists(path);
    }

    public static bool IsDirectory(this string path)
    {
        return !string.IsNullOrEmpty(path) && System.IO.Directory.Exists(path);
    }
    public static string GetTargetFolder(string FileName)
    {
        
            string? path = System.IO.Path.GetDirectoryName(FileName);
            string? fileName = System.IO.Path.GetFileName(FileName);

            Shell shell = new Shell();
            Folder folder = shell.NameSpace(path);
            FolderItem folderItem = folder.ParseName(fileName);
            if (folderItem != null)
            {
                ShellLinkObject shellLinkObject = (ShellLinkObject)folderItem.GetLink;
                return shellLinkObject.Path;

            }
            
        
        
        
        

        return string.Empty ;
    }
}
