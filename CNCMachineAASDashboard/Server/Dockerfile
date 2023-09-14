FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CNCMachineAASDashboard/Server/CNCMachineAASDashboard.Server.csproj", "CNCMachineAASDashboard/Server/"]
COPY ["CNCMachineAASDashboard/Client/CNCMachineAASDashboard.Client.csproj", "CNCMachineAASDashboard/Client/"]
COPY ["CNCMachineAASDashboard/Shared/CNCMachineAASDashboard.Shared.csproj", "CNCMachineAASDashboard/Shared/"]
RUN dotnet restore "CNCMachineAASDashboard/Server/CNCMachineAASDashboard.Server.csproj"
COPY . .
WORKDIR "/src/CNCMachineAASDashboard/Server"
RUN dotnet build "CNCMachineAASDashboard.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CNCMachineAASDashboard.Server.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CNCMachineAASDashboard.Server.dll"]