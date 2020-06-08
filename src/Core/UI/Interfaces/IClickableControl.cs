using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UI.Interfaces
{
    interface IClickableControl
    {
        bool IsSelected();
        void ExecuteAction();
    }
}
