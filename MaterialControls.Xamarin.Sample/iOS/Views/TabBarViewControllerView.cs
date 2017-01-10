
using System;

using Foundation;
using UIKit;
using MaterialControls;
using System.Linq;
using MaterialControls.Xamarin.Sample.Core.ViewModels;
using System.Threading.Tasks;

namespace MaterialControls.Xamarin.Sample.iOS.Views
{
    public partial class TabBarViewControllerView : BaseView<TabBarViewControllerViewModel>
    {
        MDTabBarViewController TabBarViewController;
        TabBarViewControllerDelegate Delegate;

        public TabBarViewControllerView() : base("TabBarViewControllerView", null)
        {
            Delegate = new TabBarViewControllerDelegate();
            TabBarViewController = new MDTabBarViewController(Delegate);

            TabBarViewController.TabBar.Height = 200;
            TabBarViewController.TabBar.IndicatorHeight = 1;
            TabBarViewController.TabBar.ShadowColor = UIColor.Yellow;
            TabBarViewController.TabBar.ShadowsEnabled = true;
            TabBarViewController.SetItems(new NSObject[] {
                new NSString ("FIRST TAB"),

            });

        }

        public override void DidReceiveMemoryWarning()
        {
            // Releases the view if it doesn't have a superview.
            base.DidReceiveMemoryWarning();

            // Release any cached data, images, etc that aren't in use.
        }

        public override async void ViewDidLoad()
        {
            base.ViewDidLoad();

            AddChildViewController(TabBarViewController);
            UIView controllerView = TabBarViewController.View;
            View.AddSubview(controllerView);

            NSDictionary viewsDictionary = new NSDictionary("TopLayoutGuide", TopLayoutGuide, "BottomLayoutGuide", BottomLayoutGuide, "controllerView", controllerView);
            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("V:[TopLayoutGuide]-0-[controllerView]-0-[BottomLayoutGuide]", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, viewsDictionary));
            View.AddConstraints(NSLayoutConstraint.FromVisualFormat("H:|-0-[controllerView]-0-|", NSLayoutFormatOptions.DirectionLeadingToTrailing, null, viewsDictionary));

            //await Task.Delay(2000);

        }
        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            TabBarViewController.SetSelectedIndex((nuint)(TabBarViewController.TabBar.NumberOfItems - 1));

        }
    }

    public class TabBarViewControllerDelegate : MDTabBarViewControllerDelegate
    {
        #region implemented abstract members of MDTabBarViewControllerDelegate

        public override UIViewController ViewControllerAtIndex(MDTabBarViewController viewController, nuint index)
        {
            TabContentViewController controller = new TabContentViewController("Tab " + (index + 1));
            return controller;
        }

        #endregion

    }
}

