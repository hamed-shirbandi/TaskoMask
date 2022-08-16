using System.Collections.Generic;
using System.Linq;

namespace TaskoMask.BuildingBlocks.Domain.Models
{

    /// <summary>
    ///
    /// </summary>
    public abstract class BaseValueObject
    {
        /// <summary>
        /// 
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            return GetEqualityComponents()
                .SequenceEqual(
                    ((BaseValueObject)obj).GetEqualityComponents());
        }



        /// <summary>
        /// 
        /// </summary>
        public override int GetHashCode()
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x, y) => x ^ y);
        }



        /// <summary>
        /// 
        /// </summary>
        protected static bool EqualOperator(BaseValueObject left, BaseValueObject right)
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null))
                return false;

            return ReferenceEquals(left, null) || left.Equals(right);
        }



        /// <summary>
        /// 
        /// </summary>
        protected static bool NotEqualOperator(BaseValueObject left, BaseValueObject right)
        {
            return !EqualOperator(left, right);
        }



        /// <summary>
        /// 
        /// </summary>
        protected abstract IEnumerable<object> GetEqualityComponents();



        /// <summary>
        /// Check policies for each value object by itself
        /// Policies are kind of validation that the system know how to deal with
        /// </summary>
        protected abstract void CheckPolicies();


    }
}