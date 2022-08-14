using Blazored.Modal;
using Blazored.Toast.Services;
using TaskoMask.BuildingBlocks.Contracts.Helpers;
using TaskoMask.Clients.UserPanel.Services.ComponentMessage;

namespace TaskoMask.Clients.UserPanel.Helpers
{
    public class CommandResultHandler
    {
        private Result<CommandResult> _result;
        private MessageType _messageType;


        private CommandResultHandler()
        {

        }



        /// <summary>
        /// 
        /// </summary>
        public static CommandResultHandler Init()
        {
            return new CommandResultHandler();
        }



        /// <summary>
        /// 
        /// </summary>
        public CommandResultHandler WithResult(Result<CommandResult> result)
        {
            _result = result;
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public CommandResultHandler WithComponentMessageType(MessageType messageType)
        {
            _messageType = messageType;
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public CommandResultHandler ShowToast(IToastService toastService)
        {
            if (_result.IsSuccess)
                toastService.ShowSuccess(_result.Value.Message, _result.Message);
            else
                toastService.ShowError(_result.Errors.ParseToFragment(), _result.Message);
            return this;

        }



        /// <summary>
        /// 
        /// </summary>
        public CommandResultHandler ShowErrorToast(IToastService toastService)
        {
            if (!_result.IsSuccess)
                toastService.ShowError(_result.Errors.ParseToFragment(), _result.Message);
            return this;
        }



        /// <summary>
        /// 
        /// </summary>
        public CommandResultHandler PublishMessage(IComponentMessageService messageService)
        {
            if (_result.IsSuccess)
                messageService.SendMessage(_messageType);
            return this;
        }




        /// <summary>
        /// 
        /// </summary>
        public CommandResultHandler CloseModal(BlazoredModalInstance modalInstance)
        {
            if (_result.IsSuccess)
                modalInstance.CloseAsync();
            return this;

        }

    }
}
