using TaskoMask.BuildingBlocks.Contracts.Dtos.Organizations;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Models;
using TaskoMask.BuildingBlocks.Contracts.ViewModels;
using TaskoMask.BuildingBlocks.Web.Services;

namespace TaskoMask.Clients.UserPanel.Services.API;

public class OrganizationApiService : BaseApiService
{
    #region Fields


    #endregion

    #region Ctor

    public OrganizationApiService(IHttpClientService httpClientService)
        : base(httpClientService) { }

    #endregion

    #region Public Methods


    /// <summary>
    ///
    /// </summary>
    public async Task<Result<GetOrganizationDto>> GetAsync(string id)
    {
        var url = $"/owners-read/organizations/{id}";
        return await _httpClientService.GetAsync<GetOrganizationDto>(url);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<IEnumerable<OrganizationDetailsViewModel>>> GetListAsync()
    {
        var url = $"/aggregator/organizations";
        return await _httpClientService.GetAsync<IEnumerable<OrganizationDetailsViewModel>>(url);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<IEnumerable<SelectListItem>>> GetSelectListItemsAsync()
    {
        var url = $"/owners-read/organizations";
        var organizationsResult = await _httpClientService.GetAsync<IEnumerable<GetOrganizationDto>>(url);
        if (!organizationsResult.IsSuccess)
            return Result.Failure<IEnumerable<SelectListItem>>(organizationsResult.Errors, organizationsResult.Message);

        var selectListItems = MapToSelectListItem(organizationsResult.Value);
        return Result.Success(selectListItems);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> AddAsync(AddOrganizationDto input)
    {
        var url = $"/owners-write/organizations";
        return await _httpClientService.PostAsync<CommandResult>(url, input);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> UpdateAsync(string id, UpdateOrganizationDto input)
    {
        var url = $"/owners-write/organizations/{id}";
        return await _httpClientService.PutAsync<CommandResult>(url, input);
    }

    /// <summary>
    ///
    /// </summary>
    public async Task<Result<CommandResult>> DeleteAsync(string id)
    {
        var url = $"/owners-write/organizations/{id}";
        return await _httpClientService.DeleteAsync<CommandResult>(url);
    }

    #endregion

    #region Private Methods



    /// <summary>
    ///
    /// </summary>
    private IEnumerable<SelectListItem> MapToSelectListItem(IEnumerable<GetOrganizationDto> organizations)
    {
        var items = new List<SelectListItem>();
        foreach (var item in organizations)
        {
            items.Add(new SelectListItem { Text = item.Name, Value = item.Id });
        }

        return items;
    }

    #endregion
}
