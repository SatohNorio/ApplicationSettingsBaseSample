using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ApplicationSettingsBaseSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// ApplicationSettingsBaseSample.MainWindow クラスの新しいインスタンスを作成します。
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            var setting = new MySetting();

            if (!setting.IsReadOnly)
            {
                var list = new List<ApplicationInfo>();
                list.Add(new ApplicationInfo("ApplicationSettingsBaseSample", "-d"));
                list.Add(new ApplicationInfo("MyProgram", ""));
                setting.ApplicationNames = list;
                setting.PcIpAddress = "192.168.35.100";
                setting.UdpReceivingPort = 65000;
                setting.Save();
            }
            else
            {
                var lb = this.listBox;
                var items = lb.Items;
                var collection = setting.ApplicationNames;
                if (collection != null)
                {
                    foreach (var item in collection)
                    {
                        items.Add(item);
                    }
                }
                items.Add(setting.PcIpAddress);
                items.Add(setting.UdpReceivingPort);
            }
        }
    }
}
