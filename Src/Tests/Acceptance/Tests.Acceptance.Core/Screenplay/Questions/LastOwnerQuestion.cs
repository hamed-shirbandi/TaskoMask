using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Models;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay.Questions
{
    public abstract class LastOwnerQuestion : IQuestion<OwnerBasicInfoDto>
    {
        public LastOwnerQuestion( )
        {
        }


        public OwnerBasicInfoDto AnsweredBy(Actor actor)
        {
            return GetLastOwner(actor);
        }

        protected abstract OwnerBasicInfoDto GetLastOwner<T>(T actor) where T : Actor;
    }
}
