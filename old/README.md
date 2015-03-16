# TicketTrackingSystem
Ticket Tracking System

Ticket Tracking System

You will create a web-based ticket tracking system for a multi-building facility.  It will consist of the following front-ends:
A ticket request system called EZFacilities.  There are two panels, on one panel employees can use this form to log issues with building facilities.  They do so by providing the following information:
Employee number 
OR
Name (First and last)
Office number 
Phone number
Email
(If employee number is entered the above four fields are auto-populated)
Current date (auto populated)
Building with issue {Main office, Warehouse A, Warehouse B, West Annex, Downtown office, Transport pool}
Issue description
When a ticket is submitted the user is given a PIN.  On the other panel they can use the EZFacilities application to enter a PIN and view the details and status of their Ticket Request (Submitted, Cancelled, Assigned, or Completed).
If they forget their PIN they can enter their email address and get a list of PINs they have submitted.

A ticket management system called EZTicketManager.  This application allows a user to view all submitted tickets.  They can filter by ticket status, last name of the person who submitted the ticket, or last name of the employee who has been assigned the ticket.  The user can also perform the following tasks on any ticket:
Assign the ticket to an employee of type Maintenance (This will also change its status to assigned)
Cancel the ticket (This will change its status to canceled)
Close the ticket (This will change its status to completed)
Un-assign a ticket (This will change its status to submitted) 

A ticket application called EZMyTickets.  This application allows an employee to view tickets that have been assigned to them.  It should only display the ticket id, the ticket location, ticket description, and ticket status.  The application should allow the user to look at one ticket at a time, and mark any of these as completed.
This application is intended to be viewed on a mobile device, so keep the user interface simple.

Other requirements
Parts 1 and 2 should use classes declared in a DLL.  Part 3 should interact with a WCF service.
An empty database called EZTicket# is on the BISIISDev server.
Use an AJAX template on question 1 to smooth the load of employee information
You should create a ticket and employee class.  A ticket “has” 2 Employee objects.  All presentation layer code should interact only with these objects and their manager class.

 
      
  
  
