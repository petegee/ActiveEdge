using System.ComponentModel.DataAnnotations;

namespace Domain
{
  public enum TouchPreference
  {
    [Display(Name = "Don't Know")]
    DoNotKnow,
    Light,
    Heavy,
    Deep,
  }
}