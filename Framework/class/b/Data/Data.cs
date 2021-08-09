// Sector Name:
// Author: Dashie


#pragma warning disable IDE1006


using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

using DashFramework.DashResources;
using DashFramework.Erroring;

using DashFramework.resources; // {safe_projectname}


namespace DashFramework
{
    namespace Data
    {
	public class DataTools
	{
	    // Date & Times:
	    public string GetCurrentDate() => DateTime.Now.ToLongDateString();
	    public string GetCurrentTime() => DateTime.Now.ToLongTimeString();


	    // Color Related:
	    public string RGBString(Color cc) => ($"{cc.R}, {cc.G}, {cc.B}");

	    public Color NegativeRGB(int minus, Color origin)
	    {
		return
		(
		    Color.FromArgb
		    (
			origin.R - minus,
			origin.G - minus,
			origin.B - minus
		    )
		);
	    }

	    public Color PositiveRGB(int plus, Color origin)
	    {
		return
		(
		    Color.FromArgb
		    (
			origin.R + plus,
			origin.G + plus,
			origin.B + plus
		    )
		);
	    }

	    public Size ResizeSize(Size Original, int X, int Y, bool Add = true)
	    {
		Original.Height += Y;
		Original.Width += X;

		if (!Add)
		{
		    Original.Height -= (2 * Y);
		    Original.Width -= (2 * X);
		}

		return (Original);
	    }

	    public Size SubstractSize(int Amount, Size Size)
	    {
		return new Size(Size.Width - Amount, Size.Height - Amount);
	    }


	    // Coordinate Related:
	    public Point GetCenterFor(Control This, Control BasedOn, bool FromLeft = true, bool FromTop = true, int X = -1, int Y = -1)
	    {
		try
		{
		    int x = FromLeft ? (BasedOn.Width - This.Width) / 2 : (X != -1 ? X : 0);
		    int y = FromTop ? (BasedOn.Height - This.Height) / 2 : (Y != -1 ? Y : 0);

		    return new Point(x, y);
		}

		catch
		{
		    return Point.Empty;
		}
	    }


	    public Point OGetCenter(Control BasedOn, Control This, Point Coords)
	    {
		try
		{
		    int x = (Coords.X == -1 ? (BasedOn.Width - This.Width) / 2 : Coords.X);
		    int y = (Coords.Y == -1 ? (BasedOn.Height - This.Height) / 2 : Coords.Y);

		    return new Point(x, y);
		}

		catch
		{
		    return Point.Empty;
		}
	    }


	    // Font Related:
	    readonly ResourceTools ResourceTool = new ResourceTools();
	    public Size GetFontSize(string Text, int Size = 10, int Id = 1)
	    {
		return TextRenderer.MeasureText(Text, ResourceTool.GetFont(Id, Size));
	    }
	}


	public class Lists
	{
	    public class Dashlet<A, B, C>//Three Datatype Storage
	    {
		public A a;
		public B b;
		public C c;

		public A Item1() => a;
		public B Item2() => b;
		public C Item3() => c;

		public Dashlet(A a, B b, C c)
		{
		    this.a = a;
		    this.b = b;
		    this.c = c;
		}
	    }


	    public class DashList<A>//One Datatype Storage
	    {
		private readonly List<A> a = new List<A>();

		public A Get(int id)
		{
		    if (a.Count - 1 < id)
		    {
			return default(A);
		    }

		    return a[id];
		}

		public bool Remove(int id)
		{
		    if (a.Count - 1 < id)
		    {
			return false;
		    }

		    a.RemoveAt(id);

		    return true;
		}
	    }
	}


	public class Values
	{
	    // List Related:
	    public List<string> GetLineIf(string file, string contains)
	    {
		try
		{
		    var lines = new List<string>();

		    if (!File.Exists(file))
		    {
			return null;
		    }

		    foreach (string line in File.ReadAllLines(file))
		    {
			if (line.IndexOf(contains, StringComparison.OrdinalIgnoreCase) >= 0)
			{
			    lines.Add(line);
			}
		    }

		    return lines;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public List<object> ListRemove(List<object> obj, object criteria)
	    {
		try
		{
		    for (int id = 0; id < obj.Count; id += 1)
		    {
			if (obj[id] == criteria)
			{
			    obj.RemoveAt(id);
			}
		    }

		    return obj;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    // String etc Related:
	    public bool ArrayContains(object obj, object[] arr)
	    {
		for (int k = 0; k < arr.Length; k += 1)
		    if (arr[k] != obj && !arr[k].Equals(obj))
			return false;
		return true;
	    }


	    public string Replace(string obj, string to, params string[] wha)
	    {
		try
		{
		    foreach (string criteria in wha)
		    {
			obj = obj.ToLower().Replace(criteria
			    .ToLower(), $@"{to}");
		    }

		    return obj;
		}

		catch (Exception E)
		{
		    throw (ErrorHandler.GetException(E));
		}
	    }


	    public bool IsAnyNull(params object[] targets)
	    {
		foreach (object target in targets)
		    if (target == null)
			return true;
		return false;
	    }
	}


	public class Files
	{
	    public bool MoveFile(string from, string to, bool exceptionFail = false)
	    {
		try
		{
		    if (!File.Exists(from))
		    {
			throw new Exception("#1");
		    }

		    else if (File.Exists(to))
		    {
			File.Delete(to);
		    }

		    File.Move(from, to);

		    if (!File.Exists(to))
		    {
			throw new Exception("#2");
		    }

		    return true;
		}

		catch (Exception E)
		{
		    if (exceptionFail)
		    {
			ErrorHandler.GetException(E);
		    }
		}

		return false;
	    }
	}
    }
}