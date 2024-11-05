namespace TestWorkExercise.Controls.ViewModels;

internal partial class FileViewModel : BaseViewModel
{   

    [ObservableProperty]
    private string? _name;
    [ObservableProperty]
    private string? _extension;
    [ObservableProperty]
    private float _size; 
    public FileViewModel(File file)
    {
        Name = file.Name;
        Extension = file.Extension;
        Size = file.Size;
    }
}
