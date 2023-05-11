export class Register{
  email: string;
  password: string;
  name:string;
  city:string;
  streetAdress:string;
  postalCode:string;
  phoneNumber:string;
  role:string;
  userName:string;
  DisPlayName:string;

  constructor(e:string,pass:string,na:string,city:string,street:string,postal:string,phone:string,play:string,role:string,user:string)
  {
    this.email=e;
    this.password=pass;
    this.name=na;
    this.city=city;
    this.streetAdress=street;
    this.postalCode=postal;
    this.phoneNumber=phone;
    this.DisPlayName=play;
    this.role=role;
    this.userName=user;

  }
}