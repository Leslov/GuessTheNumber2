using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontWpf.ViewModels
{
	public class MainWindowViewModel : PropertyChangedModel
	{

		public MainWindowViewModel()
		{
			GuessCommand = new RelayCommand(g => _onGuessCanExecute, (_) => OnGuess());
		}
		public RelayCommand GuessCommand { get; }

		private ushort _userGuessShort;
		private string _userGuess;
		private bool _onGuessCanExecute;
		public string UserGuess
		{
			get => _userGuess;
			set
			{
				if (ushort.TryParse(value, out var result) && result.HasUniqueDigits() || value == string.Empty)
				{
					_userGuessShort = result;
					_userGuess = value;
					_onGuessCanExecute = _userGuess.Length == 4;
				}
				OnPropertyChanged();
			}
		}

		private List<GuessResult> History { get; } = new List<GuessResult>();

		private void OnGuess()
		{
			History.Add(new GuessResult(_userGuessShort, 2, 1));
		}
	}
}
