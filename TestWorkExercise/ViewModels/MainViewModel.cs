
namespace TestWorkExercise.ViewModels;

public partial class MainViewModel : ObservableObject
{
    [ObservableProperty]
    private string? filePath;

    [ObservableProperty]
    private File? selectedFile;

    [ObservableProperty]
    private object? selectedViewModel;

    [ObservableProperty]
    public ObservableCollection<File>? filesAndDirectories;
    public MainViewModel()
    { 
    }

    [RelayCommand]
    public void SelectionChanged(File file)
    {
        if (file.IsFile)
            SelectedViewModel = new FilePropertyBlockViewModel(file);
        if (file.IsDirectory)
            SelectedViewModel = new DirectoryPropertyBlockViewModel(file);
    }

    [RelayCommand]
    public void FilePathChanged(string filePath)
    {
        FilePath = filePath;
        FilesAndDirectories = new ObservableCollection<File>(GetterFiles.NavigateToPath(FilePath!));
    }
    [RelayCommand]
    public void OpenFile(File file)
    {
        if (Constants.AllowedFilesToOpen.Contains(file.Extension!))
        {
            Process.Start("notepad.exe", file!.Path!);
        }

    }
}
