using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace TaskoMask.BuildingBlocks.Application.Extensions
{

    /// <summary>
    /// 
    /// </summary>
    public static class DataAnnotationExtension
    {


        /// <summary>
        /// 
        /// </summary>
        public static bool Validate<TObject>(this TObject obj, out ICollection<ValidationResult> results)
        {
            results = new List<ValidationResult>();

            return Validator.TryValidateObject(obj, new ValidationContext(obj), results, true);
        }



        /// <summary>
        /// 
        /// </summary>
        public static object GetDisplayName<TObject>(this TObject obj) where TObject : class
        {
            return typeof(TObject).CustomAttributes.Any() ?
                typeof(TObject).CustomAttributes.First().ConstructorArguments.First().Value :
                nameof(TObject);
        }


    }
}