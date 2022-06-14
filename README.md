After you download or clone the repo do the following:

Running the HEMS Task project:\
    - Make sure the instance of MSSQL is already installed on your machine (MSSQL 2017 was used to implement the task)\
    - Open the project in visual studio and configure your connection string in (appsettings.Development.json, appsettings.Production.json)\
    - Run the project\
    - Make sure which environment variable you are using: \
        http://localhost:4010; https://localhost:4011; Development environment\
        http://localhost:4020;https://localhost:4021; Production environment\
    - After running the project the database will be created, if you need to seed the database!!, please run the HemsDbSeeder script\

Notes:\
    - The second part of the optional task (Create Pdf for all data) hasn't been implemented because of the other commitments and for not exceeding the deadline\
    - Table hasn't been used on the main pages (Categories, Types, Products) as mentioned in the test, but it was used on the "Create All In One" page to represent data in a different way, moreover of it's more suitable in this page to use table than using cards elements\
    - The default behavior on deleting an entity is: on delete cascade as it's not mentioned in the test to use another behavior\
