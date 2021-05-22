#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Api/Write/EmergingBooking.ApiWrite/EmergingBooking.ApiWrite.csproj", "Api/Write/EmergingBooking.ApiWrite/"]
RUN dotnet restore "Api/Write/EmergingBooking.ApiWrite/EmergingBooking.ApiWrite.csproj"
COPY . .
WORKDIR "/src/Api/Write/EmergingBooking.ApiWrite"
RUN dotnet build "EmergingBooking.ApiWrite.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmergingBooking.ApiWrite.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmergingBooking.ApiWrite.dll"]