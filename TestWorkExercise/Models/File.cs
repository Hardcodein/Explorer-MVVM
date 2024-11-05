namespace TestWorkExercise.Models;
internal class File : DataUnitBase
{
    public string? Extension { get; set; }
    public float Size { get; set; }
    public string? Path { get; internal set; }
}
