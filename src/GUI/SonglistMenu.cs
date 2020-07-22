using PIX_UI;
using PIX_UI.Graphics;
using PIX_UI.Graphics.Controls;
using PIX_UI.Graphics.Primitives;
using SFML.Graphics;
using SFML.System;

namespace music_app.GUI
{
    class SonglistMenu
    {
        private bool _Active;

        public bool Active
        {
            get { return _Active; }
            set
            {
                _Active = value;
                UpdateActiveState();
            }
        }

        public SonglistMenu(Vector2f Main_Pos)
        {
            new Rect("Songlist_BG", Alignment.LEFT_BOTTOM, 400, 450, Main_Pos.X, Main_Pos.Y, new Color(138, 138, 138, 255));
            App.GetElemByName("Songlist_BG").RenderLayer = 2;

            new Rect("Songlist_Seperator", Alignment.LEFT_BOTTOM, 400, 2, Main_Pos.X, Main_Pos.Y - 400, new Color(255, 255, 255, 255));
            App.GetElemByName("Songlist_Seperator").RenderLayer = 3;

            new SpriteButton("Button_Songlist_Next_Song", Alignment.LEFT_BOTTOM, Main_Pos.X + 350, Main_Pos.Y - 400, "arrow_right");
            App.GetElemByName("Button_Songlist_Next_Song").RenderLayer = 3;

            new SpriteButton("Button_Songlist_Previous_Song", Alignment.LEFT_BOTTOM, Main_Pos.X, Main_Pos.Y - 400, "arrow_left");
            App.GetElemByName("Button_Songlist_Previous_Song").RenderLayer = 3;

            new SimpleText("Songlist_Page_Info", Alignment.CENTER_CENTER, Main_Pos.X + 200, Main_Pos.Y - 421, new Color(255, 255, 255, 255), "sansC", 20, Text.Styles.Regular, "Page[0/0]");
            App.GetElemByName("Songlist_Page_Info").RenderLayer = 3;

            Active = false;
        }


        //Update Active/Visible
        private void UpdateActiveState()
        {
            App.GetElemByName("Songlist_BG").IsActive = Active;
            App.GetElemByName("Songlist_Seperator").IsActive = Active;
            App.GetElemByName("Button_Songlist_Next_Song").IsActive = Active;
            App.GetElemByName("Button_Songlist_Previous_Song").IsActive = Active;
            App.GetElemByName("Songlist_Page_Info").IsActive = Active;
        }
    }
}
