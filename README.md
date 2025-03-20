Nimbus is a Navigational application

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

