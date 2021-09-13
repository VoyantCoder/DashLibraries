// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using DashFramework.Runnables;
using DashFramework.Erroring;
using DashFramework.Sorters;


namespace DashFramework
{
    namespace DashControls
    {
	namespace Customs
	{
	    public class MessageContainer
	    {
		readonly ControlIntegrator Controls = new ControlIntegrator();
		readonly PlainSorters Sorters = new PlainSorters();
		readonly DataTools DataTool = new DataTools();

		public Control ContainerParent = null;

		public Color BackColor = Color.DarkRed;
		public Color ForeColor = Color.White;

		public int ContentConfigured = -1;
		public int ContainerHeight = 40;
		public int ContainerWidth = -1;
		public int ContentFontSize = 14;
		public int ContentFontId = 1;

		public void ChangeSettings(Control ContainerParent, int ContainerWidth, int ContainerHeight, int ContentFontSize, int ContentFontId, Color ForeColor, Color BackColor)
		{
		    this.ContainerParent = ContainerParent;
		    this.ContentFontSize = ContentFontSize;
		    this.ContainerHeight = ContainerHeight;
		    this.ContainerWidth = ContainerWidth;
		    this.ContentFontId = ContentFontId;
		    this.ForeColor = ForeColor;
		    this.BackColor = BackColor;
		}

		public void SetColor(Color BackColor, Color ForeColor)
		{
		    Container.BackColor = BackColor;
		    Content.BackColor = BackColor;
		    Content.ForeColor = ForeColor;

		    this.BackColor = BackColor;
		    this.ForeColor = ForeColor;
		}


		readonly Runnable Runnable = new Runnable();
		delegate void Synchronize();

		void Sync(Synchronize sync) => Runnable.
		    RunTaskSynchronously(ContainerParent, () => sync());


		readonly DashPanel Container = new DashPanel();
		readonly Label Content = new Label();

		public bool Initialized() => (ContentConfigured != -1);

		public void Show(string Message, Point ContainerLoca, int VisibilityTimeout = -1)
		{
		    try
		    {
			Sorters.SortCode(("Validation Process"), () =>
			{
			    if (Initialized() && Container.Visible)
			    {
				return;
			    }

			    else if (ContainerParent == null)
				return;
			});

			Sorters.SortCode(("Visibility Handler"), () =>
			{
			    Point GetCenter() => new Point((Container.Width
				- GetContentSize().Width) / 2, (Container.Height - GetContentSize().Height) / 2);

			    Size GetContentSize() => DataTool.GetFontSize(Message,
				ContentFontSize, ContentFontId);

			    ContainerWidth = ContainerWidth == -1 ? ContainerParent.Width : ContainerWidth;
			    ContainerLoca = ContainerLoca.Equals(Point.Empty) ? GetCenter() : ContainerLoca;

			    if (!Initialized())
			    {
				Sorters.SortCode(("Container Initialization"), () =>
				{
				    Controls.Panel(ContainerParent, Container, new Size
					(ContainerWidth, ContainerHeight), ContainerLoca, BackColor);

				    Controls.Label(Container, Content, GetContentSize(), new Point(-2, -2),
					BackColor, ForeColor, (Message), ContentFontId, ContentFontSize);

				    ContentConfigured += 1;
				});
			    }

			    Container.Location = ContainerLoca;

			    if (!Content.Text.Equals(Message))
			    {
				Content.Size = GetContentSize();
				Content.Location = GetCenter();
				Content.Text = Message;
			    }

			    SetColor(BackColor, ForeColor);

			    Container.BringToFront();
			    Container.Show();
			});

			Sorters.SortCode(("Visibility Timeout"), () =>
			{
			    if (VisibilityTimeout > 50)
			    {
				Runnable.RunTaskLater(null, () =>
				{
				    new Thread(() =>
				    {
					Color GetBackAlpha(int Alpha, Control Control) => Color.FromArgb(Alpha,
					    Control.BackColor.R, Control.BackColor.G, Control.BackColor.B);

					Color GetForeAlpha(int Alpha, Control Control) => Color.FromArgb(Alpha,
					    Control.ForeColor.R, Control.ForeColor.G, Control.ForeColor.B);

					void UpdateColors(Color A, Color B, Color C)
					{
					    Sync(() =>
					    {
						Container.BackColor = A;
						Content.ForeColor = B;
						Content.BackColor = C;
					    });
					}

					for (int k = 255; k > 40; k -= 15)
					{
					    UpdateColors
					    (
						GetBackAlpha(k, Container),
						GetForeAlpha(k, Content),
						GetBackAlpha(k, Content)
					    );

					    Thread.Sleep(10);
					}

					Sync(() => Container.Hide());

					UpdateColors(BackColor, ForeColor, BackColor);
				    })

				    { IsBackground = true }.Start();
				},

				VisibilityTimeout);
			    }
			});
		    }

		    catch (Exception E)
		    {
			throw (ErrorHandler.GetException(E));
		    }
		}
	    }
	}
    }
}