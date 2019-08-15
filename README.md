# SimpsonsSearch

.Net Core Web Projekt zur Umsetzung einer Suchmaschine für die Serie "Die Simpsons".

Umgesetzt mit Lucene.net als Suchmaschinen Library  
https://lucenenetdocs.azurewebsites.net/

Deployment: 

1. Ubunto docker installation:

	  sudo apt install docker.io

2. Verify docker installation:

	  docker --version
  
3. Start application:
	- clone git repo: https://github.com/informationretrieval19/SimpsonsSearch	
  
	- navigate to project folder from command prompt 
  
    ../simpsonssearch/simpsonssearchproject/simpsonssearch
  
    docker build -t simpsonssearch .
    
    docker run -d -p 8080:80 --name myapp SimpsonsSearch
  
	- go to localhost:8080

Guides:
https://phoenixnap.com/kb/how-to-install-docker-on-ubuntu-18-04

https://docs.docker.com/engine/examples/dotnetcore/

-------------------------------------

Alternativ: manuelles Deployment

- clone rep
	git clone https://github.com/informationretrieval19/SimpsonsSearch.git
	
- benötigt wird .net core Runtime um Anwendung auszuführen 

	- version 2.1.505 wird benötigt 
	- diesem guide folgen zur installation der runtime:
		https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/runtime-2.1.5
		
- start application

	- change directory to ../simpsonssearch/simpsonssearch/simpsonssearchproject/simpsonssearch/bin/release/netcoreapp2.1
	dotnet 
	
	simpsonssearch.dll 

