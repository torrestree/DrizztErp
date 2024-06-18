using CommunityToolkit.Mvvm.Input;
using Core.Abstract.ViewModel;

namespace CoreServer.ViewModel.Common
{
    public class VmMain : ViewModelBase
    {
        public AsyncRelayCommand CmdInfo { get; set; }
        public AsyncRelayCommand CmdSuccess { get; set; }
        public AsyncRelayCommand CmdWarning { get; set; }
        public AsyncRelayCommand CmdFailure { get; set; }
        public AsyncRelayCommand CmdError { get; set; }
        public AsyncRelayCommand CmdOkCancel { get; set; }
        public AsyncRelayCommand CmdYesNoCancel { get; set; }

        public VmMain()
        {
            CmdInfo = new(() => VmMessage.ShowInfo("提示", "查看提示。"));
            CmdSuccess = new(() => VmMessage.ShowSuccess("完成", "操作完成。"));
            CmdWarning = new(() => VmMessage.ShowWarning("警告", "风险警告。"));
            CmdFailure = new(() => VmMessage.ShowFailure("失败", "操作失败。"));
            CmdError = new(() => VmMessage.ShowError("错误", "出现错误。"));
            CmdOkCancel = new(() => VmMessage.ShowOkCancel("确认1","确认操作。"));
            CmdYesNoCancel = new(() => VmMessage.ShowYesNoCancel("确认2", "确认操作。"));
        }
    }
}
