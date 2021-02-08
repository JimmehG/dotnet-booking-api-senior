

### Install Git 

https://www.atlassian.com/git/tutorials/install-git 


### Install Docker Desktop 

https://www.docker.com/get-started 


### Install .NET Core 3.1 

https://dotnet.microsoft.com/download/dotnet-core/3.1 


### .NET Configuration

// From the project folder 

dotnet add src/BookingApi/BookingApi.csproj package Npgsql.EntityFrameworkCore.PostgreSQL --version 3.1.4


### Docker 

#### Starting Docker 

// From the project folder  

docker-compose up -d 

#### Stoping Docker 

// From the project folder  

docker-compose down # If you use `docker-compose down -v`, any saved data will be lost!


#### Rebuilding / redeploying the booking api container

// From the project folder  

docker-compose up --force-recreate --no-deps -d --build booking_api 

### Database 

All the information about the database can be found on the seed.sql file, also its access credentials can be found on the docker-compose.yml file.

### API Endpoints

The following endpoints are being provided:  

http://localhost:7070/api/room - GET

http://localhost:7070/api/patient - GET  

### Tasks

Create an endpoint that allows "Manual" and "Auto" booking appointments. It should respond on the following address:

http://localhost:7070/api/appointment - POST 

#### Manual Booking 

The Manual booking should accept the following input request:

Request:  
`
{
    "roomCode": "R1",
    "patientCode": "P-A",
    "bookingStartDate": "31/07/2020",
    "bookingEndDate": "07/08/2020"
}
`  
And it should return the the following output response:

Response:  
`
{
    "bookingNumber": 1,
    "patient": {
        "id": 1,
        "code": "P-A",
        "name": "Andrew"
    },
    "room": {
        "id": 1,
        "code": "R1",
        "description": "Room R1"
    },
    "bookingStartDate": "2020-07-31T00:00:00",
    "bookingEndDate": "2020-08-07T00:00:00",
    "requestedFixedDuration": 0,
    "requestedExtraDuration": 0
}
`

#### Auto Booking 

The Auto booking should accept the following input request:

Request:  
`
{
    "roomCode": "R2",
    "patientCode": "P-B",
    "bookingStartDate": "31/07/2020",
    "requestedFixedDuration": 2,
    "requestedExtraDuration": 5
}
`    

The output format will be the same as per "Manual Booking". The specific room and end date of the booking will be determined by the auto allocation algorithm (see Task 3 on the document emailed to you).

#### Constraints  

The date fields ("bookingStartDate", "bookingEndDate") must accept only valid dates using the format "dd/MM/yyyy".  
The roomCode field must be an existing room on the DB. 
The patientCode field must be an existing patient on the DB. 