# ExchangeRateAPI


Steps to run the application and test the api
- Open the solution in Visual Studio.
- Make sure the startup project is setup to ExchangeRateAPI
- Now start the application
- It should open a browser with this get request "https://localhost:5001/exchangerate".
- I have added the above get request to make sure the api project is running sucessfully.
- Once you have the message "App is running Successfully" on the browser.
- Open postman desktop client.
- Make a API GET request to "https://localhost:5001/exchangerate/GetExchangeRatesByDates"
- In the request body (Raw and Json), add the inputs, for instance
{
    "dates": [ "2018-02-01", "2018-02-15", "2018-03-01" ],
    "baseCurrency": "SEK",
    "targetCurrency": "NOK"
}
- Now make a request, this should return the desired output.
- You can also use Postman collection.
