namespace TestWorkExercise.ViewModels;

internal partial class MainViewModel : BaseViewModel
{
    [ObservableProperty]
    private string? filePath;

    [ObservableProperty]
    private File? selectedFile;

    [ObservableProperty]
    private BaseViewModel? selectedViewModel;
   

    [RelayCommand]
    internal void SelectionChanged(File file)
    {
        SelectedViewModel = file.Type switch
        {
            DataTypes.File => new FileViewModel(file),
            DataTypes.Directory => new DirectoryViewModel(file),
            _ => throw new InvalidOperationException("Не работает"),
        };
    }

    [RelayCommand]
    public void FilePathChanged(string filePath)
    {
        FilePath = filePath;
        var getterAllData = new GetterAllData();
        FilesAndDirectories = new ObservableCollection<File>(getterAllData.GetAllDataInDirectory(filePath));
    }


    [RelayCommand]
    internal void OpenFile(File file)
    {
        if (Constants.AllowedFilesToOpen.Contains(file.Extension!))
            Process.Start("notepad.exe", file!.Path!);
    }
}
