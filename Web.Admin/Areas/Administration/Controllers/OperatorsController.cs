using TaskoMask.Application.Administration.Operators.Commands.Models;
using TaskoMask.Application.Administration.Operators.Queries.Models;
using TaskoMask.Application.Administration.Operators.Services;
using TaskoMask.Application.Administration.Roles.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TaskoMask.Domain.Administration.Entities;
using TaskoMask.Web.Common.Controllers;

namespace TaskoMask.Web.Admin.Areas.Administration.Controllers
{

    [Authorize]
    [Area("Administration")]
    public class OperatorsController : BaseMvcController
    {
        #region Fields

        private readonly IOperatorService _operatorService;
        private readonly IRoleService _roleService;

        #endregion

        #region Ctor

        public OperatorsController(IOperatorService operatorService, IRoleService roleService, IMapper mapper) : base(mapper)
        {
            _operatorService = operatorService;
            _roleService = roleService;
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion


    }
}
