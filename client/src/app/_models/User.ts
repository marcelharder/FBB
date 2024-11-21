export interface User {
  Id:number;
  UserName: string;
  Token: string;
  roles: string[];
  KnownAs: string;
  PhotoUrl: string;
  Email: string;
  Mobile: string;
  PaidTill: Date;
  Country:string;
}
