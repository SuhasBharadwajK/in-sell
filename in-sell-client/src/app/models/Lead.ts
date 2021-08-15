export class Lead{
    public bDR: string; 
    public dateAdded: Date; 
    public practice: string; 
    public campaign: string; 
    public companyName: string; 
    public firstName: string; 
    public middleName: string; 
    public lastName: string; 
    public industry: string; 
    public designation: string; 
    public phoneNumber: string; 
    public email: string; 
    public revenue: string; 
    public linkedIn: string;
    public source: string;
    public country: string; 
    public state: string;
    public companyWebsite: string; 
    public addedBy: string; 
    public status: string;

    constructor(args: any){
        args = !!args ? args : {};
        this.bDR = args.bDR; 
        this.dateAdded =  args.dateAdded; 
        this.practice = args.practice; 
        this.campaign = args.campaign; 
        this.companyName = args.companyName; 
        this.firstName = args.firstName; 
        this.middleName = args.middleName; 
        this.lastName = args.lastName; 
        this.industry = args.industry; 
        this.designation = args.designation; 
        this.phoneNumber = args.phoneNumber; 
        this.email = args.email; 
        this.revenue = args.revenue; 
        this.linkedIn = args.linkedIn;
        this.source = args.source;
        this.country = args.country; 
        this.state = args.state;
        this.companyWebsite = args.companyWebsite; 
        this.addedBy = args.addedBy;
        this.status = args.status;
    }
}