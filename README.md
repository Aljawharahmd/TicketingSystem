# TicketingSystem

A fully functional support ticketing system of well-integrated layers including the data access layer, the service layer (business logic) as well as the presentation layer. 

The system serves as helpdesk for product support where the client submits a ticket stating their concern with the ability to attach files. The ticket then is received by the manager who assigns it to a support staff. Although the manager has the privilege of monitoring all the activities and assigns tickets to different staff, the staff member is only able to access the tickets assigned to them by his manager. The manager is provided with a dashboard that displays useful insights that help in decision making. The staff are also provided with a dashboard that shows different statistics about their assigned tickets. Finally, the clients can track their tickets and chat with the support staff and confirm the resolution of the issue so the staff can close the ticket. 

<img width="538" alt="TickIT doc" src="https://user-images.githubusercontent.com/68808585/114041259-0e244200-988d-11eb-8115-8b37092ad48d.png">

![TicketSystem-ERD](https://user-images.githubusercontent.com/68808585/114041278-12e8f600-988d-11eb-8e28-9fb216c8fd87.png)

Functional Requirements
Main System Actors
-	External Client 
-	Company Support Team Member
-	Company support Manager  
The system contains two subsystems (UI layers) with shared Web API layer
-	External Client System which is accessible anywhere through the internet
-	Support Employees System which is accessible only from company public IP
Registration
Manager and Support Staff: 
-	Fill the registration form containing basic user information (full name, mobile number, email, date of birth and address).
-	OTP verification.
-	User selects the preferred authentication method (voice or face recognition) using matching API. 
External clients:
-	Login using their registered mobile number and password. 
-	OTP verification.
 
Login
Manager and Support Staff
-	login using their registered mobile number. 
-	OTP verification.
-	Image or Voice Matching by matching user’s registered image/voice with login image\voice. 
External clients
-	Login using their registered mobile number and password. 
-	OTP verification.

 Support Manager Workflow
-	List of all support staff
-	List of all clients with a number of tickets for each client
-	Activate / Deactivate / view support employees
-	Activate / Deactivate / view clients
-	Deactivated Support Staff / External Clients cannot login to the system
-	The Support Manager can list all tickets with status, priority, assigned staff, product, client number, ticket number and dates filters
-	The Support Manager can view ticket information
-	Assign tickets to support staff
-	Dashboard contains some charts about ticket status, statistics, most productive staff and other useful information

External Client Workflow
-	See a list of all tickets related to them and can view the ticket details.
-	Chat with the assigned support staff. 
-	Add new tickets and attach related files.
-	Tickets will be submitted with status: Open.
-	Tickets have four possible statuses: Open, In Progress, Closed and Solved. 
-	Tickets will arrive to the Support Manager and he will assign/reassign the new ticket to any of the support staff members.
-	Client will close the ticket once the issue is resolved, otherwise it will be closed automatically after 10 days from the last feedback

Support Staff Workflow
-	Support Employees will see a list of assigned tickets with status, priority, product, client number, ticket number and dates filters. 
-	View ticket details and reply to it with the ability to upload attachments. Clients can see these comments and reply to them. 
-	Dashboard contains some charts about ticket status and other useful information.

Technical Aspects
- The system is designed using 3-tier architecture with 3 physical layers: UI (Presentation layer), Business (WebAPI layer) and Data Access Layer. 
-	MySQL as RDBMS.
-	Ping action for UI layer (MVC) and for WebAPI layer.
-	Health check action to detect system current health status. Used for monitoring purposes. 
-	Errors and Exception handling. 
-	UI/UX, Look and Feel and responsive design.
-	Logging. 
-	Clean code and OOP principles are considered. 

Non-Functional Requirements
a detailed specification of the user interaction with the software and measurements placed on the system performance.
- Performance Requirements
PE-1: Dashboard pages should refresh automatically every 30 seconds.
- Security Requirements
SE-1: The system should log out the user automatically after one hour of screen inactivity.
SE-2: Login should be for the active users only.
SE-3: All password should be hashed.
SE-4: The system should permit unauthorized users from access.
SE-5: Users should be required to log in to the system for all operations.
- User Experience Requirements
Navigability
The application should allow the user to navigate between pages easily. 
Memorability
Use different icons and colors in the application to support memorability. 
Flexibility
The application should be flexible to help the user to deal with it. 
Usability
The services provided in the application should be easy to use. 
Readability
The application should be easy to be understood and read. 
