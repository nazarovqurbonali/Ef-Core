using System.Net;

namespace Domain.Responses;

public class Response<T>
{
    public int StatusCode { get; set; }
    public T? Data { get; set; }
    public List<string>? Errors { get; set; } = new List<string>();

    public Response(T data)
    {
        StatusCode = 200;
        Data = data;
    }
    
    public Response(T data,HttpStatusCode statusCode)
    {
        StatusCode = (int)statusCode;
        Data = data;
    }
    
    public Response(T data,HttpStatusCode statusCode,string error)
    {
        StatusCode = (int)statusCode;
        Data = data;
        Errors.Add(error);
    }
    public Response(HttpStatusCode statusCode,List<string> errors)
    {
        StatusCode = (int)statusCode;
        Errors = errors;
    }
    public Response(HttpStatusCode statusCode,string errors)
    {
        StatusCode = (int)statusCode;
        Errors.Add(errors) ;
    }
}