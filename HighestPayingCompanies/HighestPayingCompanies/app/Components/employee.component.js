"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var data_service_1 = require("../Services/data.service");
var forms_1 = require("@angular/forms");
var ng2_bs3_modal_1 = require("ng2-bs3-modal/ng2-bs3-modal");
var enum_1 = require("../Shared/enum");
var global_1 = require("../Shared/global");
var EmployeeComponent = (function () {
    function EmployeeComponent(fb, _employeeService) {
        this.fb = fb;
        this._employeeService = _employeeService;
        this.indLoading = false;
    }
    EmployeeComponent.prototype.ngOnInit = function () {
        this.employeeFrm = this.fb.group({
            EmployeeId: [''],
            Name: ['', forms_1.Validators.required],
            Salary: ['', forms_1.Validators.required],
            CompanyId: [''],
            Company: ['']
        });
        this.LoadEmployees();
        this.LoadCompanies();
        //for (let i = 0; i < this.employees.length; i++) {
        //    this.employees[i].Company = this.companies.filter(x => x.CompanyId == this.employees[i].CompanyId)[0].Name;
        //}
    };
    EmployeeComponent.prototype.LoadEmployees = function () {
        var _this = this;
        this.indLoading = true;
        this._employeeService.get(global_1.Global.BASE_EMPLOYEE_ENDPOINT)
            .subscribe(function (employees) { _this.employees = employees; _this.indLoading = false; }, function (error) { return _this.msg = error; });
        this.indLoading = true;
    };
    EmployeeComponent.prototype.LoadCompanies = function () {
        var _this = this;
        this.indLoading = true;
        this._employeeService.get(global_1.Global.BASE_COMPANY_ENDPOINT)
            .subscribe(function (companies) { _this.companies = companies; _this.indLoading = false; }, function (error) { return _this.msg = error; });
    };
    EmployeeComponent.prototype.addEmployee = function () {
        this.dbops = enum_1.DBOperation.create;
        this.SetControlsState(true);
        this.modalTitle = "Add New Employee";
        this.modalBtnTitle = "Add";
        this.employeeFrm.reset();
        this.modal.open();
    };
    EmployeeComponent.prototype.editEmployee = function (EmployeeId) {
        this.dbops = enum_1.DBOperation.update;
        this.SetControlsState(true);
        this.modalTitle = "Edit Employee";
        this.modalBtnTitle = "Update";
        this.employee = this.employees.filter(function (x) { return x.EmployeeId == EmployeeId; })[0];
        this.employeeFrm.setValue(this.employee);
        this.modal.open();
    };
    EmployeeComponent.prototype.deleteEmployee = function (EmployeeId) {
        this.dbops = enum_1.DBOperation.delete;
        this.SetControlsState(false);
        this.modalTitle = "Confirm to Delete?";
        this.modalBtnTitle = "Delete";
        this.employee = this.employees.filter(function (x) { return x.EmployeeId == EmployeeId; })[0];
        this.employeeFrm.setValue(this.employee);
        this.modal.open();
    };
    EmployeeComponent.prototype.onSubmit = function (formData) {
        var _this = this;
        this.msg = "";
        switch (this.dbops) {
            case enum_1.DBOperation.create:
                this._employeeService.post(global_1.Global.BASE_EMPLOYEE_ENDPOINT, formData._value).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Employee successfully added.";
                        _this.LoadEmployees();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.update:
                this._employeeService.put(global_1.Global.BASE_EMPLOYEE_ENDPOINT, formData._value.EmployeeId, formData._value).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Employee successfully updated.";
                        _this.LoadEmployees();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
            case enum_1.DBOperation.delete:
                this._employeeService.delete(global_1.Global.BASE_EMPLOYEE_ENDPOINT, formData._value.EmployeeId).subscribe(function (data) {
                    if (data == 1) {
                        _this.msg = "Employee successfully deleted.";
                        _this.LoadEmployees();
                    }
                    else {
                        _this.msg = "There is some issue in saving records, please contact to system administrator!";
                    }
                    _this.modal.dismiss();
                }, function (error) {
                    _this.msg = error;
                });
                break;
        }
    };
    EmployeeComponent.prototype.SetControlsState = function (isEnable) {
        isEnable ? this.employeeFrm.enable() : this.employeeFrm.disable();
    };
    __decorate([
        core_1.ViewChild('modal'),
        __metadata("design:type", ng2_bs3_modal_1.ModalComponent)
    ], EmployeeComponent.prototype, "modal", void 0);
    EmployeeComponent = __decorate([
        core_1.Component({
            templateUrl: 'app/Components/employee.component.html'
        }),
        __metadata("design:paramtypes", [forms_1.FormBuilder, data_service_1.DataService])
    ], EmployeeComponent);
    return EmployeeComponent;
}());
exports.EmployeeComponent = EmployeeComponent;
//# sourceMappingURL=employee.component.js.map