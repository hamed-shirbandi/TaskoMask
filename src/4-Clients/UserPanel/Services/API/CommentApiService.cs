using TaskoMask.BuildingBlocks.Contracts.Dtos.Comments;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Web.Services;

namespace TaskoMask.Clients.UserPanel.Services.API;

public class CommentApiService : BaseApiService
{
    #region Fields


    #endregion

    #region Ctor

    public CommentApiService(IHttpClientService httpClientService)
        : base(httpClientService) { }

    #endregion

    #region Public Methods


    /// <summary>
    ///
    /// </summary>
    public async Task<Result<GetCommentDto>> GetAsync(string id)
    {
        var url = $"/comments/{id}";
        return await _httpClientService.GetAsync<GetCommentDto>(url);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> AddAsync(AddCommentDto input)
    {
        var url = $"/comments";
        return await _httpClientService.PostAsync<CommandResult>(url, input);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> UpdateAsync(string id, UpdateCommentDto input)
    {
        var url = $"/comments/{id}";
        return await _httpClientService.PutAsync<CommandResult>(url, input);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> DeleteAsync(string id)
    {
        var url = $"/comments/{id}";
        return await _httpClientService.DeleteAsync<CommandResult>(url);
    }

    #endregion

    #region Private Methods



    #endregion
}
