using TaskoMask.BuildingBlocks.Domain.Exceptions;
using TaskoMask.BuildingBlocks.Domain.Models;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.BuildingBlocks.Contracts.Resources;

namespace TaskoMask.Services.Owners.Write.Domain.ValueObjects.Projects
{
    public class ProjectName : BaseValueObject
    {
        #region Properties

        public string Value { get; private set; }


        #endregion

        #region Ctors

        public ProjectName(string value)
        {
            Value = value;

            CheckPolicies();
        }

        #endregion

        #region  Methods



        /// <summary>
        /// Factory method for creating new object
        /// </summary>
        public static ProjectName Create(string value)
        {
            return new ProjectName(value);
        }



        /// <summary>
        /// 
        /// </summary>
        protected override void CheckPolicies()
        {
            if (string.IsNullOrEmpty(Value))
                throw new DomainException(string.Format(ContractsMetadata.Required, nameof(ProjectName)));

            if (Value.Length < DomainConstValues.Project_Name_Min_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(ProjectName), DomainConstValues.Project_Name_Min_Length, DomainConstValues.Project_Name_Max_Length));

            if (Value.Length > DomainConstValues.Project_Name_Max_Length)
                throw new DomainException(string.Format(ContractsMetadata.Length_Error, nameof(ProjectName), DomainConstValues.Project_Name_Min_Length, DomainConstValues.Project_Name_Max_Length));

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
