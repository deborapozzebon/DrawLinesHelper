using DrawLinesHelper.Model;
using System.Windows.Input;

namespace DrawLinesHelper.ViewModel
{
    public class ModelDataViewModel
    {
        public ModelData ModelData_Model { get; set; }

        public ICommand ApplyChangesCommand { get; private set; }

        public ModelDataViewModel()
        {
            ModelData_Model = new ModelData() { LineTickness = 2 };
            ApplyChangesCommand = new ExecuteApplyChangesCommand().Execute(true);
        }
    }
}
