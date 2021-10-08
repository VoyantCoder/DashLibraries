
// Author: Dashie


using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using DashFramework.DashControls.Controls;
using DashFramework.NETExtensions;


namespace DashFramework
{
    namespace DashControls
    {
	public partial class ControlIntegrator
	{
            //
            // ^^^^^^^^^^^^^^
            //
                
            public void CheckBox(Control Top, PictureBox Container1, PictureBox Container2, Size Size, Point Loca, Color DeselectedBCol, [Optional] Color SelectedBCol, [Optional] bool Select, bool Add = true)
            {
                try
                {
                    Sort.Sort(("Main Container"), () =>
                    {
                        Image(Top, Container1, Size, Loca, DeselectedBCol, Add: Add);
                    });

                    Size.Height -= 4;
                    Size.Width -= 4;

                    Sort.Sort(("Child Objects"), () =>
                    {
                        Image(Container1, Container2, Size, new Point(2, 2), DeselectedBCol);

                        Transform.Round(Container1, 2);
                        Transform.Round(Container2, 2);

                        if (Select)
                            Container2.BackColor = SelectedBCol;

                        void UpdateColor()
                        {
                            Color Col = SelectedBCol;

                            if (Container2.BackColor == Col)
                            {
                                Col = DeselectedBCol;
                            }

                            Container2.PerformLayout();
                            Container2.BackColor = Col;
                        };

                        Container1.RegisterClickEvent(UpdateColor);
                        Container2.RegisterClickEvent(UpdateColor);
                    });
                }

                catch
                {
                    throw;
                }
            }

	    public void RichTextBox(Control Top, RichTextBox Object, Size ObjectSize, Point ObjectLocation, Color ObjectBCol, Color ObjectFCol, int FontTypeID, int FontSize, bool ReadOnly = false, bool MultiLine = false, bool ScrollBar = false, bool TabStop = false, bool Add = true)
	    {
		try
		{
		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLocation);
		    Object.Font = ResourceTool.GetFont(FontTypeID, FontSize);
		    Object.BorderStyle = BorderStyle.None;
		    Object.BackColor = ObjectBCol;
		    Object.ForeColor = ObjectFCol;

		    if (ScrollBar)
		    {
			Object.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
		    }

		    Object.Multiline = MultiLine;
		    Object.ReadOnly = ReadOnly;
		    Object.TabStop = TabStop;

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }

	    public void TextBox(Control Top, TextBox Object, Size ObjectSize, Point ObjectLocation, Color ObjectBCol, Color ObjectFCol, int FontTypeID, int FontSize, bool ReadOnly = false, bool Multiline = false, bool ScrollBar = false, bool FixedSize = true, bool TabStop = false, bool Add = true)
	    {
		try
		{
		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLocation);
		    Object.BorderStyle = BorderStyle.None;
		    Object.Multiline = Multiline;
		    Object.BackColor = ObjectBCol;
		    Object.ForeColor = ObjectFCol;
		    Object.ReadOnly = ReadOnly;
		    Object.TabStop = TabStop;

		    if (FixedSize)
		    {
			var TextBoxContainer = new PictureBox();

			Transform.Resize(TextBoxContainer, ObjectSize);

			TextBoxContainer.Font = ResourceTool.GetFont(FontTypeID, FontSize);
			TextBoxContainer.BorderStyle = BorderStyle.None;
			TextBoxContainer.Location = ObjectLocation;
			TextBoxContainer.BackColor = ObjectBCol;
			TextBoxContainer.ForeColor = ObjectFCol;

			if (Add)
			{
			    Top.Controls.Add(TextBoxContainer);
			}

			TextBoxContainer.Click += (s, e) =>
			{
			    Object.Select();
			};

			var ResizedSize = new Size(ObjectSize.Width - 10, DataTool.GetFontSize("http", FontSize).Height);
			var RelocatedLocation = new Point(5, (ObjectSize.Height - ResizedSize.Height) / 2);

			Object.Location = RelocatedLocation;
			Transform.Resize(Object, ResizedSize);

			TextBoxContainers.Add(Object, TextBoxContainers.Count + 1);
			TextBoxContainer.Controls.Add(Object);
		    }

		    else
		    {
			Object.Location = ObjectLocation;
			Object.Font = ResourceTool.GetFont(FontTypeID, FontSize);

			if (ScrollBar)
			{
			    Object.ScrollBars = ScrollBars.Vertical;
			}

			if (Add)
			{
			    Top.Controls.Add(Object);
			}
		    }
		}

