namespace Infision
{
    public class PatientData
{
        public string FirstName { get; set; } = "";   // field 7
        public string LastName { get; set; } = "";   // field 6
        public string PatientId { get; set; } = "";   // field 4
        public uint Age { get; set; }         // field 9
        public Sex Sex { get; set; }         // field 10
        public float WeightKg { get; set; }         // field 12 (float32)
        public float HeightCm { get; set; }         // field 11 (float32)
        public BloodType Blood { get; set; }         // field 13
        public string Department { get; set; } = "";  // field 2
        public string Room { get; set; } = "";   // field 3
        public uint BedNo { get; set; }
    }
}