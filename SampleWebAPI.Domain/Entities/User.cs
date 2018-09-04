namespace SampleWebAPI.Domain.Entities
{
    public class User : IEntity
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string email { get; set; }
        public virtual string password { get; set; }
        public virtual bool IsConfidentials { get; set; }
    }
}
