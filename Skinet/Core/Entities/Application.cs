namespace Core.Entities
{
    public class Application : BaseEntity
    {
        public Guid ApplicantId { get; set; }
        public Nullable<bool> Agree { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> SubmittedAt { get; set; }
        public bool InviteEduQuest { get; set; }
        public bool Award { get; set; }
        public string ApplicantAwardStatus { get; set; }
        public Nullable<bool> AcceptOfferLetter { get; set; }
        public Nullable<System.DateTime> AcceptOfferLetterDate { get; set; }
        public Nullable<bool> CourierOfferLetter { get; set; }
        public bool IsRegistered { get; set; }
        public bool IsTransferredToESMS { get; set; }
        public string StatusId { get; set; }
        public System.DateTime InsAt { get; set; }
        public string InsBy { get; set; }
        public System.DateTime UpdAt { get; set; }
        public string UpdBy { get; set; }

        public virtual ICollection<ApplicationConsent> ApplicationConsents { get; set; }
    }
}
