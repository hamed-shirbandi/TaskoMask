namespace TaskoMask.BuildingBlocks.Test.TestData;

public static class TestDataGenerator
{
    private static readonly Random _random = new();
    private const string CHARS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    private const string ALPHABETS = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

    /// <summary>
    ///
    /// </summary>
    public static string GetRandomName(int length)
    {
        return new string(Enumerable.Repeat(ALPHABETS, length).Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    /// <summary>
    ///
    /// </summary>
    public static string GetRandomEmail()
    {
        return $"{GetRandomName(10)}@taskomask.ir";
    }

    /// <summary>
    ///
    /// </summary>
    public static string GetRandomString(int length)
    {
        return new string(Enumerable.Repeat(CHARS, length).Select(s => s[_random.Next(s.Length)]).ToArray());
    }
}
