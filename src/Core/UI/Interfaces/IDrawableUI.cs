namespace Core.UI.Interfaces
{
    interface IDrawableUI<Type>
    {
        void setPosition(string origin_align = "left_top", string position_align = "left_top", float x_pos = 0, float y_pos = 0);
    }
}
