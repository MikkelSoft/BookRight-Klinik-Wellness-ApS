namespace BookSoft.Domain.Enums
{
    /// <summary>
    /// Alle behandlingstyper BookRight tilbyder.
    /// Hvert enum-værdis navn bruges som string nøgle når UI opretter en booking.
    /// Prisen og varighed beregnes fra typen i Appointment-entiteten.
    /// </summary>
    public enum AppointmentTypeEnum
    {
        // Fysioterapi — tre varigheder med stigende pris
        Fysioterapi30Min = 0,   // 395 kr
        Fysioterapi45Min = 1,   // 589 kr
        Fysioterapi60Min = 2,   // 745 kr

        // Sportsmassage — to varigheder
        Sportsmassage30Min = 3, // 350 kr
        Sportsmassage60Min = 4, // 699 kr

        // Akupunktur — fast varighed
        Akupunktur45Min = 5,    // 550 kr

        // Kostvejledning — forskellig pris for første og opfølgning
        KostvejledningFoerste = 6,      // 799 kr, 60 min (første konsultation)
        KostvejledningOpfoelgning = 7,  // 450 kr, 30 min (opfølgning)

        // Holdtræning — pris pr. deltager, max 6 deltagere
        Holdtraening60Min = 8   // 150 kr pr. deltager
    }
}
