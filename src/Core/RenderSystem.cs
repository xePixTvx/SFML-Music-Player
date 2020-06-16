using Core.UI.Interfaces;
using System.Collections.Generic;
using System.Linq;

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
            SortRenderList();
        }

        public void RemoveFromRenderList(IRenderable elem)
        {
            RenderList.Remove(elem);
            SortRenderList();
        }

        public void SortRenderList()
        {
            List<IRenderable> sortedList = RenderList.OrderBy(e => e.RenderLayer).ToList();
            RenderList = sortedList;
        }

        public List<IRenderable> GetRenderList()
        {
            return RenderList;
        }

        public void Render()
        {
            foreach(IRenderable elem in RenderList)
            {
                if(elem.IsActive)
                {
                    if(elem is IClickable clickElem)
                    {
                        clickElem.UpdateSelection();
                    }
                    elem.Render();
                }
            }
        }
    }
}
