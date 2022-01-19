using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskoMask.Domain.Core.Exceptions;
using TaskoMask.Domain.Core.Models;
using TaskoMask.Domain.Share.Resources;

namespace TaskoMask.Domain.Workspace.Tasks.Entities
{
    /// <summary>
    /// All task activities like moving between cards, delete and ...
    /// </summary>
    public class Activity : BaseEntity
    {
        #region Fields


        #endregion

        #region Ctors

        private Activity(string description)
        {
            Description = description;
            CheckPolicies();
        }

        #endregion

        #region Properties


        public string Description { get; set; }

        #endregion

        #region Public Methods


        /// <summary>
        /// 
        /// </summary>
        public static Activity Create(string description)
        {
            return new Activity(description);
        }




        /// <summary>
        /// 
        /// </summary>
        public void Update(string description)
        {
            Description = description;
            base.UpdateModifiedDateTime();

            CheckPolicies();
        }

        #endregion

        #region Private Methods



        /// <summary>
        /// 
        /// </summary>
        private void CheckPolicies()
        {
            if (Description == null)
                throw new DomainException(string.Format(DomainMessages.Null_Reference_Error, nameof(Description)));
        }


        #endregion
    }
}
