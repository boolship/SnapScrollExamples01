
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Media;

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

            var gridViewData1 = new GridViewData();
            NormalGridView.ItemsSource = gridViewData1.Collection;

            var gridViewData2 = new GridViewData();
            VerticalGridView.ItemsSource = gridViewData2.Collection;

            var listViewData1 = new ListViewData();
            NormalListView.ItemsSource = listViewData1.Collection;

            var listViewData2 = new ListViewData();
            HorizontalListView.ItemsSource = listViewData2.Collection;

            // debug only
            WinRTXamlToolkit.Debugging.DC.ShowVisualTree();

            Workarounds();
        }

        /// <summary>
        /// What implements IScrollSnapPointsInfo?? 
        /// 
        /// Panel\StackPanel** - yes** (working)
        /// ItemsControl**\local:SnappingItemsControl - yes** (working)
        /// 
        /// Panel\VirtualizingPanel\OrientedVirtualizingPanel**\VirtualizingStackPanel** - yes** (bug: not working)
        /// 
        /// ItemsControl\Selector\ListViewBase\GridView - no, yes iff GridView.ItemsPanel contains WrapGrid
        /// Panel\VirtualizingPanel\OrientedVirtualizingPanel**\WrapGrid - yes**
        /// 
        /// ItemsControl\Selector\ListViewBase\ListView - no
        /// Panel\ItemsWrapGrid - no
        /// ListBox - no
        /// </summary>
        private void Workarounds()
        {
            //var scrollViewer = FindScrollViewer(NormalGridView);
            //if (scrollViewer != null)
            //{
            //    // Mandatory, MandatorySingle, Optional, OptionalSingle, None
            //    scrollViewer.HorizontalSnapPointsType = SnapPointsType.MandatorySingle;
            //    // Center, Far, Near
            //    // For a vertically oriented element, Near is the top and Far is the bottom.
            //    // For a horizontally oriented element, Near is left and Far is right.
            //    scrollViewer.HorizontalSnapPointsAlignment = SnapPointsAlignment.Center;
            //    // Center, Left, Right, Stretch
            //    //scrollViewer.HorizontalContentAlignment = HorizontalAlignment.Left;
            //}



            //NormalGridView.ScrollIntoView(new object(), ScrollIntoViewAlignment.Leading);
            //NormalGridView.ShowsScrollingPlaceholders = true;

        }

        private ScrollViewer FindScrollViewer(DependencyObject d)
        {
            if (d == null) return null;
            if (d is ScrollViewer) return d as ScrollViewer;

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(d); i++)
            {
                var scrollViewer = FindScrollViewer(VisualTreeHelper.GetChild(d, i));
                if (scrollViewer != null) return scrollViewer;
            }

            return null;
        }
    }
}
