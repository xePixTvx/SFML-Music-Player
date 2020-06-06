using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.UI.Interfaces
{
    interface IClickableControl
    {
        void DrawTo(RenderWindow window);
        bool IsSelected();
        void ExecuteAction();
    }
}
