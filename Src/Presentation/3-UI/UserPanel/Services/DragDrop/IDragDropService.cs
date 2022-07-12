namespace TaskoMask.Presentation.UI.UserPanel.Services.DragDrop
{
    public interface IDragDropService
    {
        void SetDraggedData(string data);
        string GetDraggedData();
    }
}
