
namespace TestWorkExercise.Controls.ViewModelsControl;

public partial class FilePropertyBlockViewModel : ObservableObject
{   

    [ObservableProperty]
    private string? _name;

    [ObservableProperty]
    private string? _extension;

    [ObservableProperty]
    private float _size;

    
    public FilePropertyBlockViewModel(File file)
    {
        Name = file.Name;
        Extension = file.Extension;
        Size = file.Size;
        
    }
}
