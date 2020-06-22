using Core.UI.Interfaces;
using SFML.System;

namespace Core.UI
{
    class RenderableBase : IRenderable
    {
        private bool _IsActive = true;
        private bool _IsVisible = true;
        private int _RenderLayer = 0;
        private Origin_Horizontal_Alignment _Origin_H_Align = Origin_Horizontal_Alignment.LEFT;
        private Origin_Vertical_Alignment _Origin_V_Align = Origin_Vertical_Alignment.TOP;
        private Vector2f _Position = new Vector2f(0, 0);
        private float _Rotation = 0;

        #region Render
        public virtual bool IsActive
        {
            get { return _IsActive; }
            set { _IsActive = value; }
        }

        public virtual bool IsVisible
        {
            get { return _IsVisible; }
            set { _IsVisible = value; }
        }

        public virtual int RenderLayer
        {
            get { return _RenderLayer; }
            set 
            { 
                _RenderLayer = value;
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
            get { return _Origin_H_Align; }
            set { _Origin_H_Align = value; }
        }

        public virtual Origin_Vertical_Alignment Origin_V_Align
        {
            get { return _Origin_V_Align; }
            set { _Origin_V_Align = value; }
        }

        public virtual void SetOrigin(Origin_Horizontal_Alignment h_align = Origin_Horizontal_Alignment.LEFT, Origin_Vertical_Alignment v_align = Origin_Vertical_Alignment.TOP)
        {
            Core.App.Log.Print("SetOrigin() not defined for " + this, LoggerType.ERROR);
        }

        public virtual Vector2f Position
        {
            get { return _Position; }
            set { _Position = value; }
        }

        public virtual void SetPosition(float x, float y)
        {
            Core.App.Log.Print("SetPosition() not defined for " + this, LoggerType.ERROR);
        }

        public virtual float Rotation
        {
            get { return _Rotation; }
            set { _Rotation = value; }
        }

        public virtual void SetRotation(float rotation)
        {
            Core.App.Log.Print("SetRotation() not defined for " + this, LoggerType.ERROR);
        }
        #endregion
    }
}
