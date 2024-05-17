namespace PulsemaalerRestApi.Model
{
    public class PulsHistoryRepository
    {
        private readonly PersonDbContext _context;

        public PulsHistoryRepository(PersonDbContext context)
        {
            _context = context;
        }
        public IEnumerable<PulsHistory> GetAll()
        {
            IQueryable<PulsHistory> queryable = _context.PulsHistorys.AsQueryable();
            return queryable.ToList();
        }
        public IEnumerable<PulsHistory> GetByPersonId(int personId)
        {
            return _context.PulsHistorys.Where(h => h.PersonId == personId).ToList();
        }

        public PulsHistory Add(PulsHistory history)
        {
            _context.PulsHistorys.Add(history);
            _context.SaveChanges();
            return history;
        }

        public PulsHistory Delete(int historyId)
        {
            var history = _context.PulsHistorys.Find(historyId);
            if (history != null)
            {
                _context.PulsHistorys.Remove(history);
                _context.SaveChanges();
            }
            return history;
        }

        public PulsHistory Update(PulsHistory history)
        {
            var existingHistory = _context.PulsHistorys.Find(history.HistoryId);
            if (existingHistory != null)
            {
                existingHistory.PersonId = history.PersonId;
                existingHistory.HvilePuls = history.HvilePuls;
                existingHistory.RecordTime = history.RecordTime;

                _context.PulsHistorys.Update(existingHistory);
                _context.SaveChanges();
            }
            return existingHistory;
        }
      
    }
}

