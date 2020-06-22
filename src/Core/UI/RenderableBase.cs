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
        private bool _NeedsUpdate = false;

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
            set 
            { 
                _Origin_H_Align = value;
                _NeedsUpdate = true;
            }
        }

        public virtual Origin_Vertical_Alignment Origin_V_Align
        {
            get { return _Origin_V_Align; }
            set 
            { 
                _Origin_V_Align = value;
                _NeedsUpdate = true;
            }
        }

        public virtual Vector2f Position
        {
            get { return _Position; }
            set
            { 
                _Position = value;
                _NeedsUpdate = true;
            }
        }

        public virtual float Rotation
        {
            get { return _Rotation; }
            set 
            {
                _Rotation = value;
                _NeedsUpdate = true;
            }
        }

        public virtual bool NeedsUpdate
        {
            get { return _NeedsUpdate; }
            set { _NeedsUpdate = value; }
        }

        public virtual void Update()
        {
            Core.App.Log.Print("Update() not defined for " + this, LoggerType.ERROR);
        }
        #endregion
    }
}
