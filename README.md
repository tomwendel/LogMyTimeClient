# LogMyTime Client
This is a C# library for Timetracker LogMyTime.de

## Communication Layer
In the first place this library allows you to communicate with the LogMyTime API on a very basic, but typed level. The communication layer only wraps the different data calls to the API and allows to get or send data to the server. It handels the Authentication, HTTP Calls and serialization of everything.

## Cache Layer
In the second step the library handles data updates on a more intelligent way by caching long term data and updates only required stuff by using the ChangesDigest call of the LogMyTime API.

For more information about the API visit
https://www.logmytime.de/Api
