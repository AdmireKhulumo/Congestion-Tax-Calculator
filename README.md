# Congestion Tax Calculator Solution

## Overview
An ASP.NET Core Web API to solve the [Volvo congestion tax calculator challenge](https://github.com/volvo-cars/congestion-tax-calculator/blob/main/ASSIGNMENT.md).

## Details

1. The Web API runs on *localhost:5000*. By default, it opens to *localhost:5000/swagger* to display a Swagger UI for easy testing.
2. When running the solution, make a post request to *localhost:5000/congestiontax* and provide the following in the body as form data:
    ```
    {
        // name of the city with charging rules to apply
        city : string,
        
        // type of vehicle
        type: string,
        
        // dates to calculate for
        datesStr: string
    }
    ```

    * Supported value for city is "gothenburg" as there is only one city in the database.
    * Supported values for *type* are : car, motorcycle, bus, tractor, emergency, diplomat, foreign, military. Default is *car*.
    * Dates in datesStr must be supplied as "YYYY-MM-DD HH:MM:SS" and each separated by a comma.
    
    
3. The app is connected to a Cloud Firestore database with one record. The record consists of the following schema to represent the gothenburg charging amounts provided: 
 ```
 {
        // name of the city
        name: "gothenburg",
        
        // time ranges and their charges
        times: 
            [
                {timeRange: "06:00-06:29", amount: "8"},
                {timeRange: "06:30-06:59", amount: "13"},
                {timeRange: "07:00-07:59", amount: "18"},
                ...
            ]
 }
 ```
4. The database is currently live for testing of this solution.

 
## Example

* An example request body form data:
    ```
    {
        "city"      : "gothenburg",
        "type"      : "car",
        "datesStr"  : "2013-02-08 07:20:27, 2013-02-08 17:20:27"
    }
    ```

* Response:
    ```
    {
        "congestion-tax" : 31
    }
    ```
