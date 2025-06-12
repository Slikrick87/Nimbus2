Nimbus is a Navigational application that currently only targets windows

Created using a .NET Maui Framework with Blazor pages. Built for Server Side and Web Assembly


***This project requires a google maps API key to be set in the Nimbus.shared/Pages/Map.razor file for geocoding and map to work properly***
You can reach me on linkedin at:
https://www.linkedin.com/in/rickylynnthomasjr/
Email me at:  
Ricky Thomas
mailto:rjtom476@gmail.com
--------------------------------------------------------------------------------
Will have to run some commands in powershell to get the database up and running
or just clicking to initialize a new database in the project's home page will work as well but with provided sample data

if (initializing a new database without sample data)
	(navigate to **/Nimbus2/Nimbus/Nimbus/Nimbus.Shared in the powershell terminal to run these commands)
	just running 
	dotnet ef database may be enough but if not run the following commands in order:

	cd Nimbus
	cd Nimbus.Shared
	
	//Potentially will have to run dotnet update database to initialize the database
	//and may have to apply migrations 
	


Using an SQLite database (local for now but remote database would be best) for the fleet of trucks to more easily track mileage on trucks and some commonly replaced parts like 
tires and oil through user daily mileage input will automatically update mileage on said trucks tires and oil change

using same local database for adding addresses to a particular route that a truck is also assigned to.

adding a Google maps api to display a map with pins showing where each address is on a particular route providing a visual aid to help the driver to plan their route for that day
using an ordered list or dictionary (not sure yet) to provide a way for driver to reorder the list of addresses at their discretion

implementing a google directions api to allow the driver to get directions provided to each address and hopefully just hit a button to give directions to the next address on list

now the database contains a fourth table tied to trucks to track maintenance done to truck and cost to help management better assess costs per delivery still a WIP
but the logs are successfully being added to the database and displayed in the UI, and can also be filtered by truck and month.

THINGS I'M ADDING AS TIME PERMITS:

	Create login for security and to track hours for drivers
	
	serve an api to allow someone to input an address or id# for stops to see when the stop was made by adding a datetime type to addresses for when the stop is marked done
	
	create code to allow a text file in json to be possibly used to add addresses to a particular stop or create a seperate database to call on to add addresses for a route
	
	implement the use of an api to send a weekly email to show the mileage and hours of the fleet
	
	Create unit tests to aid in reliability and debugging program
	
	implement regex to ensure proper address input

also sometimes the waypoints for the google map API do not load in on the first page render so if they do not load may have to navigate to another page then back again
hopefully they load in first attempt but if not just a minor inconvenience that I'm working on fixing


