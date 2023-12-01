# PhoneBookTask

Implement an application in C# \ .Net to manage the following two entities: companies and persons.
Company
- Add
  - Company Name (string) (Unique)
  - Registration Date (date)
- View: display / retrieve all
  - Also calculate number of persons linked to the company

Person
- Add
  - Full Name (string)
  - Phone number (string)
  - Address (string)
  - Company (drop down / link)
- View All: display / retrieve all
  - Search: to check through all fields including Company Name
  - View Profile
    - Edit
    - Remove

- Wild card: opens a random profile’s edit page.
Further instructions:
- Company needs to be stored in a separate table and linked via a foreign key.
- Wild card: random pick functionality should be implemented in backend.
- Search: needs to work on all fields including Company.

## Implementation
Applicant can choose to consume the above functionality through one of the below two options.
### Option 1: Web APIs & Unit Tests
- Expose the above functionality as API methods through a ASP.Net Web Application
- Create a Unit Test Project for the following methods
Note: inputs can either be randomized or use variables with static values at the start of the
test methods
  - Company_Add
  - Company_GetAll:
    - Including “No. People” property
Don’t include linked People.

  - Person_Add
  - Person_Add_Edit_Remove: add, edit, and remove all in one method
  - Person_GetAll: retrieve all
  - Person_Search: retrieve entries matching the search criteria.
  - Person_WildCard: randomly retrieve a person object.

NOTE: Assume that Person’s table can grow to a very large number of rows. The above data retrieval
methods/properties marked in green, need to be implemented so that there is little load to the
database and unnecessary data is not retrieved.
### Option 2: Full Stack
- Front-end in Asp.Net, React, Angular or similar framework
Optional “Company” field suggestions (for simplicity):
- Add: leave as text field. In the companies table insert in case it doesn’t already exist a
company with the same name.
- Edit: show as drop-down list, user can only change to one of the companies that already
exist.

## Deliverables
Provide GIT repo containing
- Code in .Net can be either .Net Framework or .Net 6.0 and a modern Visual Studio solution
like 2022 or 2019
- MySQL or SQL Server database \ schema backup
- In case front-end is not in .Net provide separate GIT Repo
## Appendix
If unsure which project templates to use here are some suggestions
.NET Framework
- ASP.Net Web Application (.NET Framework)
- Unit Test Project (.NET Framework)
.NetCore / .Net 6.0
- ASP.NET Core Web API
- MSTest Test Project
