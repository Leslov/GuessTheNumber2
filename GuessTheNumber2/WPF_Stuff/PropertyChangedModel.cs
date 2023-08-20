using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FrontWpf.ViewModels
{
	public abstract class PropertyChangedModel:INotifyPropertyChanged
	{
		public virtual event PropertyChangedEventHandler PropertyChanged;
		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}
