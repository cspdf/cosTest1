AOT/
$ mkdir cosTest
$ cd cosTest
$ dotnet new blazorwasm
$ vim *.csproj
add 
<RunAOTCompilation>true</RunAOTCompilation>
to 
the beginning of <PropertyGroup>

$ dotnet add reference ../../../cspdf/cosobj/cosobj.csproj
Reference `..\..\..\cspdf\cosobj\cosobj.csproj` added to the project.


* add test code to blazor(razor page) for cosobj
...
/costest -> CosTest.razor, CosTest.cs


$ time dotnet publish -c Release


