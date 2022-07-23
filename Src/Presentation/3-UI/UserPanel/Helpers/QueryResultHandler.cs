using Blazored.Modal;
using Blazored.Toast.Services;
using TaskoMask.Application.Share.Helpers;
using TaskoMask.Presentation.UI.UserPanel.Services.Message;

namespace TaskoMask.Presentation.UI.UserPanel.Helpers
{
    public class QueryResultHandler<T>
    {

        public QueryResultHandler()
        {

        }
        private Result<T> _result;
        private MessageType _messageType;


        public static QueryResultHandler<T> Init()
        {
            return new QueryResultHandler<T>();
        }


        public QueryResultHandler<T> WithResult(Result<T> result)
        {
            _result = result;
            return this;
        }



        public QueryResultHandler<T> WithMessageType(MessageType messageType)
        {
            _messageType = messageType;
            return this;
        }


        public QueryResultHandler<T> ShowToas(IToastService toastService)
        {
            if (_result.IsSuccess)
                toastService.ShowSuccess(_result.Message, "");
            else
                toastService.ShowError(_result.Errors.ParseToFragment(), _result.Message);
            return this;

        }


        public QueryResultHandler<T> ShowErrorToast(IToastService toastService)
        {
            if (!_result.IsSuccess)
                toastService.ShowError(_result.Errors.ParseToFragment(), _result.Message);
            return this;
        }


        public QueryResultHandler<T> PublishMessage(IMessageService messageService)
        {
            if (_result.IsSuccess)
                messageService.SendMessage(_messageType);
            return this;

        }


        public QueryResultHandler<T> CloseModal(BlazoredModalInstance? modalInstance)
        {
            modalInstance.CloseAsync();
            return this;

        }

    }
}
