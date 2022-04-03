#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/User.DDD.WebApi/User.DDD.WebApi.csproj", "src/User.DDD.WebApi/"]
COPY ["src/User.DDD.Application/User.DDD.Application.csproj", "src/User.DDD.Application/"]
COPY ["src/User.DDD.Domain/User.DDD.Domain.csproj", "src/User.DDD.Domain/"]
COPY ["src/User.DDD.Core/User.DDD.Core.csproj", "src/User.DDD.Core/"]
COPY ["src/User.DDD.Intrastructure/User.DDD.Intrastructure.csproj", "src/User.DDD.Intrastructure/"]
RUN dotnet restore "src/User.DDD.WebApi/User.DDD.WebApi.csproj"
COPY . .
WORKDIR "/src/src/User.DDD.WebApi"
RUN dotnet build "User.DDD.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "User.DDD.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "User.DDD.WebApi.dll"]