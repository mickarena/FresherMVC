<<<<<<< HEAD
﻿
using System;
using System.Collections.Generic;
=======
﻿using System.ComponentModel;
>>>>>>> 251164ab22390e254035d91341fc3f66630d375f
using System.ComponentModel.DataAnnotations;

namespace Core.Entities
{
    public class MedicineBill : BaseEntity
    {
        [Required]
        [DisplayName("Doctor ID")]
        public Guid DoctorID { get; set; }

        [DisplayName("Date created")]
        public DateTime DateCreate { get; set; }

        [Required]
        [DisplayName("Pay status")]
        public bool PayStatus { get; set; }

        public IEnumerable<MedicineBillInfo>? MedicineBillInfos { get; set; }
    }
}

