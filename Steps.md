Azure Func tools, .NET 6

```bash
npm install -g azurite
mkdir Azurite
cd Azurite
azurite
```

```bash
func init AzureFunctionsWithTwilioBindings --dotnet
```

```bash
cd AzureFunctionsWithTwilioBindings
```

```bash
func new --name SendSmsHttp --template "HTTP trigger"
func new --name SendSmsTimer --template "Timer trigger"
```

```bash
func start
```

```bash
dotnet add package Microsoft.Azure.WebJobs.Extensions.Twilio
```
https://www.nuget.org/packages/Microsoft.Azure.WebJobs.Extensions.Twilio

Update code

Update local.settings.json