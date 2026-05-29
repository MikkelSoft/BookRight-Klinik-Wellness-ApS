using System;

namespace BookSoft.Facade.DTOs
{
    /// <summary>
    /// Data needed to register a new clinic.
    /// Clinics only have a name for now — practitioners are linked to clinics
    /// separately through their own relationships.
    /// </summary>
    public record AddClinicRequest(
        string ClinicName
    );
}
