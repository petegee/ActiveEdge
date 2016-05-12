namespace Domain.Model
{
  public class Clinic : Entity
  {
    public string Name { get; set; }
    public Address Address { get; set; }
    public virtual Organisation Standard { get; set; }
  }
}