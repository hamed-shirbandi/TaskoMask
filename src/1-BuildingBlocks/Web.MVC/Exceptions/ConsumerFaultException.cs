using System;
namespace TaskoMask.BuildingBlocks.Web.MVC.Exceptions
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsumerFaultException : Exception
    {
        public ConsumerFaultException(string message): base(message)
        {
        }

    }
}