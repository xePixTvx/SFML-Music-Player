using PIX_UI;
using PIX_UI.Graphics;
using PIX_UI.Graphics.Controls;
using PIX_UI.Graphics.Primitives;
using PIX_UI.Utilities;
using SFML.Graphics;
using SFML.System;
using System;

namespace music_app.GUI
{
    class MainGUI
    {
        private VolumeMenu Volume_Menu;
        public MainGUI()
        {
            Vector2f Position_CENTER_BOTTOM = Position_Utils.GetPositionOnScreen(Alignment.CENTER_BOTTOM);
            Vector2f Position_RIGHT_BOTTOM = Position_Utils.GetPositionOnScreen(Alignment.RIGHT_BOTTOM);

            //Volume Menu
            Volume_Menu = new VolumeMenu(new Vector2f(Position_RIGHT_BOTTOM.X - 10, Position_RIGHT_BOTTOM.Y - 70));

            //Play/Pause Button
            new SpriteButton("Button_Play_Pause", Alignment.CENTER_BOTTOM, Position_CENTER_BOTTOM.X + 25, Position_CENTER_BOTTOM.Y - 10, "button_play");
            App.GetElemByName("Button_Play_Pause").RenderLayer = 1;

            //Stop Button
            new SpriteButton("Button_Stop", Alignment.CENTER_BOTTOM, Position_CENTER_BOTTOM.X - 25, Position_CENTER_BOTTOM.Y - 10, "button_stop");
            App.GetElemByName("Button_Stop").RenderLayer = 1;

            //Next Song Button
            new SpriteButton("Button_Next", Alignment.CENTER_BOTTOM, Position_CENTER_BOTTOM.X + 95, Position_CENTER_BOTTOM.Y - 10, "button_next");
            App.GetElemByName("Button_Next").RenderLayer = 1;

            //Previous Song Button
            new SpriteButton("Button_Previous", Alignment.CENTER_BOTTOM, Position_CENTER_BOTTOM.X - 95, Position_CENTER_BOTTOM.Y - 10, "button_previous");
            App.GetElemByName("Button_Previous").RenderLayer = 1;

            //Toggle Volume Menu Button
            new SpriteButton("Button_Volume_Menu_Toggle", Alignment.RIGHT_BOTTOM, Position_RIGHT_BOTTOM.X - 10, Position_RIGHT_BOTTOM.Y - 10, "button_volume", Action_ToggleVolumeMenu);
            App.GetElemByName("Button_Volume_Menu_Toggle").RenderLayer = 1;

            //Song Time
            new SimpleText("Song_Time", Alignment.CENTER_BOTTOM, Position_CENTER_BOTTOM.X, Position_CENTER_BOTTOM.Y - 100, new Color(255, 255, 255, 255), "sansC", 20, Text.Styles.Regular, "0:00");
            App.GetElemByName("Song_Time").RenderLayer = 1;

            //Song Time Line
            new ProgressBar("Song_TimeLine", 600, 15, Position_CENTER_BOTTOM.X, Position_CENTER_BOTTOM.Y - 145, ProgressBarStyles.HORIZONTAL, new Color(138, 138, 138, 255), new Color(205, 205, 205, 255), 0);
            App.GetElemByName("Song_TimeLine").RenderLayer = 1;

            //Song Name
            new SimpleText("Song_Name", Alignment.CENTER_CENTER, Position_CENTER_BOTTOM.X, Position_CENTER_BOTTOM.Y - 190, new Color(255, 255, 255, 255), "sansC", 20, Text.Styles.Regular, "-");
            App.GetElemByName("Song_Name").RenderLayer = 1;
        }






        private void Action_ToggleVolumeMenu()
        {
            Volume_Menu.Active = (Volume_Menu.Active) ? false : true;
        }






    }
}
