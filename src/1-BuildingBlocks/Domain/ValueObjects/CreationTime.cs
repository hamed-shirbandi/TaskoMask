using System;
using System.Collections.Generic;

namespace TaskoMask.BuildingBlocks.Domain.ValueObjects;

/// <summary>
///
/// </summary>
public class CreationTime : BaseValueObject
{
    #region Properties

    public DateTime CreateDateTime { get; private set; }
    public DateTime ModifiedDateTime { get; private set; }
    public int CreateDay { get; private set; }
    public int CreateMonth { get; private set; }
    public int CreateYear { get; private set; }

    #endregion

    #region Ctors

    private CreationTime(DateTime dateTime)
    {
        CreateDateTime = dateTime;
        ModifiedDateTime = CreateDateTime;
        CreateDay = CreateDateTime.Day;
        CreateMonth = CreateDateTime.Month;
        CreateYear = CreateDateTime.Year;
    }

    #endregion

    #region  Methods



    /// <summary>
    ///
    /// </summary>
    public static CreationTime CreateNowDateTime()
    {
        return new CreationTime(DateTime.Now);
    }

    /// <summary>
    ///
    /// </summary>
    public CreationTime UpdateModifiedDateTime()
    {
        return new CreationTime(DateTime.Now);
    }

    /// <summary>
    ///
    /// </summary>
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return CreateDateTime;
        yield return ModifiedDateTime;
        yield return CreateDay;
        yield return CreateMonth;
        yield return CreateYear;
    }

    /// <summary>
    ///
    /// </summary>
    protected override void CheckPolicies() { }

    #endregion
}
