import { Component, OnInit, ViewChild } from '@angular/core';
import { DataService } from '../Services/data.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ModalComponent } from 'ng2-bs3-modal/ng2-bs3-modal';
import { ICompany } from '../Models/company';
import { IEmployee } from '../Models/employee';
import { DBOperation } from '../Shared/enum';
import { Observable } from 'rxjs/Rx';
import { Global } from '../Shared/global';

@Component({
    templateUrl: 'app/Components/employee.component.html'
})

export class EmployeeComponent implements OnInit {
    @ViewChild('modal') modal: ModalComponent;
    employees: IEmployee[];
    employee: IEmployee;
    companies: ICompany[];
    msg: string;
    indLoading: boolean = false;
    employeeFrm: FormGroup;
    dbops: DBOperation;
    modalTitle: string;
    modalBtnTitle: string;


    constructor(private fb: FormBuilder, private _employeeService: DataService) { }

    ngOnInit(): void {
        this.employeeFrm = this.fb.group({
            EmployeeId: [''],
            Name: ['', Validators.required],
            Salary: ['', Validators.required],
            CompanyId: [''],
            Company: ['']
        });

        this.LoadEmployees();
        this.LoadCompanies();

        //for (let i = 0; i < this.employees.length; i++) {
        //    this.employees[i].Company = this.companies.filter(x => x.CompanyId == this.employees[i].CompanyId)[0].Name;
        //}
    }

    LoadEmployees(): void {
        this.indLoading = true;
        this._employeeService.get(Global.BASE_EMPLOYEE_ENDPOINT)
            .subscribe(employees => { this.employees = employees; this.indLoading = false; },
            error => this.msg = <any>error);
        this.indLoading = true;
    }

    LoadCompanies(): void {
        this.indLoading = true;
        this._employeeService.get(Global.BASE_COMPANY_ENDPOINT)
            .subscribe(companies => { this.companies = companies; this.indLoading = false; },
            error => this.msg = <any>error);
    }

    addEmployee() {
        this.dbops = DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Employee";
        this.modalBtnTitle = "Add";
        this.employeeFrm.reset();
        this.modal.open();
    }

    editEmployee(EmployeeId: number) {
        this.dbops = DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Employee";
        this.modalBtnTitle = "Update";
        this.employee = this.employees.filter(x => x.EmployeeId == EmployeeId)[0];
        this.employeeFrm.setValue(this.employee);
        this.modal.open();
    }

    deleteEmployee(EmployeeId: number) {
        this.dbops = DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.employee = this.employees.filter(x => x.EmployeeId == EmployeeId)[0];
        this.employeeFrm.setValue(this.employee);
        this.modal.open();
    }

    onSubmit(formData: any) {
        this.msg = "";

        switch (this.dbops) {
            case DBOperation.create:
                this._employeeService.post(Global.BASE_EMPLOYEE_ENDPOINT, formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Employee successfully added.";
                            this.LoadEmployees();
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
                this._employeeService.put(Global.BASE_EMPLOYEE_ENDPOINT, formData._value.EmployeeId, formData._value).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Employee successfully updated.";
                            this.LoadEmployees();
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
                this._employeeService.delete(Global.BASE_EMPLOYEE_ENDPOINT, formData._value.EmployeeId).subscribe(
                    data => {
                        if (data == 1) //Success
                        {
                            this.msg = "Employee successfully deleted.";
                            this.LoadEmployees();
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
        isEnable ? this.employeeFrm.enable() : this.employeeFrm.disable();
    }
}