using Suzianna.Core.Screenplay.Actors;
using Suzianna.Core.Screenplay.Questions;
using TaskoMask.Tests.Acceptance.Core.Models;

namespace TaskoMask.Tests.Acceptance.Core.Screenplay.Questions
{
    public abstract class OwnerDetailsQuestion : IQuestion<OwnerDetailsDto>
    {
        protected readonly string OwnerId;
        public OwnerDetailsQuestion(string ownerId)
        {
            OwnerId = ownerId;
        }


        public OwnerDetailsDto AnsweredBy(Actor actor)
        {
            return GetOwnerDetails(actor);
        }

        protected abstract OwnerDetailsDto GetOwnerDetails<T>(T actor) where T : Actor;
    }
}
