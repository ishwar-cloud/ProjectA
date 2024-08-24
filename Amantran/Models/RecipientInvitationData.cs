using Infrastructure.DataContext;

namespace Amantran.Models
{
    public class RecipientInvitationData
    {
        public int RecipientId { get; set; }
        public int FunctionId { get; set; }
        public bool IsOnlyGents { get; set; }
        public bool IsWholeFamily { get; set; }
        public bool IsWedding { get; set; }
        public bool IsGaval { get; set; }
        public bool IsHalad { get; set; }
        public bool IsOvalane { get; set; }
        public bool IsReception { get; set; }
        public bool IsMehandi { get; set; }
        public bool IsSangit { get; set; }
        public int InvitedById { get; set; }
        public int w_cardId { get; set; }
        public int w_videoId { get; set; }

        public int invitationId { get; set; }

        public string mediaType { get; set; }
    }

}
