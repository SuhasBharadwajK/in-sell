import { Component, OnInit } from "@angular/core";
import { NgbModal, ModalDismissReasons } from "@ng-bootstrap/ng-bootstrap";
import { Lead } from "app/models/Lead";
import { FormControl, FormGroup, Validators } from "@angular/forms";
import { LeadsService } from "app/services/leadsService";

@Component({
  selector: "app-add-lead",
  templateUrl: "./add-lead.component.html",
  styleUrls: ["./add-lead.component.css"],
})
export class AddLeadComponent implements OnInit {
  closeResult = "";

  constructor(
    private modalService: NgbModal,
    private leadsService: LeadsService
  ) {}

  ngOnInit() {}

  leadForm = new FormGroup({
    bDR: new FormControl("", [Validators.required]),
    dateAdded: new FormControl("", [Validators.required]),
    practice: new FormControl("", [Validators.required]),
    campaign: new FormControl("", [Validators.required]),
    companyName: new FormControl("", [Validators.required]),
    firstName: new FormControl("", [
      Validators.required,
      Validators.pattern(/^[a-zA-Z ]+$/),
    ]),
    middleName: new FormControl("", [
      Validators.required,
      Validators.pattern(/^[a-zA-Z ]+$/),
    ]),
    lastName: new FormControl("", [
      Validators.required,
      Validators.pattern(/^[a-zA-Z ]+$/),
    ]),
    industry: new FormControl("", [Validators.required]),
    designation: new FormControl("", [Validators.required]),
    phoneNumber: new FormControl("", [
      Validators.required,
      Validators.pattern(/^\d{10}$/),
    ]),
    email: new FormControl("", [
      Validators.required,
      Validators.pattern(/^[a-zA-Z0-9\.]+@[a-zA-Z]+\.[a-zA-Z]{2,3}$/),
    ]),
    revenue: new FormControl("", [Validators.required]),
    linkedIn: new FormControl("", [Validators.required]),
    source: new FormControl("", [Validators.required]),
    country: new FormControl("", [Validators.required]),
    state: new FormControl("", [Validators.required]),
    companyWebsite: new FormControl("", [Validators.required]),
    status: new FormControl("", [Validators.required]),
  });

  get form() {
    return this.leadForm.controls;
  }

  public open(content) {
    this.modalService
      .open(content, { ariaLabelledBy: "modal-basic-title" })
      .result.then(
        (result) => {
          this.closeResult = `Closed with: ${result}`;
        },
        (reason) => {
          this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;
        }
      );
  }

  public save() {
    this.modalService.dismissAll();
    this.leadsService.addLeads(this.leadForm.value);
  }

  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return "by pressing ESC";
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return "by clicking on a backdrop";
    } else {
      return `with: ${reason}`;
    }
  }
}
