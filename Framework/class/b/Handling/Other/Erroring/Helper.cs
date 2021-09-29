
// Author: Dashie


using System;


namespace DashFramework
{
    namespace Erroring
    {
	public partial class HandleError
	{
	    public string TranslateException(Exception E)
	    {
		try
		{
		    return string.Format
		    (
			"StackTrace: {0}\r\n\r\n" +
			"Message: {1}\r\n",
			E.StackTrace, E.Message
		    );
		}

		catch
		{
		    return string.Empty;
		}
	    }

	    public void Show()
	    {
		try
		{
		    dialog.Show();
		}

		catch
		{
		    throw;
		}
	    }

	    string getHead()
	    {
		return ("Oh no, an exception was caught!");
	    }

	    string getBody(Exception E)
	    {
		return string.Format
		(
		    "Unfortunately this application has malfunctioned, making it unusable. My best advice is to restart this application to see if it solves the problem.\r\n\r\n" +
		    "If it does not however, you can always reach out to me at KvinneKraft@protonmail about the matter so I can go ahead and patch it out."
		);
	    }

	    public void Handle(Exception E)
	    {
		try
		{
		    dialog.SetContents(getHead(), getBody(E));
		}

		catch
		{
		    throw;
		}

		Show();
	    }

	    public void Hide()
	    {
		try
		{
		    dialog.Hide();
		}

		catch
		{
		    throw;
		}
	    }
	}
    }
}