using System.ComponentModel.DataAnnotations;

namespace Domain.Model
{
  public enum ExcerciseFrequency
  {

    Never,
    [Display(Name = "Once A Week")]
    OnceAWeek,
    [Display(Name = "Twice A Week")]
    TwiceAWeek,
    [Display(Name = "Three Times A Week")]
    ThreeTimesAWeek,
    [Display(Name = "Four Times A Week")]
    FourTimesAWeek,
    [Display(Name = "Five Times A Week")]
    FiveTimesAWeek,
    [Display(Name = "Six Times A Week")]
    SixTimesAWeek,
    [Display(Name = "Seven Times A Week")]
    SevenTimesAWeek,
    [Display(Name = "Seven+ A Week")]
    SevenPlusTimesAWeek
  }
}