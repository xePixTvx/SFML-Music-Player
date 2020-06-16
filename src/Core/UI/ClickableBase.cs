using Core.UI.Interfaces;
using System;

namespace Core.UI
{
    class ClickableBase : RenderableBase, IClickable
    {
        private bool isSelected = false;
        private Action execAction = null;

        public virtual bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }

        public virtual Action ExecAction
        {
            get { return execAction; }
            set { execAction = value; }
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
