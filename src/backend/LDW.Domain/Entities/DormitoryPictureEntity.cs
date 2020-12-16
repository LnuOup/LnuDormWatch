using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Domain.Entities
{
	public class DormitoryPictureEntity
	{
		public int Id { get; set; }
		public int DormitoryId { get; set; }
		public bool IsMain { get; set; }
		public byte[] Image { get; set; }

		public DormitoryEntity Dormitory { get; set; }
	}
}
