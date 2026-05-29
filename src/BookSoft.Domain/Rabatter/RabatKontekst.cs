using BookSoft.Domain.Entities;
using BookSoft.Domain.Enums;

namespace BookSoft.Domain.Rabatter
{
    // alt det en rabat strategi skal bruge for at beregne rabatten
    public record RabatKontekst(
        Patient Patient,
        AppointmentTypeEnum BehandlingsType,
        decimal BasisPris,
        DateTime BookingDato,
        IReadOnlyList<Campaign> AktiveKampagner
    );
}
