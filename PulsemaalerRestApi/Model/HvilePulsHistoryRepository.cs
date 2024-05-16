namespace PulsemaalerRestApi.Model
{
    public class HvilePulsHistoryRepository
    {
        private readonly PersonDbContext _context;

        public HvilePulsHistoryRepository(PersonDbContext context)
        {
            _context = context;
        }
        public IEnumerable<HvilePulsHistory> GetAll()
        {
            IQueryable<HvilePulsHistory> queryable = _context.HvilePulsHistorys.AsQueryable();
            return queryable.ToList();
        }
        public IEnumerable<HvilePulsHistory> GetByPersonId(int personId)
        {
            return _context.HvilePulsHistorys.Where(h => h.PersonId == personId).ToList();
        }

        public void Add(HvilePulsHistory history)
        {
            _context.HvilePulsHistorys.Add(history);
            _context.SaveChanges();
        }

        public void Delete(int historyId)
        {
            var history = _context.HvilePulsHistorys.Find(historyId);
            if (history != null)
            {
                _context.HvilePulsHistorys.Remove(history);
                _context.SaveChanges();
            }
        }

        public void Update(HvilePulsHistory history)
        {
            var existingHistory = _context.HvilePulsHistorys.Find(history.HistoryId);
            if (existingHistory != null)
            {
                existingHistory.PersonId = history.PersonId;
                existingHistory.HvilePuls = history.HvilePuls;
                existingHistory.RecordTime = history.RecordTime;

                _context.HvilePulsHistorys.Update(existingHistory);
                _context.SaveChanges();
            }
        }
    }
}

