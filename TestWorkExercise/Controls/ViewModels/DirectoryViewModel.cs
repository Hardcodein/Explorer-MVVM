namespace TestWorkExercise.Controls.ViewModels;

internal partial class DirectoryViewModel :BaseViewModel
{    
    public DirectoryViewModel(File file)
    {
        var getterAllData = new GetterAllData();
        FilesAndDirectories = new ObservableCollection<File> (getterAllData.GetAllDataInDirectory(file!.Path!));  
    }
}
