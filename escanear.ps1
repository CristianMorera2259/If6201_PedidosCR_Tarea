dotnet sonarscanner begin /k:"WebApiNet10-Laboratorio" /n:"Web API .NET 10 - Laboratorio" /d:sonar.host.url="http://localhost:9000" /d:sonar.token="$env:SONAR_TOKEN"
dotnet build --no-incremental
dotnet sonarscanner end /d:sonar.token="$env:SONAR_TOKEN"
