namespace TestWorkExercise.Services;

internal class FinderDirectory
{
    public string GetTargetFolder(string FileName)
    {
        string? pathDirectory = Path.GetDirectoryName(FileName);
        string? fileName = Path.GetFileName(FileName);

        Shell shell = new();
        Folder folder = shell.NameSpace(pathDirectory);
        FolderItem folderItem = folder.ParseName(fileName);

        if (folderItem is null)
            return string.Empty;

        ShellLinkObject? shellLinkObject = folderItem.GetLink as ShellLinkObject;

        return shellLinkObject.Path;
    }
}
