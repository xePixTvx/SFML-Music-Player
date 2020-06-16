using System;

namespace Core.UI.Interfaces
{
    interface IClickable
    {
        bool IsSelected { get; set; }
        Action ExecAction { get; set; }
        void UpdateSelection();
        void ExecuteAction();
    }
}
