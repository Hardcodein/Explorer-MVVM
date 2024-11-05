namespace TestWorkExercise.Services;

internal class GetterAllData
{
    private readonly LoaderUnitDataFromComputer loaderDataFromComputer;
    public GetterAllData()
    {
            loaderDataFromComputer = new LoaderUnitDataFromComputer();
    }

    internal List<File> GetAllDataInDirectory(string path)
    {
        List<File> DataUnitList = new List<File>();

        if (!Directory.Exists(path))
            return DataUnitList ;
        
        DataUnitList.AddRange(loaderDataFromComputer.GetDirectories(path));
        DataUnitList.AddRange(loaderDataFromComputer.GetFiles(path));

        return DataUnitList;
    }
}
