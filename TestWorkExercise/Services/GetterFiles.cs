namespace TestWorkExercise.Services;

public static  class GetterFiles
{
   
    public static List<File> NavigateToPath(string path)
    {
        var ListofFiles = new List<File>();
        
        if (path.IsDirectory())
        {
            ListofFiles.Clear();

            foreach (var dir in DownloaderFiles.GetDirectories(path))
            {
                ListofFiles.Add(dir);
            }
            foreach (var file in DownloaderFiles.GetFiles(path))
            {

                ListofFiles.Add(file);
            }
        }
        return ListofFiles;
    }
    
}
