using System;
using System.Collections.Generic;
using System.Text;

namespace LDW.Application.Models.Dormitory
{
	public class DormitoryPictureModel
	{
		public int Id { get; set; }
		public int DormitoryId { get; set; }
		public bool IsMain { get; set; }
		public byte[] Image { get; set; }
	}
}
