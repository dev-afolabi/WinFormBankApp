FROM mcr.microsoft.com/dotnet/runtime:3.1 AS base
WORKDIR /app
COPY *.sln .


FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
COPY BankApp.Docker.UI/*.csproj BankApp.Docker.UI/
RUN dotnet restore BankApp.Docker.UI/*.csproj
COPY . .


# WORKDIR "/app/BankApp.Docker.UI"
# RUN dotnet build "BankApp.Docker.UI.csproj" -c Release -o /app/build

FROM build AS publish
WORKDIR /app
RUN dotnet publish "BankApp.Docker.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BankApp.Docker.UI.dll"]
