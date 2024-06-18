using CommunityToolkit.Mvvm.ComponentModel;
using Core.ViewModel.Common;

namespace Core.Abstract.ViewModel
{
    public abstract class ViewModelBase : ObservableObject
    {
        public VmMessage VmMessage { get; set; } = new();
    }
}
