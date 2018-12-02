FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY . ./activitylog/
WORKDIR /app/activitylog
RUN dotnet restore
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.1-aspnetcore-runtime AS runtime
WORKDIR /app
COPY --from=build /app/activitylog/out ./
ENTRYPOINT ["dotnet", "activitylog.dll"]
