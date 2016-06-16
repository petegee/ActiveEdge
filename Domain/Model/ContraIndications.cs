using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;

namespace Domain.Model
{
    public class ContraIndications
    {
        [DisplayName("Sunburn")]
        public bool Sunburn { get; set; }

        [DisplayName("Headache")]
        public bool Headache { get; set; }

        [DisplayName("Asthma")]
        public bool Asthma { get; set; }

        [DisplayName("Diabetes")]
        public bool Diabetes { get; set; }

        [DisplayName("Epilepsy")]
        public bool Epilepsy { get; set; }

        [DisplayName("Depression")]
        public bool Depression { get; set; }

        [DisplayName("Hemophilia")]
        public bool Hemophilia { get; set; }

        [DisplayName("Cuts/Burns/Bruises")]
        public bool CutsBurnsBruises { get; set; }

        [DisplayName("Severe Pain")]
        public bool SeverePain { get; set; }

        [DisplayName("Arteriosclerosis")]
        public bool Arteriosclerosis { get; set; }

        [DisplayName("Varicose Veins")]
        public bool VaricoseVeins { get; set; }

        [DisplayName("Dizziness")]
        public bool Dizziness { get; set; }

        [DisplayName("High Blood Pressure")]
        public bool HighBloodPressure { get; set; }

        [DisplayName("Low Blood Pressure")]
        public bool LowBloodPressure { get; set; }

        [DisplayName("Imflamation")]
        public bool Imflamation { get; set; }

        [DisplayName("Sleep Disturbance")]
        public bool SleepDisturbance { get; set; }

        [DisplayName("Is Pregnant")]
        public bool IsPregnant { get; set; }

        [DisplayName("Hernia")]
        public bool Hernia { get; set; }

        [DisplayName("Cancer")]
        public bool Cancer { get; set; }

        [DisplayName("Contact Lenses")]
        public bool ContactLenses { get; set; }

        [DisplayName("Musculo Skeletal Problems")]
        public bool MusculoskeletalProblems { get; set; }

        [DisplayName("Irritated Skin Rash")]
        public bool IrritatedSkinRash { get; set; }

        [DisplayName("Cold Or Flu")]
        public bool ColdOrFlu { get; set; }

        [DisplayName("Arthritis")]
        public bool Arthritis { get; set; }

        [DisplayName("Stomach Ulcers")]
        public bool StomachUlcers { get; set; }

        [DisplayName("Pacemaker")]
        public bool PinsPacemaker { get; set; }

        [DisplayName("Heart Disease")]
        public bool HeartDisease { get; set; }

        [NotMapped]
        public bool HasAny => Conditions != null && Conditions.Any();

        [NotMapped]
        public IEnumerable<string> Conditions
        {
            get
            {
                var properties =
                    GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(info => info.CanWrite);

                foreach (var propertyInfo in properties)
                {
                    if ((bool)propertyInfo.GetValue(this))
                    {
                        yield return propertyInfo.GetCustomAttribute<DisplayNameAttribute>().DisplayName;
                    }
                }
            }
        }
    }
}