namespace Core.UI.Interfaces
{
    interface IClickable
    {
        bool IsSelected { get; set; }
        void UpdateSelection();
    }
}
