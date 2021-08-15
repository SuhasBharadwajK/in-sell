import { Component, OnInit } from "@angular/core";
import { Lead } from "app/models/Lead";
import { LeadsService } from "app/services/leadsService";

@Component({
  selector: "app-table-list",
  templateUrl: "./table-list.component.html",
  styleUrls: ["./table-list.component.css"],
})
export class TableListComponent implements OnInit {
  public leads: Lead[] = [];

  constructor(private leadsService: LeadsService) {}

  ngOnInit() {
    (async () => {
      this.leads = await this.leadsService.getLeads();
      console.log(this.leads);
    })();
  }
}
