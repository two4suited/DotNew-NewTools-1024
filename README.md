# DotNew-NewTools-1024

## Base Features

- Aspire with Postgres

## New Tools

- [Redoc](https://github.com/Redocly/redoc) 
- [Fluent Assertions](https://fluentassertions.com/)
- [Mapster/Mapster.Tool](https://github.com/MapsterMapper/Mapster)
- [Fluent Results](https://github.com/altmann/FluentResults)
- [Carter](https://github.com/CarterCommunity/Carter)
- [Scalar API Documentation](https://github.com/scalar/scalar)


## Work Arounds

### Get Auto Generated Mapper Code
     dotnet msbuild -t:CleanGenerated && dotnet clean && dotnet msbuild -t:Mapster
 