# Answers to Technical Questions

###### 1. How long did you spend on the coding assignment? What would you add to your solution if you had more time? If you didn't spend much time on the coding assignment then use this as an opportunity to explain what you would add.

 * **8 hours**
 * add to your solution
    - Error handling 
    - Caching 
    - API Rate Limiting 
    - Authorize


###### 2. What was the most useful feature that was added to the latest version of your language of choice?

 * File-Scoped Namespace Declaration

    ## Code Snippet:

  ```
    // Before C# 10
    namespace Cryptocurrency.AppService.ExchangeRates.Queries.Get
    {
        public class GetExchangeRatesQueryResult
        {
            public decimal PriceInUsd { get; set; }
            public Dictionary<string, decimal> PricesInOtherCurrencies { get; set; } = new();
        }
    }

    // C# 10 and onward
    namespace Cryptocurrency.AppService.ExchangeRates.Queries.Get;
    public class GetExchangeRatesQueryResult
    {
        public decimal PriceInUsd { get; set; }
        public Dictionary<string, decimal> PricesInOtherCurrencies { get; set; } = new();
    }
   ```


###### 3. How would you track down a performance issue in production? Have you ever had to do this?

 *	Monitoring
 *	Log
 *	DotTrace, botnet counters
 *	SQL Server Profiler


###### 4. What was the latest technical book you have read or tech conference you have been to? What did you learn?

  * Okala Engineer Recruitment Test
   >> A Markdown file (with the .md file extension) is a plain text file that uses a lightweight markup language called Markdown.


###### 5. What do you think about this technical assessment?

    Not Bad

###### 6. Please, describe yourself using JSON.
```
{
  "name": "Seyed Abolfazl Sharifi",
  "age": 29,
  "skills": [
    "C#",
    "ASP.NET Core",
    "Microservices",
    "Clean Architecture",
    "Azure",
    "SQL/NoSQL Databases"
  ],
  "experience": {
    "years": 7,
    "companies": [
      {
        "name": "Gaj International Publications",
        "role": "Technical Development Team Expert",
        "duration": "January 2022 - Present"
      },
      {
        "name": "Dadkhah Aryan Mehregan",
        "role": "Chief Technology Officer / IT Manager",
        "duration": "December 2020 - December 2021"
      },
      {
        "name": "APANCO",
        "role": "Chief Technology Officer",
        "duration": "March 2020 - November 2020"
      },
      {
        "name": "Text Aspect",
        "role": "Test Engineer",
        "duration": "October 2019 - February 2020"
      },
      {
        "name": "Eideh Tazan Shomal",
        "role": "Senior Web Developer",
        "duration": "February 2016 - March 2018"
      }
    ]
  },
  "education": {
    "degree": "Bachelor of Science in Software engineering",
    "university": "Rouzbahan University",
    "year_of_graduation": 2017
  },
  "personal_interests": [
    "Reading a book",
    "Watching a movie",
    "Listening to music"
  ]
}
```


