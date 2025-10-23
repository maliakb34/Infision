using System;

namespace Infision.PayloadBuilder.Models
{
    public class Patient
    {
        public string Pid { get; set; } = string.Empty;
        public string VisitId { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public string Ward { get; set; } = string.Empty;
        public string Bed { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public Gender Gender { get; set; } = Gender.Unknown;
        public int? Age { get; set; }
        public AgeUnit AgeUnit { get; set; } = AgeUnit.Years;
        public double? HeightCm { get; set; }
        public double? WeightKg { get; set; }
        public BloodType BloodType { get; set; } = BloodType.Unknown;
        public string Physician { get; set; } = string.Empty;
        public string Diagnosis { get; set; } = string.Empty;
        public DateTime? AdmitDateUtc { get; set; }
    }
}
