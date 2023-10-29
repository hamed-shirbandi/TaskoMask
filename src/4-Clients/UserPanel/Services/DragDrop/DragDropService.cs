namespace TaskoMask.Clients.UserPanel.Services.DragDrop;

public class DragDropService : IDragDropService
{
    private string data;

    public DragDropService() { }

    /// <summary>
    ///
    /// </summary>
    public string GetDraggedData()
    {
        return data;
    }

    /// <summary>
    ///
    /// </summary>
    public void SetDraggedData(string data)
    {
        this.data = data;
    }
}
