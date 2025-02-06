
/// For Reading CMD Arg.

//  string browerName = TestContext.Parameters["browser"];

    // dotnet test SeleniumC#Framework.csproj --filter TestCategory=Mouse CLick


    dotnet test SeleniumC#Framework.csproj -- TestRunParameters.Parameter(name=\"browser\", value=\"Firefox\")


____________________________________________________________________________________________________________________________________________

Setup For Allure ---

1- install dependency using nuget
2- install npm
3- install allure  using  
    npm install -g allure-commandline --save-dev
4- To open Allure report
     -- Go to allure- result file 
     -- after then run cmd
     +++ allure serve allure-results
-------------------------------------------------------------------------

RUn Jenkins
-- go to folder where , jenking.war is located
  after that run command
   --  java -jar jenkins.war

   --------
   TO Run jenkin with Git
     -- We need ngrock tool, this will host our jenkins on web server



    