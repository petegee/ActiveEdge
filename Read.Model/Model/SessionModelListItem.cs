using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ActiveEdge.Read.Model
{
    public class SessionModelListItem
    {
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public int ClientId { get; set; }

        [AdditionalHtml(PlaceHolder = "Search")]
        [DisplayName("Client Name")]
        public string ClientFullName { get; set; }

        [DisplayName("Feedback From Last Session")]
        public string Feedback { get; set; }

        [DisplayName("Goal Or Expectations")]
        public string GoalOrExpectations { get; set; }

        [DisplayName("Areas of Discomfort")]
        public string AreasOfDiscomfort { get; set; }

        [DisplayName("Contributing Factors To Condition")]
        public string ContributingFactorsToCondition { get; set; }

        [DisplayName("Hypothesis")]
        public string Hypothesis { get; set; }

        [DisplayName("Pre-Massage Palpation")]
        public string PreMassagePalpation { get; set; }

   
   

    }
}