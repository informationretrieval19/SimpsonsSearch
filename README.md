# SimpsonsSearch

.Net Core web application implementing a search engine for the tv-show 'The Simpsons'.

This project uses Lucene.net as search engine library:  
https://lucenenetdocs.azurewebsites.net/

Deployment of this application using Ubuntu Terminal:   

Step 1: Clone repository    

	git clone https://github.com/informationretrieval19/SimpsonsSearch.git  
	
Step 2: .net core Runtime is needed to run the application

	wget -q https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb  
	sudo dpkg -i packages-microsoft-prod.deb  
	sudo add-apt-repository universe  
	sudo apt-get install apt-transport-https  
	sudo apt-get update  
	sudo apt-get install dotnet-sdk-2.2  
		
Step 3: Start application

	cd SimpsonsSearch/SimpsonsSearchProject/SimpsonsSearch  
	dotnet restore  
	dotnet build  
	dotnet run   
	 
-------------------------------------

How to use this search engine:


- The red search button ('Search') uses the baseline version of the search engine. 

- The matching terms between query and documents will be highlighted in bold.

- The green search button ('SearchAdvancedOnlyInText') uses Query Refinement for a certain amount of topics (topics 15-50). Only script lines will be searched (mainly dialogue).

- The yellow search button ('SearchAdvancedAllTerms') uses the same Query Refinement, but will search in all fields (location, characters).

- Results are scenes, not whole episodes. Information about the episode and season where the scene appears will be given, though.
 
- A timestamp was added so you can conveniently skip to a scene of interest when watching the show.
