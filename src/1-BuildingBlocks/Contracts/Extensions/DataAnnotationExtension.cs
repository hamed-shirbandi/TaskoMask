using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskoMask.BuildingBlocks.Contracts.Extensions;

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
}
