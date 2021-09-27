
// Author: Dashie


namespace DashFramework
{
    namespace DashDialogs
    {
	public partial class SimpleDialog
	{
	    public void Show()
	    {
		WindowInstance.Show();
		WindowInstance.BringToFront();
	    }

	    public void Hide()
	    {
		WindowInstance.Hide();
	    }
	}
    }
}