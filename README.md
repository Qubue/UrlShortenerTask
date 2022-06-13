# UrlShortener

Provide some details about your application 

## How to start?

### Prequisties
The application is using reactJS on frontend. It is necessary to have nodejs installed on the machine. 

### How to run
1. From UrlShortener.WebApplication/src folder run npm start.
2. Go to the localhost:3000
3. Run the UrlShortener.WebApplication
3. The input with 2 button is present
4. In the input provide the url
5. Click button submit to generate shortUrl
6. Click button getAll to get all the generated mappings

## Key assumptions 
`Section description: If you have any assumption during your implementation, please provide them here.`

## Future Ideas
# To do:
1. Add some visible information on frontnet when passed url is not valid (currently only backend returns 400) or any other request fails
2. Extend unit tests for all methods and added classes
3. Add pagination for already registered URL
4. Deeper analysis of possible edge cases
5. Try to make the url tinier
6. Make it more generic, allow to store any long string.
6.1 Validate input based on input type- ITypedValidator
6.2 URLTransformer could depend on ITypedValidator interface
7. Move the validation to separate class instead of validating data in URLtransformer

## Task Description 
>Build a URL shortening service like TinyURL. This service will provide short aliases redirecting to long URLs.
### Why do we use Url shortening?
URL shortening is used to create shorter aliases for long URLs. We call these shortened aliases “short links.” Users are redirected to the original URL when they hit these short links. Short links save a lot of space when displayed, printed, messaged, or tweeted. Additionally, users are less likely to mistype shorter URLs.

For example, if we shorten the following URL: `https://www.some-website.io/realy/long-url-with-some-random-string/m2ygV4E81AR`

We would get something like this: `https://short.url/xer23`

URL shortening is used to optimize links across devices, track individual links to analyze audience, measure ad campaigns’ performance, or hide affiliated original URLs.

### URL shortening application should have:
 - A page where a new URL can be entered and a shortened link is generated. You can use Home page.
 - A page that will show a list of all the shortened URL’s.
### Functional Requirements:
- Given a URL, our service should generate a shorter and unique alias of it. This is called a short link. This link should be short enough to be easily copied and pasted into applications.
- When users access a short link, our service should redirect them to the original link.
- Application should store logs information about requests.
### Non-Functional Requirements:
- URL redirection should happen in real-time with minimal latency.
- Please add small project description to Readme.md file.
### During implementation please pay attention to:
- Application is runnable out of box. If some setup is needed please provide details on ReadMe file.
- Project structure and code smells.
- Design Principles and application testability.
- Main focus should be on backend functionality, not UI.
- Input parameter validation.
- Please, don't use any library or service that implements the core functionality of this test.
### Other recommendation:
- You may change UI technology to any other you are most familiar with.
- You can use InMemory data storage.
- You can use the Internet.
# May the force be with you {username}!
