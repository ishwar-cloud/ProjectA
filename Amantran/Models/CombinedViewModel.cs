namespace Amantran.Models
{
    public class CombinedViewModel
    {
        public InvitaionSelectionModel InvitaionSelectionModel { get; set; }
        public List<Recipient> Recipients { get; set; }
        public List<InvitedBy> InvitedBies { get; set; }
    }
}
