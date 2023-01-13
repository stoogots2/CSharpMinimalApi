# CSharpMinimalAPI Example


**This is a quick and dirty example of .NET 6's Minimal API.  Extremely cool how few lines of code it takes.**

Using it and testing it is done with Postman.
TCP Ports are http://localhost:5015 and https://localhost:7015.

I've included the postman collection for fun as _MinimalAPI.postman_collection.json.

To Test an Add, Create a POST request to add a new developer to the list {{$guid}} creates and injects a new guid into the request.
{
        "Id": "{{$guid}}",
        "fullName": "Forest Laurenceton",
        "languages": "C#, GO, Javascript, Python, VB, SQL"
}
After you add a few developers:
To Test a Get (all), Create a GET request to http://localhost:5015/Developers
which should return the whole list.

This MinimalAPI supports PUT and DELETE commands which are update and delete, respectively.
So to update, Create a PUT request to http://localhost:5015/Developers with the all the updated information in the body
and include the guid
{
        "Id": "28a88907-e26f-4d09-a579-ee1b9c14b4ef",
        "fullName": "Laurence Jesterton",
        "languages": "C#, VB, SQL"
}
DELETE => Create a DELETE request 
http://localhost:5015/Developers/28a88907-e26f-4d09-a579-ee1b9c14b4ef 
and specify the guid at the end like above.


