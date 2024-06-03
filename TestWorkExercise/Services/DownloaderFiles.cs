using TestWorkExercise.Properties;

namespace TestWorkExercise.Services;

public static class DownloaderFiles
{
    public static List<File> GetFiles(string directory)
    {
        List<File> files = [];

        if (!directory.IsDirectory())
            return files;

        string cuttrenfile = "";

        try
        {
            foreach (var itemFile in System.IO.Directory.GetFiles(directory))
            {
                cuttrenfile = itemFile;
                if (System.IO.Path.GetExtension(itemFile) != ".lnk")
                {
                    FileInfo fileInfo = new FileInfo(itemFile);
                    File fileModel = new File()
                    {
                        Name = System.IO.Path.GetFileNameWithoutExtension(fileInfo.FullName),
                        Path = fileInfo.FullName,
                        Extension = fileInfo.Extension,
                        Size = (float) Math.Round(fileInfo.Length / 1024f,2),
                        Type = TypeFile.File

                    };
                    files.Add(fileModel);
                }

            }
            
        }
        catch (UnauthorizedAccessException UAex)
        {
            MessageBox.Show($"{Resources.UnauthorizedAccess} {UAex.Source}");
        }
       
        catch (Exception ex)
        {
           MessageBox.Show(ex.Message);
        }
        return files;
    }
    public static List<File> GetDirectories(string directory)

    {
        List<File> directories = [];

        if (!directory.IsDirectory())
            return directories;

        string cuttrenfile = "";

        try
        {
            foreach (var itemDirectories in System.IO.Directory.GetDirectories(directory))
            {
                cuttrenfile = itemDirectories;
                if (System.IO.Path.GetExtension(itemDirectories) != ".lnk")
                {
                    DirectoryInfo fileInfo = new DirectoryInfo(itemDirectories);
                    File fileModel = new File()
                    {
                        Name = System.IO.Path.GetFileNameWithoutExtension(fileInfo.FullName),
                        Path = fileInfo.FullName,
                        Extension = fileInfo.Extension,
                        Type = TypeFile.Directory


                    };
                    directories.Add(fileModel);
                }

            }
            foreach (string itemFile in System.IO.Directory.GetFiles(directory))
            {
                if (System.IO.Path.GetExtension(itemFile) != ".lnk")
                {
                    string realDirPath = FinderFiles.GetTargetFolder(itemFile);
                    FileInfo fileInfo = new FileInfo(realDirPath);
                    File dModel = new File()
                    {

                        Name = fileInfo.Name,
                        Path = fileInfo.FullName,
                        Extension = fileInfo.Extension,
                        Size = fileInfo.Length,
                        Type = TypeFile.File
                    };

                    directories.Add(dModel);
                }
            }

        }
        catch (UnauthorizedAccessException UAex)
        {
            MessageBox.Show($"{Resources.UnauthorizedAccess} {UAex.Source}");
        }
        catch (NotImplementedException) 
        {
            //Вылазит это исключание, думал-думал не придумал
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        return directories;
    }

}
