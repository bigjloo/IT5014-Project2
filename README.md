# IT5014 Project 2- Ticket System in C# 

## Learning Objectives
- Software Development Life Cycle
  - Requirements analysis
  - Documentation
  - Testing (xUnit)
- Develop solution in C#
- Object Oriented Programming
- UML diagrams 
- SOLID principles

# Stage 1: Planning

Identifying user goals with use case diagram

## Use case diagram:
<img src="/UML/use_case_diagram.jpg" width="400">

## Users:

- Staff - Internal staff from other departments

- Helpdesk Support - IT Tech Support staff

## Purpose:

To allow Helpdesk Support staff to assist Staff members through a Ticket
System

## Solution:

Ticket System that allows:

1.  Staff to submit ticket

2.  Helpdesk to resolve issues from tickets submitted

# Stage 2: Requirements Analysis

## Agile user stories:

-   As a staff member, I want to get my password changed, so I can log
    in

-   As a staff member, I want to submit a ticket, so I can continue with
    my work.

-   As helpdesk support, I want to be able to respond to tickets, so the
    staff can continue with his work.

-   As helpdesk support, I want to be able to reopen tickets, so I don't
    need to re-create a new ticket for existing issue.

-   As helpdesk support, I want to be able to view ticket statistics, so
    I can have an overall view on work progress

-   As helpdesk support, I want to be able to view all tickets
    information.

-   As helpdesk support, I want to be able to automate password change
    response, so I can put my time into other issues.

## Functional Requirements:

### FR0. System Should be able to create Tickets 

- FR0.1 Tickets should be created with two methods:

    - FR0.1.1 Two arguments:

            1. StaffID - made up of employee's name + first letter of surname

            2. Description - description of issue

        Default values of "Not Specified" for creator name and contact email

    - FR0.1.2 Four arguments:

            1. StaffID

            2. Description

            3. Email -- email of staff

            4. Creator Name -- name of staff

- FR0.2 Ticket Number should be assigned automatically using a counter
static field plus 2000

    - FR0.2.1 When ticket is created

            Ticket number = counter + 2000

    - FR 0.2.2 Counter field +1 for every new ticket created

### FR1 Responding to Tickets

- FR1.1 Password automatically generated and set to Ticket.Response if
Ticket description contains words "Password Change"

    - Password generation method:

            -   First two characters of StaffID

            -   Hexadecimal representation of Ticket Number

            -   Hexadecimal representation of first three characters of
                timestamp

    - Password generated set to Ticket.Response after

- FR1.2 Option for Helpdesk Support to provide feedback after Ticket
submitted

-   Allow Helpdesk to respond with a message

### FR2 Ticket Statistics

- FR2.1 Ticket statistics for created, opened, closed tracked

    - When tickets are created, resolved or reopened, statistic is tracked
    and updated

            FR2.1.1 Created: created += 1, opened += 1

            FR2.1.2 Resolved: opened -= 1, closed += 1

            FR2.1.3 Reopened: opened +=1, closed -= 1

- FR2.2 User can display Ticket Statistics to console

### FR3 Ticket Display

- FR3.1 There should be method to display ticket information

- FR3.2 Ticket information to display

        Ticket number

        Name of Ticket creator

        Staff ID

        Email address

        Description of issue

        Response from Helpdesk Support

        Ticket status

## Technical Requirements:

TR1 Ticket class should contain common ticket information

-   Ticket number

-   Name of ticket creator

-   Staff ID

-   Email address

-   Description of issue

-   Response from Helpdesk Support

-   Ticket status

TR2 Ticket created using constructors

TR3 Ticket class should have methods to:

-   Respond to ticket

-   Resolve ticket

-   Reopen ticket

-   Resolving password change request

TR4 Method to print information for all ticket objects (ticket objects
stored in List\<Ticket>)

TR5 TicketStats class should contain information on ticket statistics

-   Created

-   Opened

-   Closed

TR6 TicketStats variables for storing statistics should be
encapsulated with default value of 0.

TR7 TicketStats should have method to return string value that
displays statistics information

TR8 PasswordGenerator class have static method to generate password
base on:

-   Ticket number

-   StaffID

-   Timestamp

TR9 in Main method:

-   Create at least one instance of both ways to create ticket, at least
    one with password change request

-   After tickets created, display ticket statistics

-   Resolve some tickets, display ticket information and statistics

-   Reopen some resolved tickets, display ticket information and
    statistics

# Stage 3: Solution design

## Classes

1\. Ticket

2\. TicketStats

3\. PasswordGenerator (static)

4\. TicketContainer

# Stage 4: Detailed Design

## Class diagram:

<img src="/UML/class_diagram.jpg" height="400">

## Process diagrams:

-   Create Ticket

<img src="/UML/staff-create-ticket.jpg" width="600">

-   Resolve ticket

<img src="/UML/helpdesk-resolve.jpg" width="600">

-   Reopen Ticket

<img src="/UML/helpdesk-reopen.jpg" width="600">

-   Display ticket statistic and information

<img src="/UML/helpdesk-displayTicketStatsAndInformation.jpg" width="600">

## Object Oriented Programming concepts applied:

### Polymorphism

Ticket Class:

-   Constructor overloading is used to allow Ticket class two ways to
    create instances of the same \<Ticket> type

### Abstraction

Interfaces:

-   Interfaces are used in the program to hide concrete classes and
    allow only the methods that are needed to be applied. Example:
    main() would only need to use methods Reopen() and Resolve() and any
    class that implements the interface with the two methods can be
    used. The main() program doesn't know what concrete class is
    returned, only that the object returned implemented the interface

-   Abstractions through interfaces also allows for more room for future
    modification as it generalises.

-   With abstraction through interfaces we also hide the methods that
    are not needed

### Encapsulation

TicketStats Class:

-   By encapsulating through getter/setter methods in the class itself,
    setting the properties to private, we can protect the integrity of
    the state (ticket statistics) inside from outside. This reduces the
    likelihood of unwanted state modification

Ticket Class:

-   Private setters are applied with the same reason that we design the
    system to allow users to retrieve the property data but not modify
    it.

-   Private methods are also used to protect from external modification

# Stage 5: Construction 

Refer to solution files in folder

# Stage 6: Testing

Refer to Test files in folder

### Test suite used 

XUnit

### Functional requirements coverage

10/13 -\> 77%

### Technical requirements coverage

6/9 -\> 66.6%

### Untested

-   Display to console methods

-   Main()

-   Password Generator -- Hard to test with variable timestamp

## Line Coverage

![line coverage](/UML/test_coverage.jpg)

## Problems from test

Singleton pattern hard for testing

## Solution

Removed singleton pattern and have dependencies injected from main()
instead

1.  Main() creates TicketStats and TicketContainer

2.  Main() injects TicketStats and TicketContainer into TicketFactory
    and TicketDisplay

3.  TicketFactory injects TicketStats to create Tickets and adds ticket
    to TicketContainer

## Redesign after Test

![redesigned diagram](/UML/UML_final.jpg)

-   Added TicketFactory and TicketDisplay class to separate
    responsibilities

-   Added interfaces to decouple concrete classes from one another and
    main()
