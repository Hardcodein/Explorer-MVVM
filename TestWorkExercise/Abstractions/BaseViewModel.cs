namespace TestWorkExercise.Abstractions;

internal abstract  partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    internal ObservableCollection<File>? filesAndDirectories = [];
}
