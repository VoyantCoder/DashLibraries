
// Author: Dashie


using System.Drawing;
using System.Windows.Forms;


namespace DashFramework
{
    namespace DashControls
    {
        public partial class ControlIntegrator
        {
            public void PictureBox(Control parent, PictureBox pictureBox, Point location, Image image)
            {
                try
                {
                    if (pictureBox == null)
                    {
                        pictureBox = new PictureBox();
                        Register(parent, pictureBox);
                    }

                    Size size = image == null ? new Size(0, 0) : image.Size;

                    SetLocation(location, parent, size, pictureBox);
                    pictureBox.BackColor = Color.Transparent;

                    if (image != null)
                    {
                        pictureBox.Image = image;
                    }

                    Transform.Resize(pictureBox, size);
                    parent.Controls.Add(pictureBox);

                    UpdateRegister(parent, pictureBox);
                }

                catch
                {
                    throw;
                }
            }

            public void PictureBox(Control parent, PictureBox pictureBox, Point location, Image image, Color backColor)
            {
                try
                {
                    PictureBox(parent, pictureBox, location, image);
                    pictureBox.BackColor = backColor;
                    UpdateRegister(parent, pictureBox);
                }

                catch
                {
                    throw;
                }
            }

            public void PictureBox(Control parent, PictureBox pictureBox, Point location, Image image, Color backColor, Size size)
            {
                try
                {
                    PictureBox(parent, pictureBox, location, image, backColor);
                    Transform.Resize(pictureBox, size);
                    UpdateRegister(parent, pictureBox);
                }

                catch
                {
                    throw;
                }
            }

            public void PictureBox(Control parent, PictureBox pictureBox, Point location, Image image, Size size, bool parentBackColor)
            {
                try
                {
                    Color backColor = Color.Transparent;

                    if (parentBackColor)
                    {
                        backColor = parent.BackColor;
                    }

                    PictureBox(parent, pictureBox, location, image, backColor);
                    UpdateRegister(parent, pictureBox);
                }

                catch
                {
                    throw;
                }
            }

            public void PictureBox(Control parent, PictureBox pictureBox, Point location, Image image, Size size, bool parentBackColor, bool additionals)
            {
                try
                {
                    PictureBox(parent, pictureBox, location, image, size, parentBackColor);

                    if (additionals)
                    {
                        pictureBox.BorderStyle = BorderStyle.None;
                    }

                    UpdateRegister(parent, pictureBox);
                }

                catch
                {
                    throw;
                }
            }
        }
    }
}