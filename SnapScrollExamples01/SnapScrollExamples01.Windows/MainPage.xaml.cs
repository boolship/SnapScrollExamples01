
namespace SnapScrollExamples01
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();


            var listViewData1 = new ListViewData();
            BottomLeft.ItemsSource = listViewData1.Collection;

            var listViewData2 = new ListViewData();
            BottomRight.ItemsSource = listViewData2.Collection;
        }
    }
}
