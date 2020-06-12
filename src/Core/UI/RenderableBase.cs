using Core.UI.Interfaces;

namespace Core.UI
{
    class RenderableBase : IRenderable
    {
        private bool isActive = false;
        private bool isVisible = true;
        private int renderLayer = 0;

        public virtual bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }

        public virtual bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }

        public virtual int RenderLayer
        {
            get { return renderLayer; }
            set { renderLayer = value; }
        }

        public virtual void SetOrigin()
        {
            Core.App.Log.Print("SetOrigin() not defined for " + this, LoggerType.ERROR);
        }

        public virtual void SetPosition()
        {
            Core.App.Log.Print("SetPosition() not defined for " + this, LoggerType.ERROR);
        }

        public virtual void Render()
        {
            Core.App.Log.Print("Render() not defined for " + this, LoggerType.ERROR);
        }
    }
}
