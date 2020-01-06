using Microsoft.Toolkit.Win32.UI.XamlHost;

namespace OilLakeHost
{
    /// <summary>
    /// 既定の Application クラスを補完するアプリケーション固有の動作を提供します。
    /// </summary>
    sealed partial class App : XamlApplication
    {
        public App()
        {
            Initialize();
        }
    }
}
