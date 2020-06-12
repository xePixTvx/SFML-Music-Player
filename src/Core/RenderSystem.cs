using Core.UI.Interfaces;
using System.Collections.Generic;

namespace music_player_app.Core
{
    class RenderSystem
    {
        private List<IRenderable> RenderList = new List<IRenderable>();//RenderableBase??????


        public RenderSystem()
        {
            RenderList.Clear();
        }
    }
}
