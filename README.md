# SimpsonsSearch

.Net Core web application implementing a search engine for the tv-show 'The Simpsons'.

This project uses Lucene.net as search engine library:  
https://lucenenetdocs.azurewebsites.net/

Deployment of this application: 

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

Alternatively: manual deployment

- clone rep
	git clone https://github.com/informationretrieval19/SimpsonsSearch.git
	
- .net core Runtime is needed to run the application

	- version 2.1.505 is needed
	- follow this guide for the installation of the runtime:
		https://dotnet.microsoft.com/download/linux-package-manager/ubuntu18-04/runtime-2.1.5
		
- start application

	- change directory to ../simpsonssearch/simpsonssearch/simpsonssearchproject/simpsonssearch/bin/release/netcoreapp2.1
	dotnet 
	
	simpsonssearch.dll 

-------------------------------------

How to use this search engine:


- The red search button ('Search') uses the baseline version of the search engine. 

- The matching terms between query and documents will be highlighted in bold.

- The green search button ('SearchAdvancedOnlyInText') uses Query Refinement for a certain amount of topics (topics 15-50). Only script lines will be searched (mainly dialogue).

- The yellow search button ('SearchAdvancedAllTerms') uses the same Query Refinement, but will search in all fields (location, characters).

- Results are scenes, not whole episodes. Information about the episode and season where the scene appears will be given, though.
 
- A timestamp was added so you can conveniently skip to a scene of interest when watching the show.
