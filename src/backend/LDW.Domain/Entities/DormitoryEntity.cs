using LDW.Domain.Entities.Common;

namespace LDW.Domain.Entities
{
    public class DormitoryEntity : BaseEntity<int>
    {
        public int Number { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}