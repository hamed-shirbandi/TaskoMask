namespace TaskoMask.Services.Monolith.Presentation.UI.UserPanel.Services.DragDrop
{
    public interface IDragDropService
    {
        void SetDraggedData(string data);
        string GetDraggedData();
    }
}
