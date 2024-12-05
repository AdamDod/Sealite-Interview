Assumptions 
- A direct link cannot reconnect to the same town
- A direct link cannot have a distance of 0

Overview

	Based on the question promt this is a directional weighted graph problem.

	The first step to solve this is understanding how to interperate this in c#.

	To do this i used a matrix that represents all possible connections between towns as well as their distance (or weight)

	In technical terms i created a Directed Graph where towns represented the Vertices and Routes represented the Edges

	I have not worked on graph problems before so basic knowledge of them was found prior to starting this challenge

Setup

	The Graph will be represented by the Graph class which holds a Matrix property and a NumVert property

	When the Graph is initialised we will use a property to generate the empty matrix size (in this case 5)

	Once the Graph is initialised we can start to add hte Edges including the weights of the Edge

	As this is a directional graph we will only populate one way, as the majority of routes are one way we dont need to add complexity by adding an undirected option

Problem 1 - Find the distace between routes

	With the created graph we can now query to find the distance between routes.

	The most lengths provided for a route is 4, however we dont need to assume this and can use an array to represent the route 

	To find the length of the route we need to add all the edge weights together

Problem 2 - A route that does no exist

	In this case i decided to throw an exception, assuming that this will be a part of a larger application that can give the user better feedback
	For the unit tests we can just assert that the exception will occur

Problem 3 - Find the number of trips from point to point with a max of x stops
	
	For this problem we need to find all paths given a max depth 

	To do this we can keep a running total of the depth per recursion and compare that to the max depth at the start of each cycle 

	If the depth is greater thant the max depth we ignore that path and continue with the next adjacent vertice

Problem 4 - Length of the shortest route between 2 points
	
	This is a simmilar problem to 3, however we need to keep track of the distance (weight) 
	instead of the depth and only keep the route if it is smaller than the current smallest

Problem 5 - 
	
	This issue is simmilar to 4 however we want to find all options

	I did not have time to complete this one

Unit tests
	
	For the unit tests i used Xunit Throry as this allowed me to easily add all the test cases i needed and can also add more if needed

	
	


