using System.ComponentModel.DataAnnotations;

namespace FBB.data.models;
public class CaseReport

    {
        [Key]
        public int CaseReportNo {get; set;}
        public string? Gender { get; set; }
        public string? PhotoUrl { get; set; }
        public string? Country { get; set; }
        public string? KnownAS {get; set;}
        public string? BatteryType {get; set;}
        public DateTime DateOfBirth { get; set; }
        public DateTime Created { get; set; }
        public int? Outcomes {get; set;}
        public int? ReferrerId {get; set;}
       
    }
