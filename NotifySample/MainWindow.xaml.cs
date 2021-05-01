using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Xaml.Behaviors.Core;

namespace NotifySample
{
	public partial class MainWindow : INotifyPropertyChanged
	{
		private int volume = 50;
		public int Volume
		{
			get => this.volume;
			set
			{
				this.volume = value;
				OnPropertyChanged();
			}
		}

		private bool isMuted;
		public bool IsMuted
		{
			get => this.isMuted;
			set
			{
				this.isMuted = value;
				OnPropertyChanged();
			}
		}

		private bool noDevice;
		public bool NoDevice
		{
			get => this.noDevice;
			set
			{
				this.noDevice = value;
				OnPropertyChanged();
			}
		}

		private ICommand muteCmd;
		public ICommand MuteCommand
		{
			get => this.muteCmd;
			set
			{
				this.muteCmd = value;
				OnPropertyChanged();
			}
		}

		private ICommand noDeviceCmd;
		public ICommand NoDeviceCommand
		{
			get => this.noDeviceCmd;
			set
			{
				this.noDeviceCmd = value;
				OnPropertyChanged();
			}
		}
		
		public MainWindow()
		{
			InitializeComponent();
			this.MuteCommand = new ActionCommand(() => this.IsMuted = !this.IsMuted);
			this.NoDeviceCommand = new ActionCommand(() => this.NoDevice = !this.NoDevice);
		}

		public event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}