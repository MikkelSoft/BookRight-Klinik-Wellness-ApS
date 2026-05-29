using BookSoft.Domain.Rabatter.Strategier;

namespace BookSoft.Domain.Rabatter
{
    // kører alle rabat strategier og returnere den bedste (laveste pris)
    // bruger Parallel.ForEach fordi beregningerne er cpu-bound og uafhængige af hinanden
    public class RabatService
    {
        private readonly IReadOnlyList<IRabatBeregner> _strategier;

        public RabatService(IEnumerable<IRabatBeregner> strategier)
        {
            _strategier = strategier.ToList();
        }

        public (decimal EndeligPris, string? AnvendtRabatType) BeregnBedsteRabat(RabatKontekst kontekst)
        {
            var resultater = new System.Collections.Concurrent.ConcurrentBag<RabatResultat>();

            // kører alle strategier parallelt - trådsikker fordi vi bruger ConcurrentBag
            Parallel.ForEach(_strategier, strategi =>
            {
                var resultat = strategi.BeregnRabat(kontekst);
                if (resultat is not null)
                    resultater.Add(resultat);
            });

            // tag den strategi der giver den laveste pris
            var bedste = resultater.OrderBy(r => r.PrisEfterRabat).FirstOrDefault();

            return bedste is null
                ? (kontekst.BasisPris, null)
                : (bedste.PrisEfterRabat, bedste.RabatType);
        }
    }
}
