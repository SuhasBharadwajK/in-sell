import { Injectable } from "@angular/core";
import { Lead } from "app/models/Lead";
import axios from "axios";

@Injectable({
  providedIn: "root",
})
export class LeadsService {
  //TODO: Add user-specific logic after auth
  getLeads = async () => {
    try {
      let leads: Lead[] = (await axios.get("https://localhost:5001/api/leads"))
        .data;
      return leads;
    } catch (e) {
      console.log(e);
    }
  };

  addLeads = async (leadBody: Lead) => {
    try {
      await axios.post("https://localhost:5001/api/leads", leadBody, {
        headers: {
          "Content-Type": "application/json",
        },
      });
    } catch (e) {
      console.log(e);
    }
  };

  getAllLeadsInTimeFrame = async (
    startDate: string,
    endDate: string
  ): Promise<Lead[]> => {
    try {
      let leads = (
        await axios.get(
          `https://localhost:5001/api/reports/getAllByTimeFrame?startDate=${startDate}&endDate=${endDate}`,
          {
            headers: {
              "Content-Type": "application/json",
            },
          }
        )
      ).data;
      return leads;
    } catch (e) {
      console.log(e);
    }
  };
}
