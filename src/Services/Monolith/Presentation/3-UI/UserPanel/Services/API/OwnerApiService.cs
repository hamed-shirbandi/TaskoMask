﻿using TaskoMask.Application.Share.Dtos.Workspace.Owners;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Application.Share.ViewModels;
using TaskoMask.Presentation.Framework.Share.ApiContracts;
using TaskoMask.Presentation.Framework.Share.Helpers;
using TaskoMask.Presentation.Framework.Share.Services.Http;

namespace TaskoMask.Presentation.UI.UserPanel.Services.API
{
    public class OwnerApiService : IOwnerApiService
    {
        #region Fields

        private readonly IHttpClientService _httpClientService;

        #endregion

        #region Ctor

        public OwnerApiService(IHttpClientService httpClientService)
        {
            _httpClientService = httpClientService;
        }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<OwnerBasicInfoDto>> Get()
        {
            var url = $"/owner";
            return await _httpClientService.GetAsync<OwnerBasicInfoDto>(url);
        }



        /// <summary>
        /// 
        /// </summary>
        public async Task<Result<CommandResult>> UpdateProfile(UpdateOwnerProfileDto input)
        {
            var url = $"/owner";
            return await _httpClientService.PutAsync<CommandResult>(url, input);
        }

        #endregion

        #region Private Methods



        #endregion

    }
}
