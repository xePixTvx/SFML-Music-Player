namespace Core.UI.Interfaces
{
    interface IDrawableUI<Type> : IDrawable<Type>
    {
        void setOrigin(string align_x = "left", string align_y = "top");
        void setPosition(string align_x = "left", string align_y = "top", float x_pos = 0, float y_pos = 0);
    }
}
