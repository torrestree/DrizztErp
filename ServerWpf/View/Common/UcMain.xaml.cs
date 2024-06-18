using CoreServer.ViewModel.Common;
using System.Windows.Controls;

namespace ServerWpf.View.Common
{
    /// <summary>
    /// Interaction logic for UcMain.xaml
    /// </summary>
    public partial class UcMain : UserControl
    {
        public UcMain()
        {
            InitializeComponent();
            DataContext = new VmMain();
        }
    }
}
