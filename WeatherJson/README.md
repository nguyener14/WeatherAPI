This is a .NET 8 Web API that fetches weather data from multiple cities and generates a JSON weather report containing the city with the lowest minimum temperature for each day.

**Installation and Setup:**
Make sure to have the following installed
  .NET 8
  Visual Studio 2022 (or Visual Studio Code)
  Git (if cloning repository)

If cloning from Git, use the following command:
git clone https://github.com/YOUR_GITHUB_USERNAME/WeatherAPI.git

If you received this project as a .zip, extract it first and then open the solution file (*.sln) in Visual Studio.

**Running the API**
Make sure WeatherAPI is selected as the startup project and run the program using the start button on the UI or press F5.
The Swagger UI should display in the web browser with your localhost as the URL.
**Note: if there are issues with trusting certificates in the web browser, it can be bypassed by running as http instead of https.**

**Testing the API**
In the Swagger UI, click on the drop down and then press "Try it out" and execute the API listed as "generate-json".
Alternatively, you can test in Postman by making a GET request to the API path: http://localhost:5000/api/weather/generate-json

**JSON Output**
After running the API, you should get a response output in JSON format as well as a JSON file in the directory listed as "output" in the root directory of the project.