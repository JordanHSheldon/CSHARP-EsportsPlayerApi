namespace EsportsProfileWebApi.Web.Orchestrators.Models.Data;

public class GetPaginatedUsersResponseModel 
{
    public string Id {get;set;} = string.Empty;
    
    public string UserName {get;set;} = string.Empty;

    public string FirstName {get;set;} = string.Empty;

    public string LastName {get;set;} = string.Empty;
}