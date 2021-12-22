//=== blazor wasm app
code-behind tips:
Counter.razor --> code-behind Counter.cs (or Counter.razor.cs?)
public partial class Counter: ComponentBase

* "partial" modifier is must as class Counter is implicitly declared within Counter.razor


xxx add namespace ex2 to Counter.cs
xxx add @namespace ex2 to Counter.razor

-->
add namespace ex2.Pages to Counter.cs
no need to add @namespace to Counter.razor
its namespace is by default ex2.Pages following the folder hierarchy

namespace ex2 is created by "dotnet new blazorwasm" template
namespace ex2.Shared  and ex2.Pages follow the folder hierarchy


//===
$ dotnet new blazorwasm
$ vim *.csproj
add 
<RunAOTCompilation>true</RunAOTCompilation>
to 
the beginning of <PropertyGroup>


$ time dotnet publish -c Release

[warning2021.12.06]
embuilder : warning : LLVM version for clang executable "/mnt/sdb1/workspaces/emsdk/upstream/bin/clang" appears incorrect (seeing "14.0", expected "13.0") [-Wversion-check] [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]

--> as i executed "source ./emsdk_env.sh" under /mnt/sdb1/workspaces/emsdk/
now dotnet got emsdk from /mnt/sdb1/workspaces/emsdk instead 
from "dotnet workload install wasm-tools"

-->
real    17m12.492s
user    15m10.724s
sys     0m57.992s

-->
$ cd  bin/Release/net6.0/publish/wwwroot
$ python3 -m http.server

open another terminal
$ chrome http://localhost:8000


-->
under  bin/Release/net6.0/publish/wwwroot/_framework/
- dotnet.wasm
- dotnet.timezones.blat
- dotnet.6.0.0.pod64u2lpb.js
- blazor.webassembly.js

$ cd bin/Release/net6.0/publish/wwwroot/_framework/
$ ls -1(one) *.dll

ex2.dll
Microsoft.AspNetCore.Components.dll
Microsoft.AspNetCore.Components.WebAssembly.dll
Microsoft.AspNetCore.Components.Web.dll
Microsoft.Extensions.Configuration.Abstractions.dll
Microsoft.Extensions.Configuration.dll
Microsoft.Extensions.Configuration.Json.dll
Microsoft.Extensions.DependencyInjection.Abstractions.dll
Microsoft.Extensions.DependencyInjection.dll
Microsoft.Extensions.Logging.Abstractions.dll
Microsoft.Extensions.Logging.dll
Microsoft.Extensions.Options.dll
Microsoft.Extensions.Primitives.dll
Microsoft.JSInterop.dll
Microsoft.JSInterop.WebAssembly.dll
System.Collections.Concurrent.dll
System.Collections.dll
System.ComponentModel.dll
System.Memory.dll
System.Net.Http.dll
System.Net.Http.Json.dll
System.Net.Primitives.dll
System.Private.CoreLib.dll
System.Private.Runtime.InteropServices.JavaScript.dll
System.Private.Uri.dll
System.Runtime.CompilerServices.Unsafe.dll
System.Runtime.dll
System.Text.Encodings.Web.dll
System.Text.Json.dll

//=== codebehind
https://devkimchi.com/2021/03/10/blazor-code-behind/
https://gist.github.com/justinyoo/adf1539f817c4b604c5cedc421e96aed

[err]
The type or namespace name 'ComponentBase' could not be found
-->
Namespace:
	Microsoft.AspNetCore.Components
Assembly:
	Microsoft.AspNetCore.Components.dll
	
-->
CSC : error RZ3008: Tag helpers cannot target tag name '<global namespace>.Counter' because it contains a '<' character. [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]
CSC : error RZ3008: Tag helpers cannot target tag name '<global namespace>.Counter' because it contains a ' ' character. [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]
CSC : error RZ3008: Tag helpers cannot target tag name '<global namespace>.Counter' because it contains a '>' character. [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]
/mnt/sdb1/workspaces/AOT/ex2/Pages/Counter.razor(5,21): error CS0103: The name 'CurrentCount' does not exist in the current context [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]
/mnt/sdb1/workspaces/AOT/ex2/Pages/Counter.razor(7,43): error CS0103: The name 'IncrementCount' does not exist in the current context [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]

--> add namespace ex2 to Counter.cs
-->
Counter.razor(5,21): error CS0103: The name 'CurrentCount' does not exist in the current context [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]
/mnt/sdb1/workspaces/AOT/ex2/Pages/Counter.razor(7,43): error CS0103: The name 'IncrementCount' does not exist in the current context [/mnt/sdb1/workspaces/AOT/ex2/ex2.csproj]

-->
add
@namespace ex2
to Counter.razor


//===
after modifying Counter.razor and adding code-behind Counter.cs
rebuild/publish

 $ time dotnet publish -c Release
...
 Optimizing dotnet.wasm ...
  Compressing Blazor WebAssembly publish artifacts. This may take a while...
  ex2 -> /mnt/sdb1/workspaces/AOT/ex2/bin/Release/net6.0/publish/

real    4m45.507s
user    4m22.776s
sys     0m6.120s


//===
add proj reference to cosmock.csproj [the cosobj mock] 
--> cos.mock.CosObj/cos.mock.CosDict


the 3rd time to publish

 $ time dotnet publish -c Release
...
 Optimizing dotnet.wasm ...
  Compressing Blazor WebAssembly publish artifacts. This may take a while...
  ex2 -> /mnt/sdb1/workspaces/AOT/ex2/bin/Release/net6.0/publish/

real    6m11.240s
user    5m52.736s
sys     0m8.956s

blazor.boot.json
blazor.webassembly.js
cosobj.dll
dotnet.6.0.0.pod64u2lpb.js
dotnet.timezones.blat
dotnet.wasm
ex2.dll
icudt_CJK.dat
icudt.dat
icudt_EFIGS.dat
icudt_no_CJK.dat


