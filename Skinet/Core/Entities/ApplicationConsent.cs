namespace Core.Entities
{
    public class ApplicationConsent : BaseEntity
    {
        public Guid ApplicationId { get; set; }
        public Guid ConsentId { get; set; }
        public bool Answer { get; set; }
        public string StatusId { get; set; }
        public System.DateTime InsAt { get; set; }
        public string InsBy { get; set; }
        public System.DateTime UpdAt { get; set; }
        public string UpdBy { get; set; }

        public virtual Application Application { get; set; }
        public virtual Consent Consent { get; set; }
    }
}
