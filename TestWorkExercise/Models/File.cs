
namespace TestWorkExercise.Models;

public class File
{
    

    public string? Name { get; set; }
    public string? Extension { get; set; }

    public float Size { get; set; }
    public string? Path { get; internal set; }
    public TypeFile Type { get; set; }

    public bool IsFile => Type == TypeFile.File;
    public bool IsDirectory => Type == TypeFile.Directory;
}
