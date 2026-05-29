# BookRight – Klinik & Wellness ApS

Skoleprojekt lavet som en del af datamatikeruddannelsen. Systemet er et booking- og administrationssystem til klinikker og wellnesscentre. Man kan oprette patienter, behandlere og klinikker, booke aftaler, lave kampagner og se økonomi i et pænt dashboard.

---

## Hvad kan det?

- **Patienter** – opret, rediger og slet patienter med søgefunktion
- **Behandlere** – samme layout som patienter, men med speciale og autorisationstype
- **Klinikker** – simpel liste over klinikker og hvor mange behandlere der er tilknyttet
- **Aftaler** – kalender (måned/uge/dag) hvor man kan booke, afslutte og aflyse aftaler
- **Kampagner** – kalenderbaseret kampagneoverblik med mulighed for at oprette rabatkampagner pr. behandlingstype
- **Økonomi** – bento-dashboard med ApexCharts: omsætning, aftalestatus, top patienter og behandlingstyper

Der er også en automatisk rabatmotor bygget med **Strategy Pattern** der håndterer loyalitetsrabatter (bronze/sølv/guld), fødselsdagsrabatter og kampagnerabatter.

---

## Arkitektur

Projektet følger **Clean Architecture** og er delt op i lag:

```
BookSoft.Domain          → Entiteter, enums, value objects og rabatstrategier
BookSoft.Facade          → DTOs og interfaces (kontrakter til UI og use cases)
BookSoft.UseCases        → Implementering af use cases (skriveoperationer)
BookSoft.Infrastructure  → EF Core, repositories og query handlers (læseoperationer)
BookSoft.Blazor          → Blazor Server frontend (pages, form-komponenter, layout)
BookSoft.Api             → Minimal REST API (ikke primært brugt i UI)
```

UI-laget kender kun til `BookSoft.Facade` – det ved intet om EF Core eller databasen direkte. Skrivninger går igennem **use cases**, og læsninger går igennem lette **query handlers** med `AsNoTracking`.

---

## Teknologier

| Hvad | Teknologi |
|---|---|
| Frontend | ASP.NET Core 10 Blazor Server |
| Grafer | Blazor-ApexCharts 6.1.0 |
| Database-adgang | Entity Framework Core 10 |
| Database | SQL Server LocalDB |
| Sprog | C# / .NET 10 |
| Tests | xUnit |

---

## Kom i gang

### Krav
- .NET 10 SDK installeret
- SQL Server LocalDB (følger med Visual Studio)

### 1. Klon projektet
```bash
git clone <repo-url>
cd BookRight-Klinik-Wellness-ApS
```

### 2. Kør migrationen
```bash
cd src/BookSoft.Blazor
dotnet ef database update
```

Det opretter databasen `BookSoftDB` på din lokale LocalDB-instans.

### 3. Start applikationen
```bash
dotnet run --project src/BookSoft.Blazor
```

Åbn `https://localhost:<port>` i browseren.

---

## Mappestruktur

```
src/
├── BookSoft.Domain/
│   ├── Entities/          # Patient, Practitioner, Clinic, Appointment, Transaction, Campaign
│   ├── Enums/             # AppointmentType, AppointmentStatus, AutorisationsType, LoyaltyLevel
│   ├── ValueObjects/      # FullName
│   ├── Rabatter/          # RabatService + strategier (Strategy Pattern)
│   └── Exceptions/        # DomainException, NotFoundException
│
├── BookSoft.Facade/
│   ├── DTOs/              # Read-only records til UI-laget
│   ├── Queries/           # IPatientQueries, IPractitionerQueries osv.
│   └── UseCases/          # IAddPatientUseCase, ICreateNewAppointmentUseCase osv.
│
├── BookSoft.UseCases/     # Konkrete use case-implementeringer
├── BookSoft.Infrastructure/
│   ├── Data/              # BookSoftDbContext + EF-migrationer
│   ├── Repositories/      # EF Core repositories
│   └── QueryHandlers/     # Læseside-implementeringer
│
└── BookSoft.Blazor/
    ├── Components/
    │   ├── Pages/         # Patients, Practitioners, Clinics, Appointment, Campaigns, Financials
    │   ├── Forms/         # AddPatient, AddPractiotioner, AddClinic,
    │   │                  #   AddAppointment, AppointmentDetail, AddCampaign
    │   └── Layout/        # NavMenu, MainLayout
    └── wwwroot/app.css    # Globale styles (modal, knapper, liste-layout, kalender)

tests/
├── BookSoft.Domain.Tests/
└── BookSoft.UseCases.Tests/
```

---

## Connection string

Ligger i `src/BookSoft.Blazor/appsettings.json`:

```json
"ConnectionStrings": {
  "Default": "Server=(localdb)\\MSSQLLocalDB;Database=BookSoftDB;Trusted_Connection=True;TrustServerCertificate=True"
}
```

---

## Tests

```bash
dotnet test
```
