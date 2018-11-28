using System.ComponentModel;

namespace WebDel3Part2.Models
{
    public class Component
    {
        public long ComponentId { get; set; }
        public long ComponentTypeId { get; set; }
        [DisplayName("Component Number")]
        public int ComponentNumber { get; set; }
        [DisplayName("Serial#")]
        public string SerialNo { get; set; }
        public ComponentStatus Status { get; set; }
        [DisplayName("Admin comment")]
        public string AdminComment { get; set; }
        [DisplayName("User comment")]
        public string UserComment { get; set; }
        public long? CurrentLoanInformationId { get; set; }
    }
}