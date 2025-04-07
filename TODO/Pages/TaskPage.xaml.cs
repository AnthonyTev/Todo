namespace TODO.Pages;

public partial class TaskPage : ContentPage
{
	public TaskPage()
	{
		InitializeComponent();
	}

    private async void GotoAddPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("AddPage");
    }

    private async void GotoEditPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("EditPage");
    }

  
}