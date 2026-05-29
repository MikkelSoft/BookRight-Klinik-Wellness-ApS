namespace BookSoft.Domain.Enums
{
    /// <summary>
    /// Typen af autorisastion en behandler har.
    /// Autorisationstypen styrer hvilke behandlinger behandleren må udføre.
    /// </summary>
    public enum AutorisationsTypeEnum
    {
        Fysioterapeut = 0,  // kan udføre Fysioterapi og Holdtræning
        Massoer = 1,        // kan udføre Sportsmassage
        Akupunktoer = 2,    // kan udføre Akupunktur
        Kostvejleder = 3    // kan udføre Kostvejledning
    }
}
