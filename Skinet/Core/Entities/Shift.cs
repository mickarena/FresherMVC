﻿namespace Core.Entities
{
    public class Shift : BaseEntity
    {
        public Guid IdShift { get; set; }
        public string? ShiftName { get; set; }
        public string? Time { get; set; }
        public ICollection<WorkShift> WorkShift { get; set; }
    }
}
