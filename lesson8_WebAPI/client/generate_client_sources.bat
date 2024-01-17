REM install java
winget install Oracle.JavaRuntimeEnvironment

REM download swaggen-codegen from https://repo1.maven.org/maven2/io/swagger/codegen/v3/swagger-codegen-cli/
REM download some not-very-new version. ; )
REM for exapmle swagger-codegen-cli-3.0.46.jar - <jar>

REM start your WEb API project
REM copy your swagger doc link
REM like this http://localhost:5016/swagger/v1/swagger.json - <link>

REM generate the client codegen
java -jar <jar> generate -i <link> -l csharp-dotnet2
