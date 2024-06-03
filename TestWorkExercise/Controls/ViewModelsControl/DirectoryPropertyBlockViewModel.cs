
namespace TestWorkExercise.Controls.ViewModelsControl;

public partial class DirectoryPropertyBlockViewModel : ObservableObject   
{
    [ObservableProperty]
    public ObservableCollection<File> filesAndDirectories;

    public DirectoryPropertyBlockViewModel(File file)
    {
        FilesAndDirectories = new ObservableCollection<File> (GetterFiles.NavigateToPath(file!.Path!));
        
    }
}
