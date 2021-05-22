#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Api/Read/EmergingBooking.ApiRead/EmergingBooking.ApiRead.csproj", "Api/Read/EmergingBooking.ApiRead/"]
RUN dotnet restore "Api/Read/EmergingBooking.ApiRead/EmergingBooking.ApiRead.csproj"
COPY . .
WORKDIR "/src/Api/Read/EmergingBooking.ApiRead"
RUN dotnet build "EmergingBooking.ApiRead.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EmergingBooking.ApiRead.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EmergingBooking.ApiRead.dll"]