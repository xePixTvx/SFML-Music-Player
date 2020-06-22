using Core.UI.Interfaces;
using System;

namespace Core.UI
{
    class ClickableBase : RenderableBase, IClickable
    {
        private bool _IsSelected = false;
        private Action _ExecAction = null;

        public virtual bool IsSelected
        {
            get { return _IsSelected; }
            set { _IsSelected = value; }
        }

        public virtual Action ExecAction
        {
            get { return _ExecAction; }
            set { _ExecAction = value; }
        }

        public virtual void UpdateSelection()
        {
            Core.App.Log.Print("UpdateSelection() not defined for " + this, LoggerType.ERROR);
        }

        public virtual void ExecuteAction()
        {
            if (ExecAction == null)
            {
                Core.App.Log.Print("ExecAction not defined for " + this, LoggerType.ERROR);
            }
            else
            {
                ExecAction();
            }
        }
    }
}
