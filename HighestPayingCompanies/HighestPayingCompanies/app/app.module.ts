import { NgModule } from '@angular/core';
import { APP_BASE_HREF } from '@angular/common';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppComponent } from './app.component';
import { Ng2Bs3ModalModule } from 'ng2-bs3-modal/ng2-bs3-modal';
import { routing } from './app.routing';
import { HomeComponent } from './components/home.component';
import { CompanyComponent } from './components/company.component';
import { EmployeeComponent } from './components/employee.component';
import { DataService } from './Services/data.service'

@NgModule({
    imports: [BrowserModule, ReactiveFormsModule, HttpModule, routing, Ng2Bs3ModalModule],
    declarations: [AppComponent, HomeComponent, CompanyComponent, EmployeeComponent],
    providers: [{ provide: APP_BASE_HREF, useValue: '/' }, DataService],
    bootstrap: [AppComponent]
})

export class AppModule { }