namespace BG3Builds.Shared.Enums;

public enum ImageDirectory
{
    Classes = 1,
    Equipments = 2,
    Spells = 3
}

public static class ImageDirectoryHelper
{
    public static string GetImageDirectoryName(ImageDirectory imageDirectory)
        => imageDirectory switch
        {
            ImageDirectory.Classes => "classes",
            ImageDirectory.Equipments => "equipments",
            ImageDirectory.Spells => "spells",
            _ => throw new ArgumentOutOfRangeException(nameof(imageDirectory), imageDirectory, null)
        };
}