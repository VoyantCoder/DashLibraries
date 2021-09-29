
// Author: Dashie


using System;
using System.Drawing;
using System.Windows.Forms;

using DashFramework.Forms;
using DashFramework.ControlTools;
using DashFramework.DashControls;
using DashFramework.DashControls.Controls;


namespace DashFramework
{
    namespace DashDialogs
    {
	public enum DiagColorType
	{
	    UIMenuBar, UI, UIText
	}

	public partial class SimpleDialog
	{
	    Color UIMenubarBackColor = Color.FromArgb(8, 8, 8);
	    Color UIBackColor = Color.FromArgb(24, 24, 24);
	    Color UIBorderBackColor = Color.Black;
	    Color UITextForeColor = Color.White;

	    public void UUIMenubarBackColor(Color color)
	    {
		try
		{
		    Window.Menubar().SetMenubarBackColor(color);
		    UIMenubarBackColor = color;
		}

		catch
		{
		    throw;
		}
	    }

	    public void UUIBackColor(Color color)
	    {
		try
		{
		    Window.SetWindowBackColor(color);
		    UIBackColor = color;
		}

		catch
		{
		    throw;
		}
	    }

	    public void UUITextForeColor(Color color)
	    {
		try
		{
		    Window.Menubar().SetTitleForeColor(color);

		    HeadLabel.ForeColor = color;
		    BodyLabel.ForeColor = color;
		    CloseBttn.ForeColor = color;

		    UITextForeColor = color;
		}

		catch
		{
		    throw;
		}
	    }

	    public void UpdateColor(Color color, DiagColorType colorType)
	    {
		try
		{
		    void Hook1()
		    {
			try
			{
			    UUIMenubarBackColor(color);
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook2()
		    {
			try
			{
			    UUITextForeColor(color);
			}

			catch
			{
			    throw;
			}
		    }

		    void Hook3()
		    {
			try
			{
			    UUIBackColor(color);
			}

			catch
			{
			    throw;
			}
		    }

		    switch (colorType)
		    {
			case DiagColorType.UIMenuBar: Hook1(); break;
			case DiagColorType.UIText: Hook2(); break;
			case DiagColorType.UI: Hook3(); break;
		    }
		}

		catch
		{
		    throw;
		}
	    }
	    
	    public void UpdateColors(Color[] colors, params DiagColorType[] colorTypes)
	    {
		try
		{
		    Exception Exception(string desc) => throw new Exception(desc);

		    if (colors.Length != colorTypes.Length)
			throw Exception("Inequal length of colors and types of colors.");
		    
		    for (int k = 0; k < colors.Length; k += 1)
		    {
			UpdateColor(colors[k], colorTypes[k]);
		    }
		}

		catch
		{
		    throw;
		}
	    }

	    public bool RoundSides = true;

	    readonly DashWindow Window = new DashWindow();
	    readonly Button CloseBttn = new Button();

	    readonly Label HeadLabel = new Label();
	    readonly Label BodyLabel = new Label();

	    public void SetContents(string head, string body)
	    {
		try
		{

		}

		catch
		{
		    throw;
		}
	    }

	    readonly ControlIntegrator Integrate = new ControlIntegrator();
	    readonly Transformer Transform = new Transformer();
	}
    }
}