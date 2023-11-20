using DataBaseForms;

internal static class FormsHelper
{
    static public DataBase DataBase = new DataBase("Server=127.0.0.1;Database=db22205;" +
        "TrustServerCertificate=true;User Id=user053;Password=User053#!31;");

    public static string[] SelectedArtistData = new string[5] { "", "", "", "", "" };

    public static List<Concert> SelectedArtistConcerts = new List<Concert>();
}