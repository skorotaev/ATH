import { ICompany } from '../Models/company';

export interface IEmployee {
    EmployeeId: number,
    Name: string,
    Salary: number,
    CompanyId: number,
    Company: string
}