namespace TaskoMask.Services.Monolith.Presentation.UI.UserPanel.Services.DragDrop
{
    public class DragDropService : IDragDropService
    {
        private string _data;

        public DragDropService()
        {

        }



        /// <summary>
        /// 
        /// </summary>
        public string GetDraggedData()
        {
            return _data;
        }



        /// <summary>
        /// 
        /// </summary>
        public void SetDraggedData(string data)
        {
            _data = data;
        }
    }
}