		catch 
		{
		    throw;
		}
	    }


	    public void TreeView(Control Top, DashTreeView Object, Size ObjectSize, Point ObjectLoca, Color ObjectBCol, Color ObjectFCol, bool Add = true)
	    {
		try
		{
		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLoca);
		    Object.BorderStyle = BorderStyle.None;
		    Object.BackColor = ObjectBCol;
		    Object.ForeColor = ObjectFCol;

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }


	    public void ListBox(Control Top, DashListBox Object, Size ObjectSize, Point ObjectLoca, Color ObjectBCol, Color ObjectFCol, bool Add = true)
	    {
		try
		{
		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLoca);
		    Object.BorderStyle = BorderStyle.None;
		    Object.BackColor = ObjectBCol;
		    Object.ForeColor = ObjectFCol;

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }


	    public void Button(Control Top, Button Object, Size ObjectSize, Point ObjectLocation, Color ObjectBCol, Color ObjectFCol, string ButtonText, int FontTypeID = 1, int FontSize = 10, bool TabStop = false, bool Add = true)
	    {
		try
		{
		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLocation);
		    Object.Font = ResourceTool.GetFont(FontTypeID, FontSize);
		    Object.FlatAppearance.BorderColor = ObjectBCol;
		    Object.FlatAppearance.BorderSize = 0;
		    Object.FlatStyle = FlatStyle.Flat;
		    Object.BackColor = ObjectBCol;
		    Object.ForeColor = ObjectFCol;
		    Object.TabStop = TabStop;
		    Object.Text = ButtonText;

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }


	    public void Label(Control Top, Label Object, Size ObjectSize, Point ObjectLocation, Color ObjectBCol, Color ObjectFCol, string LabelText, int FontTypeID = 1, int FontSize = 8, bool TabStop = false, bool Add = true)
	    {
		try
		{
		    if (ObjectSize == Size.Empty)
		    {
			ObjectSize = DataTool.GetFontSize(LabelText, FontSize);
		    }

		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLocation);
		    Object.Font = ResourceTool.GetFont(FontTypeID, FontSize);
		    Object.BorderStyle = BorderStyle.None;
		    Object.FlatStyle = FlatStyle.Flat;
		    Object.BackColor = ObjectBCol;
		    Object.ForeColor = ObjectFCol;
		    Object.TabStop = TabStop;
		    Object.Text = LabelText;

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }


	    public void Image(Control Top, PictureBox Object, Size ObjectSize, Point ObjectLoca, Color BackColor, Image ObjectImage = null, bool TabStop = false, bool Add = true)
	    {
		try
		{
		    if (ObjectSize == Size.Empty)
		    {
			if (ObjectImage == null)
			{
			    throw new Exception("No image specified.");
			}

			ObjectSize = ObjectImage.Size;
		    }

		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLoca);
		    Object.BorderStyle = BorderStyle.None;
		    Object.BackColor = BackColor;
		    Object.Image = ObjectImage;
		    Object.TabStop = TabStop;

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }


	    public void Panel(Control Top, DashPanel Object, Size ObjectSize, Point ObjectLoca, Color ObjectBCol, Control.ControlCollection ChildObjects = null, string ObjectId = "A panel!", bool Add = true)
	    {
		try
		{
		    Transform.Resize(Object, ObjectSize);

		    Object.Location = DataTool.OGetCenter(Top, Object, ObjectLoca);
		    Object.BorderStyle = BorderStyle.None;
		    Object.BackColor = ObjectBCol;
		    Object.Name = ObjectId;

		    if (ChildObjects != null)
		    {
			foreach (Control control in ChildObjects)
			{
			    Object.Controls.Add(control);
			}
		    }

		    if (Add)
		    {
			Top.Controls.Add(Object);
		    }
		}

		catch 
		{
		    throw;
		}
	    }
	}
    }
}