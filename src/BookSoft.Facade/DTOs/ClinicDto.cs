using System;

namespace BookSoft.Facade.DTOs
{
    /// <summary>
    /// Read-only snapshot of a Clinic for display in the UI.
    /// PractitionerCount is a convenience property so the list page
    /// can show "3 practitioners" without the UI loading each clinic's
    /// full practitioners collection.
    /// </summary>
    public record ClinicDto(
        Guid Id,
        string ClinicName,
        int PractitionerCount  // number of practitioners currently assigned to this clinic
    );
}
