# SympliProject

## How to run the FrontEnd:
* Ensure you have Node installed (At least Node 12) 
* Ensure you have Angular CLI installed (at least Angular 11)
* Using your cmdline of choice, navigate to the SympliProjectWeb folder and run `ng serve`

## How to run the Backend
* Ensure you have the .NET CLI installed
* Using your cmdline of choice, navigate to the SympliProject folder and run `dotnet run`


## Improvements

### Performance
Most of the performance hit in this app is in waiting for the google http response. If this were to become a problem in the future, we could increase the cache time in order to make less overall requests to the search engine

### Availability
The most obvious way in which we could increase availability would be to containerize the app and deploy it with a container orchestrator such as kubernetes. With this, we could easily create redundant instances of the app that would minimize downtime should something go wrong. 

### Reliability 
The reliability of a service can be increased not only through quality code, but also through the automation of a release pipeline. If something were to go wrong, then a fast release pipeline would increase the overall reliability of the service. 
