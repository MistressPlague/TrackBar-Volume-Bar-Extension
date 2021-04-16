namespace Libraries
{
    public static class ControlExtensions
    {
        public static List<Control> ToList(this Control.ControlCollection controls)
        {
            return controls.Cast<Control>().ToList();
        }

        public static void SetVolumeBarValue(this TrackBar trackbar, int value) // 0 -> 100
        {
            Panel panel;

            if (!trackbar.Controls.ToList().Select(o => o.BackColor).Contains(Color.Magenta))
            {
                panel = new Panel
                {
                    BackColor = Color.Magenta,
                    Location = new Point(10, -13),
                    Size = new Size(25, 198),
                    Parent = trackbar
                };

                panel.SendToBack();
            }
            else
            {
                panel = (Panel)trackbar.Controls.ToList().First(o => o.BackColor == Color.Magenta);
            }

            panel.Size = new Size(10, RealFeel.RangeConv(value, 0, 100, 0, 198));

            panel.Location = new Point(25, (trackbar.Size.Height - panel.Size.Height) - 13);
        }
    }
}
