using System;
using System.Collections.Generic;
using ScnSideMenu.Forms;
using Xamarin.Forms;

namespace ZCDemoForNewUI
{
    public partial class FilterPage 
    {
        public FilterPage() : base(PanelSetEnum.psLeftRight)
        {
            //FlowDirection = FlowDirection.RightToLeft;
            #region right menu
            var btnRightMenuShow = new Button
            {
                //Text = "Right menu ",
                Text = "BACK",
                TextColor = Color.Gray,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                BackgroundColor = Color.Transparent,
            };

            btnRightMenuShow.Clicked += (s, e) =>
            {
                App.Current.MainPage = new DashboardPage();
            };
            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += (sender, e) =>
            //{

            //    Image theImage = (Image)sender;
            //    IsShowLeftPanel = !IsShowLeftPanel;
            //};
            //var btnRightMenuShow = new Image() { Source = "icon8-search-50.png", WidthRequest = 30, HeightRequest = 30 };
            //btnRightMenuShow.BackgroundColor = Color.Gray;
            //btnRightMenuShow.GestureRecognizers.Add(tapGestureRecognizer);
            //btnRightMenuShow.HorizontalOptions = LayoutOptions.StartAndExpand;

            var lblPageTitle = new Label
            {
                Text = "Search Filter",
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            Grid grid = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Star }
                }

            };
            grid.Children.Add(btnRightMenuShow, 0,0);
            // grid.Children.Add(menuimage, 0, 0);
            grid.Children.Add(lblPageTitle, 1, 0);
            // grid.Children.Add(btnRightMenuShow, 2, 0);
            grid.BackgroundColor = Color.White;
            grid.HorizontalOptions = LayoutOptions.FillAndExpand;


            Header.Content = grid;
            //set width for right panel
            RightPanelWidth = 300;
           
            RightPanel.BackgroundColor = Color.White;
           // LeftPanel.BackgroundColor = Color.Brown;
            //add label to main layout on right panel
            RightPanel.AddToContext(
                new StackLayout
                {
                    Padding = new Thickness(32),
                    Children =
                {
                    new Label
                    {
                        Text = "Business Unit",
                        TextColor = Color.Black
                    }
                }
                });
            RightPanel.BackgroundColor = Color.Yellow;



            #endregion
            #region Page Content
            var lblPageTitle1 = new Label
            {
                Text = "Business Unit :",
                //BackgroundColor = Color.AliceBlue,
                TextColor = Color.Gray,
                VerticalOptions = LayoutOptions.Center,
               //HorizontalOptions = LayoutOptions.CenterAndExpand
            };
            var lblEntry = new Entry
            {
                BackgroundColor = Color.AliceBlue,
                VerticalOptions = LayoutOptions.Center,
               // HorizontalOptions = LayoutOptions.EndAndExpand
            };

            lblEntry.Focused += async (sender, e) =>
            {

                //remove the focus so that the next Tap-Event raises again after tapping.
                Device.BeginInvokeOnMainThread(() =>
                {
                    lblEntry.Unfocus();
                });
                //await Navigation.PushAsync(new MyChooseProjectPage());
                IsShowRightPanel = !IsShowRightPanel;
            };
            Grid grid1 = new Grid
            {
                ColumnDefinitions =
                {
                    new ColumnDefinition { Width = GridLength.Auto },
                    new ColumnDefinition { Width = GridLength.Star },
                    new ColumnDefinition { Width = GridLength.Auto }
                }

            };
            //grid.Children.Add(btnLeftMenuShow, 0,0);
            grid1.Children.Add(lblPageTitle1, 0, 0);
            grid1.Children.Add(lblEntry, 1, 0);
            //grid1.HeightRequest = 80;
            // grid1.HorizontalOptions = LayoutOptions.FillAndExpand;
            //grid.Children.Add(btnLeftMenuShow, 0,0);
            // grid.Children.Add(menuimage, 0, 0);
           
            // grid.Children.Add(btnRightMenuShow, 2, 0);
            grid1.BackgroundColor = Color.AliceBlue;
            grid1.HorizontalOptions = LayoutOptions.FillAndExpand;
            grid1.VerticalOptions = LayoutOptions.FillAndExpand;

            ContentPresenter.HorizontalOptions = LayoutOptions.FillAndExpand;
            ContentPresenter.VerticalOptions = LayoutOptions.FillAndExpand;
            ContentPresenter.Content = grid1;
            ContentPresenter.BackgroundColor = Color.White;
           //Footer.IsVisible = false;
            #endregion

        }
    }
}
