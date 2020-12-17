namespace LDW.Domain.Entities
{
	public class DormitoryPictureEntity
	{
		public int Id { get; set; }
		public int DormitoryId { get; set; }
		public bool IsMain { get; set; }
		public string ImageUrl { get; set; }

		public DormitoryEntity Dormitory { get; set; }
	}
}
