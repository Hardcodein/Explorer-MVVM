namespace TestWorkExercise.Abstractions;

public abstract partial   class BaseViewModel :ObservableObject
{
    [ObservableProperty]
    private  ObservableCollection<File>? filesAndDirectories = [];
    public virtual void NavigateToPath(string path)
    {
        if (path.IsFile())
        {

        }
        else if (path.IsDirectory())
        {
            ClearFiles();

            foreach (var dir in Fetcher.GetDirectories(path))
            {
                AddFile(dir);
            }
            foreach (var file in Fetcher.GetFiles(path))
            {

                AddFile(file);
            }
        }
    }
    public  virtual void AddFile(File file)
    {
        FilesAndDirectories?.Add(file);
    }

    public virtual void RemoveFile(File file)
    {
        FilesAndDirectories?.Remove(file);
    }

    public virtual void ClearFiles()
    {
        FilesAndDirectories?.Clear();
    }
}
