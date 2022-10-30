using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskoMask.BuildingBlocks.Application.Bus;

namespace TaskoMask.BuildingBlocks.Web.MVC.Pages
{
    public class BasePageModel: PageModel
    {
        protected readonly IInMemoryBus _inMemoryBus;

        public BasePageModel(IInMemoryBus inMemoryBus)
        {
            _inMemoryBus = inMemoryBus;
        }

    }
}
