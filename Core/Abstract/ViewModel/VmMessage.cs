using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Runtime.CompilerServices;

namespace Core.Abstract.ViewModel
{
	public class VmMessage : ObservableObject
	{
		private bool isVisible;
		public bool IsVisible
		{
			get => isVisible;
			set => SetProperty(ref isVisible, value);
		}

		private string title = string.Empty;
		public string Title
		{
			get => title;
			set => SetProperty(ref title, value);
		}

		private string content = string.Empty;
		public string Content
		{
			get => content;
			set => SetProperty(ref content, value);
		}

		private Exception ex = null!;
		public Exception Ex
		{
			get => ex;
			set => SetProperty(ref ex, value);
		}

		private bool isExVisible;
		public bool IsExVisible
		{
			get => isExVisible;
			set => SetProperty(ref isExVisible, value);
		}

		public RelayCommand CmdOk { get; set; }

		private bool isCmdOkVisible;
		public bool IsCmdOkVisible
		{
			get => isCmdOkVisible;
			set => SetProperty(ref isCmdOkVisible, value);
		}

		public RelayCommand CmdCancel { get; set; }

		private bool isCmdCancelVisible;
		public bool IsCmdCancelVisible
		{
			get => isCmdCancelVisible;
			set => SetProperty(ref isCmdCancelVisible, value);
		}

		private bool isWaitingVisible;
		public bool IsWaitingVisible
		{
			get => isWaitingVisible;
			set => SetProperty(ref isWaitingVisible, value);
		}

		private bool isProgressVisible;
		public bool IsProgressVisible
		{
			get => isProgressVisible;
			set => SetProperty(ref isProgressVisible, value);
		}

		private float progressMax;
		public float ProgressMax
		{
			get => progressMax;
			set => SetProperty(ref progressMax, value);
		}

		private float progress;
		public float Progress
		{
			get => progress;
			set => SetProperty(ref progress, value);
		}

		private MessageTypes messageType;
		public MessageTypes MessageType
		{
			get => messageType;
			set
			{
				messageType = value;
				switch (messageType)
				{
					case MessageTypes.Waiting:
						IsExVisible = false;
						IsCmdOkVisible = false;
						IsCmdCancelVisible = true;
						IsWaitingVisible = true;
						IsProgressVisible = false;
						break;
					case MessageTypes.Progress:
						IsExVisible = false;
						IsCmdOkVisible = false;
						IsCmdCancelVisible = true;
						IsWaitingVisible = false;
						IsProgressVisible = true;
						break;
					case MessageTypes.Info:
						IsExVisible = false;
						IsCmdOkVisible = true;
						IsCmdCancelVisible = false;
						IsWaitingVisible = false;
						IsProgressVisible = false;
						break;
					case MessageTypes.Success:
						IsExVisible = false;
						IsCmdOkVisible = true;
						IsCmdCancelVisible = false;
						IsWaitingVisible = false;
						IsProgressVisible = false;
						break;
					case MessageTypes.Warning:
						IsExVisible = false;
						IsCmdOkVisible = true;
						IsCmdCancelVisible = false;
						IsWaitingVisible = false;
						IsProgressVisible = false;
						break;
					case MessageTypes.Failure:
						IsExVisible = false;
						IsCmdOkVisible = true;
						IsCmdCancelVisible = false;
						IsWaitingVisible = false;
						IsProgressVisible = false;
						break;
					case MessageTypes.Error:
						IsExVisible = true;
						IsCmdOkVisible = true;
						IsCmdCancelVisible = false;
						IsWaitingVisible = false;
						IsProgressVisible = false;
						break;
					case MessageTypes.Confirm:
						IsExVisible = false;
						IsCmdOkVisible = true;
						IsCmdCancelVisible = true;
						IsWaitingVisible = false;
						IsProgressVisible = false;
						break;
					default: break;
				}
			}
		}

		private Awaiter MessageAwaiter { get; set; } = null!;

        public void ShowWaiting(string title, string content)
		{
			MessageType = MessageTypes.Waiting;
			Show(title, content);
        }
        public void ShowProgress(string title, string content, float progressMax)
		{
			MessageType = MessageTypes.Progress;
			ProgressMax = progressMax;
			Progress = 0;
            Show(title, content);
        }
		public async Task ShowInfo(string title, string content)
		{
			MessageType = MessageTypes.Info;
			Show(title, content);
			MessageAwaiter = new();
			await MessageAwaiter;
		}
		private void Show(string title, string content)
		{
            Title = title;
            Content = content;
            IsVisible = true;
        }

		public enum MessageTypes
		{
			Waiting,
			Progress,
			Info,
			Success,
			Warning,
			Failure,
			Error,
			Confirm,
		}

        public class Awaiter : INotifyCompletion
        {
			public bool IsCompleted { get; set; }

			public Awaiter GetAwaiter() => this;
			public void GetResult() { }
            public void OnCompleted(Action continuation)
            {
                throw new NotImplementedException();
            }
        }
    }
}
