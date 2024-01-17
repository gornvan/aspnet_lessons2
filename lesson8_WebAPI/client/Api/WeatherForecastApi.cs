using System;
using System.Collections.Generic;
using RestSharp;
using IO.Swagger.Client;
using IO.Swagger.Model;

namespace IO.Swagger.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IWeatherForecastApi
    {
        /// <summary>
        ///  
        /// </summary>
        /// <param name="daysAhead"></param>
        /// <returns></returns>
        void GetWeathForecastForConcreteDayAhead (int? daysAhead);
        /// <summary>
        ///  
        /// </summary>
        /// <param name="minTemperatureC"></param>
        /// <param name="maxTemperatureC"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="fields"></param>
        /// <returns>List&lt;WeatherForecast&gt;</returns>
        List<WeatherForecast> GetWeatherForecast (int? minTemperatureC, int? maxTemperatureC, int? pageSize, int? pageNumber, List<string> fields);
    }
  
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class WeatherForecastApi : IWeatherForecastApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public WeatherForecastApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient; 
            else
                this.ApiClient = apiClient;
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherForecastApi"/> class.
        /// </summary>
        /// <returns></returns>
        public WeatherForecastApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }
    
        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }
    
        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }
    
        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient {get; set;}
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="daysAhead"></param>
        /// <returns></returns>
        public void GetWeathForecastForConcreteDayAhead (int? daysAhead)
        {
            // verify the required parameter 'daysAhead' is set
            if (daysAhead == null) throw new ApiException(400, "Missing required parameter 'daysAhead' when calling GetWeathForecastForConcreteDayAhead");
    
            var path = "/WeatherForecast/{daysAhead}";
            path = path.Replace("{format}", "json");
            path = path.Replace("{" + "daysAhead" + "}", ApiClient.ParameterToString(daysAhead));
    
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
                                    
            // authentication setting, if any
            String[] authSettings = new String[] {  };
    
            // make the HTTP request
            RestResponseBase response = (RestResponse) ApiClient.CallApi(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetWeathForecastForConcreteDayAhead: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetWeathForecastForConcreteDayAhead: " + response.ErrorMessage, response.ErrorMessage);
    
            return;
        }
    
        /// <summary>
        ///  
        /// </summary>
        /// <param name="minTemperatureC"></param>
        /// <param name="maxTemperatureC"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageNumber"></param>
        /// <param name="fields"></param>
        /// <returns>List&lt;WeatherForecast&gt;</returns>
        public List<WeatherForecast> GetWeatherForecast (
            int? minTemperatureC, int? maxTemperatureC,
            int? pageSize, int? pageNumber, List<string> fields)
        {
    
            var path = "/WeatherForecast";
            path = path.Replace("{format}", "json");
                
            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;
    
             if (minTemperatureC != null) queryParams.Add("minTemperatureC", ApiClient.ParameterToString(minTemperatureC)); // query parameter
 if (maxTemperatureC != null) queryParams.Add("maxTemperatureC", ApiClient.ParameterToString(maxTemperatureC)); // query parameter
 if (pageSize != null) queryParams.Add("pageSize", ApiClient.ParameterToString(pageSize)); // query parameter
 if (pageNumber != null) queryParams.Add("pageNumber", ApiClient.ParameterToString(pageNumber)); // query parameter
 if (fields != null) queryParams.Add("fields", ApiClient.ParameterToString(fields)); // query parameter
                        
            // authentication setting, if any
            String[] authSettings = new String[] {  };

            // make the HTTP request
            RestResponse response = (RestResponse) ApiClient.CallApi(path, Method.Get, queryParams, postBody, headerParams, formParams, fileParams, authSettings);
    
            if (((int)response.StatusCode) >= 400)
                throw new ApiException ((int)response.StatusCode, "Error calling GetWeatherForecast: " + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException ((int)response.StatusCode, "Error calling GetWeatherForecast: " + response.ErrorMessage, response.ErrorMessage);
    
            return (List<WeatherForecast>) ApiClient.Deserialize(response.Content, typeof(List<WeatherForecast>), response.Headers);
        }
    
    }
}
