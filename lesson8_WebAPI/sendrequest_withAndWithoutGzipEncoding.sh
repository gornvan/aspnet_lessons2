curl -X 'GET'   'https://localhost:7176/api/2.0.0.0/WeatherForecast'   -H 'accept: text/plain' -o response_unarchived

curl -X 'GET'   'https://localhost:7176/api/2.0.0.0/WeatherForecast'   -H 'accept: text/plain' -H 'Accept-Encoding: gzip' -o response_archived