using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskoMask.Domain.Workspace.Members.Services
{
    /// <summary>
    /// Some validations that need persistence layer
    /// </summary>
    internal interface IMemberValidatorService
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="memberId">If member is created before, use it to ignore itself </param>
        /// <returns></returns>
        Task<bool> HasUniqueUserName(string userName, string memberId = "");



        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="memberId">If member is created before, use it to ignore itself </param>
        /// <returns></returns>
        Task<bool> HasUniqueEmail(string email, string memberId = "");



        /// <summary>
        /// 
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <param name="memberId">If member is created before, use it to ignore itself </param>
        /// <returns></returns>
        Task<bool> HasUniquePhoneNumber(string phoneNumber, string memberId = "");
    }
}
