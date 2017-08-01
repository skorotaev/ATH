import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../Services/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { ICompany } from '../Models/company';
import { DBOperation } from '../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({
    templateUrl: 'app/Components/company.component.html'
})

export class CompanyComponent implements OnInit {
    @ViewChild('modal') modal: ModalComponent;
    companies: ICompany[];
    company: ICompany;
    msg: string;
    indLoading: boolean = false;
    companyFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;


    constructor(private fb: FormBuilder, private _companyService: DataService) { }

    ngOnInit(): void {
        this.companyFrm = this.fb.group({
            CompanyId: [''],
            Name: ['', Validators.required]
        });

        this.LoadCompanies();
    }

    LoadCompanies(): void {
        this.indLoading = true;
        this._companyService.get(Global.BASE_COMPANY_ENDPOINT)
            .subscribe(companies => { this.companies = companies; this.indLoading = false; },
            error => this.msg = <any>error);
    }

    addCompany() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Company";
        this.modalBtnTitle = "Add";
        this.companyFrm.reset();
        this.modal.open();
    }

    editCompany(CompanyId: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Company";
        this.modalBtnTitle = "Update";
        this.company = this.companies.filter(x => x.CompanyId == CompanyId)[0];
        this.companyFrm.setValue(this.company);
        this.modal.open();
    }

    deleteCompany(id: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.company = this.companies.filter(x => x.CompanyId == id)[0];
        this.companyFrm.setValue(this.company);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";

        switch (this.dbops) {
            case DBOperation.create:
                this._companyService.post(Global.BASE_COMPANY_ENDPOINT, formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Company successfully added.";
                            this.LoadCompanies();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.update:
                this._companyService.put(Global.BASE_COMPANY_ENDPOINT, formData._value.CompanyId, formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Company successfully updated.";
                            this.LoadCompanies();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
            case DBOperation.delete:
                this._companyService.delete(Global.BASE_COMPANY_ENDPOINT, formData._value.CompanyId).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Company successfully deleted.";
                            this.LoadCompanies();
                        }
                        else {
                            this.msg = "There is some issue in saving records, please contact to system administrator!"
                        }

                        this.modal.dismiss();
                    },
                    error => {
                        this.msg = error;
                    }
                );
                break;
        }
    }

    SetControlsState(isEnable: boolean) {
        isEnable ? this.companyFrm.enable() : this.companyFrm.disable();
    }
}