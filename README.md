Nimbus is a Navigational application that currently only targets windows

hate to admit it but had to start a new Repository for this project so instead of deleting a ton of **/obj/** and **/bin/** folders I should not have been tracking
but was because of my poor .git ignore file. between time and to display my jourmey I decided to just own it and display it https://github.com/Slikrick87/Nimbus

Will have to run some commands in powershell to get the database up and running

dotnet tool install --global dotnet-ef

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet ef migrations add InitialCreate

dotnet ef database update

and had to manually change nuget package for Microsoft.EntityFrameworkCore.Design to version 8.0.3

currently that should at least get you to a white loading screen on a machine new to the project

if you find any issues causing this white screen or even just have an opinion please let me know!


Using a database (local for now but remote database would be best) for the fleet of trucks to more easily track mileage on trucks and some commonly replaced parts like 
tires and oil through user daily mileage input will automatically update mileage on said trucks tires and oil change

using same local database for adding addresses to a particular route that a truck is also assigned to.

adding a Google maps api to display a map with pins showing where each address is on a particular route providing a visual aid to help the driver to plan their route for that day
using an ordered list or dictionary (not sure yet) to provide a way for driver to reorder the list of addresses at their discretion

implementing a google directions api to allow the driver to get directions provided to each address and hopefully just hit a button to give directions to the next address on list



THINGS I WOULD LIKE TO ADD IF TIME ALLOWS

Create login for security and to track hours for drivers

serve an api to allow someone to input an address or id# for stops to see when the stop was made by adding a datetime type to addresses for when the stop is marked done

create code to allow a text file in json to be possibly used to add addresses to a particular stop or create a seperate database to call on to add addresses for a route

implement the use of an api to send a weekly email to show the mileage and hours of the fleet

Create unit tests to aid in reliability and debugging program

implement regex to ensure proper address input


Requirements I've met:
1. Integrated an SQLite CRUD database with three tables with relationships between addresses which tied to routes list and trucks table with mileage for commonly serviced parts
   is tied to routes to display which trucks are on which route.
2. In Nimbus/Nimbus.Shared/Maps.razor I Implemented a Google Maps API and Google Geocode Api to get coordinates and display a map with pins showing where each address is in a particular route's stops table.
3. Implemented dozens of Functions/Methods
4. Through the use of a List (Nimbus/Nimbus.Shared/Maps.razor) I have created a way for the driver to reorder the list of addresses at their discretion.(which won't be of much use until
   I can implement a google directions api to allow the driver to get directions provided to each address and hopefully just hit a button to give directions to the next address on list)
4. Exposed an endpoint in Nimbus/Nimbus.Web.API to allow database interactions like adding addresses to a route or deleting routes(not tied to Nimbus Project has to run independently)
5. Made basically the entire project asynchronous (can mostly be found in Nimbus/Nimbus.Shared/Repositories) except one or two methods I just recently added and haven't gotten around to making async yet.
6. Have three tables in my database with relationships between them.

