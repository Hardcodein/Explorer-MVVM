namespace TestWorkExercise.Services;

internal class LoaderUnitDataFromComputer
{
    private readonly FinderDirectory finderDirectory;

    public LoaderUnitDataFromComputer()
    {
        finderDirectory = new FinderDirectory();
    }
    public List<File> GetFiles(string directoryPath)
    {
        List<File> filesinDirectory = [];

        if (!Directory.Exists(directoryPath))
            return filesinDirectory;

        foreach (var fileName in Directory.GetFiles(directoryPath)
            .Where(fileName => Path.GetExtension(fileName) != ".lnk"))
        {
            FileInfo fileInfo = new(fileName);

            File fileModel = new()
            {
                Name = Path.GetFileNameWithoutExtension(fileInfo.FullName),

                Path = fileInfo.FullName,

                Extension = fileInfo.Extension,

                Size = (float)Math.Round(fileInfo.Length / 1024f, 2),

                Type = DataTypes.File

            };
            filesinDirectory.Add(fileModel);
        }

        return filesinDirectory;
    }

    public List<File> GetDirectories(string directoryPath)
    {
        List<File> directoriesAndFiles = [];

        if (!Directory.Exists(directoryPath))
            return directoriesAndFiles;
        try
        {
            foreach (var directory in Directory.GetDirectories(directoryPath)
                .Where(directory => Path.GetExtension(directory) != ".lnk"))
            {

                DirectoryInfo fileInfo = new(directory);
                File fileModel = new()
                {
                    Name = Path.GetFileNameWithoutExtension(fileInfo.FullName),
                    Path = fileInfo.FullName,
                    Extension = fileInfo.Extension,
                    Type = DataTypes.Directory
                };

                directoriesAndFiles.Add(fileModel);

            }

            foreach (string itemFile in Directory.GetFiles(directoryPath)
                .Where(directory => Path.GetExtension(directory) != ".lnk"))
            {

                string realDirectoryPath = finderDirectory.GetTargetFolder(itemFile);

                FileInfo fileInfo = new(realDirectoryPath);

                File dModel = new()
                {
                    Name = fileInfo.Name,

                    Path = fileInfo.FullName,

                    Extension = fileInfo.Extension,

                    Size = fileInfo.Length,

                    Type = DataTypes.File
                };

                directoriesAndFiles.Add(dModel);

            }
        }
        catch (NotImplementedException)
        {
            //Косяк Проекта
        }

        return directoriesAndFiles;
    }

}
