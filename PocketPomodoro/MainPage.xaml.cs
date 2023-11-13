using System.Diagnostics;

namespace PocketPomodoro;

public partial class MainPage : ContentPage
{
	bool focusing = false;
	IDispatcherTimer timer;
	DateTime timerStop;

	public MainPage()
	{
		InitializeComponent();

		timer = Dispatcher.CreateTimer();
		timer.Interval = TimeSpan.FromMilliseconds(1000);
		timer.Tick += (sender, e) =>
		{
			TimeSpan remaining = timerStop - DateTime.Now;
			timerLabel.Text = remaining.ToString(@"mm\:ss");
		};
	}

	private void OnPomodoroClicked(object sender, EventArgs e)
	{
		focusing = !focusing;
		timerStop = focusing ? DateTime.Now.AddMinutes(25) : DateTime.Now.AddMinutes(5);
		timer.Start();
		
		//SemanticScreenReader.Announce("Begin timer");
	}
}

