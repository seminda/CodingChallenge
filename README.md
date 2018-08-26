# .NET Code Challenge

This is the solution to the code challenge. Below include all the details about the solution.

## assumptions
- All the data coming to the same folder and Data reading from that folder 
- Each track races are coming up with the prefix. 
	Ex: Caulfield track race files start with Caulfield_

## Development Decisions
- Use separate data client for each track to read the data 
- Due to the limited time didn’t use configuration to keep the file location 

## Possible Improvements   
- Can use parallel processing to improve the performance
- Can add more test to cover negative scenarios 
- File location should take from the configuration
- Hardcoded track prefix need to move to the configuration
