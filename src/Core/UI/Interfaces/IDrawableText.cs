namespace Core.UI.Interfaces
{
    interface IDrawableText<Text> : IDrawable<Text>, IDrawableUI<Text>
    {
        void setText(string text="UNKNOWN STRING");
    }
}
