# Mov4e

1. In order to run this application you will need a few things!
  - Visual Studio 2017+
  - .Net 8.0 installed
  - MySql Workbench
  - MySql Notifier
  - MySql Server 8.0
  - MySql Connector Net 8.0.19 (IT WONT'T WORK WITH DIFFEREN VERSION)
  - MySql For Visual Studio 1.2.9

2. The application works with localhost DB.
  - Open MySqlWorkbench and if you don't have connections create one! When local server opened, in the left panel you will see
    tab control - Administration/Schemas. Click Administration. From menu Management choose Data import/Restore. After that choose
    import from Self-Contained File. In the folder DB you will find Mov4eDB dump file. Load that file and import it. If you have 
    followed these steps correctly "mov4e" schema would appear in Schemas.
    
3. Individual connection string is required!
  -The application won't start without connection string also! Due to the fact every local server is unique, every connection string is 
   unique too. Load VS solution. Open App.config file. Between <connectionStrings> and </connectionStrings> you must put your connection string.
   Example of conn. string you will find in connectionStringTxt.txt in the DB folder. Notice that in this example there are a lot of dashes
   "------------------". These dashes MUST be replaced with your local server credentials! If you dont know how to write your credentials, don't
   worry, there will be example of that too in connectionStringTxt.txt!
  
