# Last.fm Score

> Rate the breadth of your musical palette

## Running the app

1. Get an API key from [Last.fm](https://www.last.fm/api/)
2. Add a file at `wwwroot/appsettings.Development.json` that looks like this:
    {
        "LastFmApi": {
            "ApiKey": "<your_api_key>"
        }
    }
3. Run with `dotnet run`
 
