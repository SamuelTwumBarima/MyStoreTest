# MyStoreTest

Create a folder in C:\Documents named Dev
Clone the repository into Dev folder
Open the solution
Find the folder named "TestDataAccess" , Identify the Excel file named "TestData.xlsx" and right click on it then click properties, now copy the full path i.e C:\users\Your Name ....
In the solutions explorer; Open the folder named Configurations and open the config file named Environment.config
In the config file set the value of the TestDataSheetPath to the file path of the TestData.xlsx that was copied i.e C:\Users\Name\Documents\Dev\MyStoreTest\MyStoreTest\TestDataAccess\TestData.xlsx
Save and your test will be ready to be run :)

If the test fails due to accesing the data because of Provider=Microsoft.ACE.OLEDB.12.0, Then please download a compatitable version of Microsoft.ACE.OLEDB.12.0 for your machine
or uninstall and install microsoft office again (hopefully you wont have to) :)