FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["FluentValidation-WeekOne-AkbankBC/FluentValidation-WeekOne-AkbankBC.csproj", "FluentValidation-WeekOne-AkbankBC/"]
RUN dotnet restore "FluentValidation-WeekOne-AkbankBC/FluentValidation-WeekOne-AkbankBC.csproj"
COPY . .
WORKDIR "/src/FluentValidation-WeekOne-AkbankBC"
RUN dotnet build "FluentValidation-WeekOne-AkbankBC.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FluentValidation-WeekOne-AkbankBC.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FluentValidation-WeekOne-AkbankBC.dll"]
