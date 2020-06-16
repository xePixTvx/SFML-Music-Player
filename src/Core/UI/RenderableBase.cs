using Core.UI.Interfaces;
using SFML.System;

namespace Core.UI
{
    class RenderableBase : IRenderable
    {
        private bool isActive = true;
        private bool isVisible = true;
        private int renderLayer = 0;
        private Origin_Horizontal_Alignment origin_H_Align = Origin_Horizontal_Alignment.LEFT;
        private Origin_Vertical_Alignment origin_V_Align = Origin_Vertical_Alignment.TOP;
        private Vector2f position = new Vector2f(0, 0);
        private float rotation = 0;

        #region Render
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
            set 
            { 
                renderLayer = value;
                Core.App.RenderSys.SortRenderList();
            }
        }

        public virtual void Render()
        {
            Core.App.Log.Print("Render() not defined for " + this, LoggerType.ERROR);
        }
        #endregion

        #region Position
        public virtual Origin_Horizontal_Alignment Origin_H_Align
        {
            get { return origin_H_Align; }
            set { origin_H_Align = value; }
        }

        public virtual Origin_Vertical_Alignment Origin_V_Align
        {
            get { return origin_V_Align; }
            set { origin_V_Align = value; }
        }

        public virtual void SetOrigin(Origin_Horizontal_Alignment h_align = Origin_Horizontal_Alignment.LEFT, Origin_Vertical_Alignment v_align = Origin_Vertical_Alignment.TOP)
        {
            Core.App.Log.Print("SetOrigin() not defined for " + this, LoggerType.ERROR);
        }

        public virtual Vector2f Position
        {
            get { return position; }
            set { position = value; }
        }

        public virtual void SetPosition(float x, float y)
        {
            Core.App.Log.Print("SetPosition() not defined for " + this, LoggerType.ERROR);
        }

        public virtual float Rotation
        {
            get { return rotation; }
            set { rotation = value; }
        }

        public virtual void SetRotation(float rotation)
        {
            Core.App.Log.Print("SetRotation() not defined for " + this, LoggerType.ERROR);
        }
        #endregion
    }
}
