namespace TeamManager.Domain.Entities
{
    public class Collaborator
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int UnitId { get; set; }
        public int? TeamId { get; set; }
    }
}
