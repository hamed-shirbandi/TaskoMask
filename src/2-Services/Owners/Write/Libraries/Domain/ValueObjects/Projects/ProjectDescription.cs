using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Domain.ValueObjects.Projects
{
    public class ProjectDescription : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public ProjectDescription(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static ProjectDescription Create(string value)
        {
            return new ProjectDescription(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                return;

            if (Value.Length > DomainConstValues.Project_Description_Max_Length)
                throw new DomainException(string.Format(ContractsMetadata.Max_Length_Error, nameof(ProjectDescription), DomainConstValues.Project_Description_Max_Length));

        }



        /// <summary>
        /// 
        /// </summary>
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }


        #endregion

    }
}
