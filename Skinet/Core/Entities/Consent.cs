using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Consent : BaseEntity
    {
        public Consent()
        {
            this.ApplicationConsents = new HashSet<ApplicationConsent>();
        }

        public Guid ProcessFlowConfigurationId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string StatusId { get; set; }
        public System.DateTime InsAt { get; set; }
        public string InsBy { get; set; }
        public System.DateTime UpdAt { get; set; }
        public string UpdBy { get; set; }

        public virtual ICollection<ApplicationConsent> ApplicationConsents { get; set; }
        public virtual ProcessFlowConfiguration ProcessFlowConfiguration { get; set; }
    }
}
