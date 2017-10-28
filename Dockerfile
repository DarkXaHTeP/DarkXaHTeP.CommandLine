FROM microsoft/dotnet:2.0-sdk

ARG NUGET_SOURCE
ARG NUGET_USERNAME
ARG NUGET_API_KEY

ENV NUGET_API_KEY $NUGET_API_KEY

WORKDIR /app

COPY . ./
RUN dotnet restore

RUN sed -i "s|{NUGET_SOURCE}|$NUGET_SOURCE|g" NuGet.config
RUN sed -i "s|{NUGET_USERNAME}|$NUGET_USERNAME|g" NuGet.config
RUN sed -i "s|{NUGET_API_KEY}|$NUGET_API_KEY|g" NuGet.config

RUN chmod +x ./test.sh
RUN chmod +x ./publish.sh
