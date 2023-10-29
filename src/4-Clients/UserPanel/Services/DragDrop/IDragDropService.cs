namespace TaskoMask.Clients.UserPanel.Services.DragDrop;

public interface IDragDropService
{
    void SetDraggedData(string data);
    string GetDraggedData();
}
