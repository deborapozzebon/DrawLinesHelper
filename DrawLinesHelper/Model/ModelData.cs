using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DrawLinesHelper.Model
{
    public class ModelData : INotifyPropertyChanged
    {
        private int _lineTickness;

        public event PropertyChangedEventHandler PropertyChanged;

        public int LineTickness
        {
            get
            {
                return _lineTickness;
            }

            set
            {
                if (value != null && _lineTickness != value)
                {
                    _lineTickness = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
