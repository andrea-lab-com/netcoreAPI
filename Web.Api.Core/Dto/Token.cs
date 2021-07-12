 

namespace Web.Api.Core.Dto
{
  public sealed class Token
  {
    public string Id { get; }
    public string AuthToken { get; }

    public Token(string id, string authToken)
    {
      Id = id;
      AuthToken = authToken;
    }
  }
}
