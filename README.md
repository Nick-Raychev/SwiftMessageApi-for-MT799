# SwiftMessageApi-for-MT799
**Overview**

This project is a .NET 7 web API designed to handle Swift MT799 messages. It parses incoming messages, extracts relevant fields, and stores them in an SQLite database. Notably, the parsing logic is implemented without utilizing pre-built Swift libraries, ensuring a tailored approach to message handling. The project integrates NLog for robust logging capabilities and Swagger for clear API documentation.

**Features**

- Handles Swift MT799 messages via a .NET 7 web API.
- Parses incoming messages and extracts essential fields.
- Stores parsed data in an SQLite database.
- Custom parsing logic implemented without pre-built Swift libraries.
- Utilizes NLog for comprehensive logging.
- Integrates Swagger for clear API documentation.
  
**Requirements**
  
- .NET 7 SDK
- SQLite
- NLog
- Swagger

**Usage**
- Build and run the project.
- Access the API endpoints using Swagger documentation.
- Send Swift MT799 messages to the API for parsing and storage.
- Monitor logs for parsing and API interaction details.
