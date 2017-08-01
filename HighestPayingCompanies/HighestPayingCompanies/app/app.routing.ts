import { ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './components/home.component';
import { CompanyComponent } from './components/company.component';
import { EmployeeComponent } from './components/employee.component';

const appRoutes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'company', component: CompanyComponent },
    { path: 'employee', component: EmployeeComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);