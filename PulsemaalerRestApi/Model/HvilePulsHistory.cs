
using System.ComponentModel.DataAnnotations;

namespace PulsemaalerRestApi.Model

{
    public class HvilePulsHistory
    {
        [Key]
        public int HistoryId { get; set; }
        public int PersonId { get; set; }
        public int HvilePuls { get; set; }
        public DateTime RecordTime{ get; set; }

      
    }
}
