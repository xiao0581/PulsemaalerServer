
using System.ComponentModel.DataAnnotations;

namespace PulsemaalerRestApi.Model

{
    public class PulsHistory
    {
        [Key]
        public int HistoryId { get; set; }
        public int PersonId { get; set; }
        public int HvilePuls { get; set; }
        public int AktivPuls { get; set; }
        public int Stresspuls { get; set; }
        public int AfterTrainingPuls { get; set; }

        public DateTime RecordTime{ get; set; }

      
    }
}
