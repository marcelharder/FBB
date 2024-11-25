export interface CaseReportModel{
    CaseReportNo:number;
    Lesion: string;
    Gender: string;
    PhotoUrl:string;
    Country:string;
    KnownAs: string;
    DateOfBirth: Date;
    Created: Date;
    BatteryType:string;
    Outcomes: number;
    ReferrerId: number;
}