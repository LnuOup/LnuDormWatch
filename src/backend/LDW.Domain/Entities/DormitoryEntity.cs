using LDW.Domain.Entities.Common;
using System.Collections.Generic;
using System.Drawing;

namespace LDW.Domain.Entities
{
	public class DormitoryEntity : BaseEntity<int>
	{
		public int Number { get; set; }
		public string Address { get; set; }
		public string PhoneNumber { get; set; }
		public double Latitude { get; set; }
		public double Longitude { get; set; }

		public ICollection<DormitoryPictureEntity> DormitoryPictures { get; set; }
	}
}