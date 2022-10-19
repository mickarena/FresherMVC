namespace Core.Entities
{
    public class ProcessFlowConfiguration : BaseEntity
    {
        public ProcessFlowConfiguration()
        {
            this.Consents = new HashSet<Consent>();
        }

        public int ApplicationYear { get; set; }
        public int SPMYear { get; set; }
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public int TotalOfAs { get; set; }
        public int TotalSPMSubject { get; set; }
        public int DefaultBulletinId { get; set; }
        public string StatusId { get; set; }
        public System.DateTime InsAt { get; set; }
        public string InsBy { get; set; }
        public System.DateTime UpdAt { get; set; }
        public string UpdBy { get; set; }
        public virtual ICollection<Consent> Consents { get; set; }
    }
}
