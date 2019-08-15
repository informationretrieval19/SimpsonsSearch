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
