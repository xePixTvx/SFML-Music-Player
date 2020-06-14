using Core.UI.Interfaces;
using System.Collections.Generic;

namespace Core
{
    public class RenderSystem
    {
        private List<IRenderable> RenderList = new List<IRenderable>();

        public RenderSystem()
        {
            RenderList.Clear();
        }

        public void AddToRenderList(IRenderable elem)
        {
            RenderList.Add(elem);
        }

        public void RemoveFromRenderList(IRenderable elem)
        {
            RenderList.Remove(elem);
        }

        public void Render()
        {
            foreach(IRenderable elem in RenderList)
            {
                if(elem.IsActive)
                {
                    elem.Render();
                }
            }
        }
    }
}
