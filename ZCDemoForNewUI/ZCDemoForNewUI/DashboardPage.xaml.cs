using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ImageCircle.Forms.Plugin.Abstractions;
using ScnSideMenu.Forms;
using Xamarin.Forms;
using ZCDemoForNewUI.Controls;
using ZCDemoForNewUI.Model;

namespace ZCDemoForNewUI
{
    public partial class DashboardPage
    {

        public DashboardPage() : base(PanelSetEnum.psLeftRight)
        {


            #region header
            //ContentLayout.Children.Add()
            //Grid _mainLayout = new Grid
            //{
            //    Padding = new Thickness(0),
            //    RowSpacing = 0,
            //};
            //if (Device.OS == TargetPlatform.iOS)
            //    _mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(40, GridUnitType.Absolute) });
            //_mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(44, GridUnitType.Absolute) });
            //_mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
            //_mainLayout.RowDefinitions.Add(new RowDefinition { Height = new GridLength(44, GridUnitType.Absolute) });

            //Content = new ContentView { Content = _mainLayout };

            //baseLayout.Children.Add(Content,
            //Constraint.Constant(0),
            //Constraint.Constant(0),
            //Constraint.RelativeToParent(parent => { return parent.Width; }),
            //Constraint.RelativeToParent(parent => { return parent.Height; }));
            //baseLayout.Children.Add(Content);


            #endregion
            #region right menu
            var btnRightMenuShow = new Button
            {
                //Text = "Right menu ",
                Text = "SRCH",
                TextColor = Color.Gray,
                HorizontalOptions = LayoutOptions.EndAndExpand,
                BackgroundColor = Color.Transparent
                //HorizontalOptions = LayoutOptions.Start
            };
            //click on search menu
            //btnRightMenuShow.Clicked += (s, e) => { IsShowRightPanel = !IsShowRightPanel; };
            btnRightMenuShow.Clicked += (s, e) =>
            {
                App.Current.MainPage = new FilterPage();
            };
            //left
            //var btnLeftMenuShow = new Button
            //{
            //    Image = "menusupersmall.png",

            //    BackgroundColor = Color.Transparent

            //};
            //btnLeftMenuShow.Clicked += (s, e) => { IsShowLeftPanel = !IsShowLeftPanel; };
            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += (sender, e) =>
            {

                Image theImage = (Image)sender;
                IsShowLeftPanel = !IsShowLeftPanel;
            };
            var menuimage = new Image() { Source = "menumedium.png", WidthRequest = 30, HeightRequest = 30 };
            menuimage.BackgroundColor = Color.Gray;
            menuimage.GestureRecognizers.Add(tapGestureRecognizer);
            menuimage.HorizontalOptions = LayoutOptions.StartAndExpand;
            //menuimage.BackgroundColor = Color.Red;

            var lblPageTitle = new Label
            {
                Text = "Dashboard",
                TextColor = Color.Gray,
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
            //grid.Children.Add(btnLeftMenuShow, 0,0);
            grid.Children.Add(menuimage, 0, 0);
            grid.Children.Add(lblPageTitle, 1, 0);
            grid.Children.Add(btnRightMenuShow, 2, 0);
            grid.BackgroundColor = Color.White;
            grid.HorizontalOptions = LayoutOptions.FillAndExpand;


            Header.Content = grid;
            //set width for right panel
            RightPanelWidth = 300;
            //add label to main layout on right panel
            RightPanel.AddToContext(
                new StackLayout
                {
                    Padding = new Thickness(32),
                    Children =
                    {
                        new Button
                        {
                            Text = "right menu",
                            TextColor = Color.Red,
                        }
                    }
                });
            //RightPanel.BackgroundColor = Color.Blue;

            //LeftPanel.AddToContext(
            //new StackLayout
            //{
            //    Padding = new Thickness(32),
            //    Children =
            //    {
            //        new Label
            //        {
            //            Text = "Accordian Control",
            //            TextColor = Color.Black
            //        }
            //    }
            //});
            //LeftPanel.BackgroundColor = Color.Yellow;
            LeftPanelWidth = 500;
            var stcklayout1 = new StackLayout
            {
                HeightRequest = 800,
                WidthRequest = LeftPanelWidth - 200,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                //BackgroundColor = Color.Black
                BackgroundColor = Color.White

                // Opacity = 0.6

                                    
            };
            //PreparedObject();

            LeftPanel.AddToContext(
                new StackLayout
                {
                    Children = {
                    stcklayout1
                }
                });
            //TransparentSize = 200;
            LeftPanel.Click += (s, e) => { 

                ClosePanel();
            };
            BuildLeftNavigationMenu();
            #endregion

            #region left menu
            //var btnLeftMenuShow = new Button
            //{
            //    Text = "Left menu show",
            //};
            //btnLeftMenuShow.Clicked += (s, e) => { IsShowLeftPanel = !IsShowLeftPanel; };

            //ContentLayout.Children.Add(btnLeftMenuShow);

            //LeftPanel.BackgroundColor = Color.Yellow;
            //LeftPanel.AddToContext(
            //new StackLayout 
            //{
            //    Padding = new Thickness(32),
            //    Children =
            //    {
            //        new Label
            //        {
            //            Text = "left menu",
            //            TextColor = Color.Green,
            //        }
            //    }
            //});

            #endregion
            #region build left navigation
            void BuildLeftNavigationMenu()
            {
                ObservableCollection<AccordionSource> AccordianItems = FillData();
                var vFirst = true;
                foreach (var vSingleItem in AccordianItems)
                {
                    var vHeaderGrid = new AccordionGrid();
                    if (vSingleItem.IsProfile)
                    {
                        var profileGrid = new Grid();
                        profileGrid.BackgroundColor = Color.FromHex("#bedceb");
                        profileGrid.RowDefinitions.Add(new RowDefinition { Height = 80 });
                        profileGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = 80 });
                        profileGrid.ColumnSpacing = 0;
                        profileGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });

                        CircleImage img = new CircleImage
                        {
                            Source = ImageSource.FromUri(new Uri("https://www.codeproject.com/KB/GDI-plus/ImageProcessing2/flip.jpg")),
                            HeightRequest = 110,
                            WidthRequest = 110,
                            Aspect = Aspect.AspectFill,
                            Margin = new Thickness(10, 0, 0, 0)
                        };

                        profileGrid.Children.Add(img);
                        Label name = new Label
                        {
                            HorizontalTextAlignment = TextAlignment.Center,
                            HorizontalOptions = LayoutOptions.Center,
                            VerticalOptions = LayoutOptions.Center,
                            FontSize = 14,
                            Margin = new Thickness(-100, 0, 0, 0),
                            TextColor = Color.FromHex("#444444"),
                            Text = "Annuraada..."
                        };
                        Grid.SetColumn(name, 1);
                        profileGrid.Children.Add(name);
                        stcklayout1.Children.Add(profileGrid);
                    }
                    else
                    {
                        vHeaderGrid.Text = vSingleItem.HeaderText;
                        //vHeaderGrid.InputTransparent = true;
                        vHeaderGrid.BackgroundColor = vSingleItem.HeaderBackGroundColor;


                        vHeaderGrid.IsLogout = vSingleItem.IsLogout;
                        if (!vSingleItem.IsLogout)
                        {
                            Label key = new Label();
                            key.AutomationId = vSingleItem.HeaderText + "_Dashboard_AutomationId";
                            key.HorizontalOptions = LayoutOptions.Center;
                            key.VerticalOptions = LayoutOptions.Center;
                            key.TextColor = Color.Black;
                            key.FontSize = 26;
                            key.BackgroundColor = Color.White;
                            key.FontFamily = "FontAwesome";
                            //key.Text = FontAwesome.FAAngleDown;
                            vHeaderGrid.RightContent = key;


                        }

                        vHeaderGrid.DataBind();
                        var vAccordionContent = new ContentView()
                        {
                            Content = vSingleItem.ContentItems,
                            IsVisible = false
                        };
                        if (vFirst)
                        {
                            vHeaderGrid.Expand = true;
                            vAccordionContent.IsVisible = true;
                            vFirst = false;
                        }
                        TapGestureRecognizer tapped = new TapGestureRecognizer();
                        tapped.Tapped += HeaderGridTapped;

                        vHeaderGrid.GestureRecognizers.Add(tapped);
                        vHeaderGrid.AssosiatedContent = vAccordionContent;

                        // vHeaderButton.Clicked += OnAccordionButtonClicked;
                        stcklayout1.Children.Add(vHeaderGrid);

                        stcklayout1.Children.Add(vAccordionContent);
                    }
                };
            }
            void HeaderGridTapped(object sender, EventArgs e)
            {
                var senderGrid = sender as AccordionGrid;
                try
                {
                    if (sender != null)
                    {

                        Label rightContent = senderGrid.RightContent as Label;

                        if (senderGrid.IsLogout)
                        {
                            //App.MasterDetailVM.IsExecuting = true;

                            //CommonService.LogoutService((r) =>
                            //{
                            //    CommonService.Logout(sender);

                            //    App.MasterDetailVM.IsExecuting = false;
                            //    if (r.Count > 0)
                            //    {
                            //        DialogService.InfoDailog(r[0].Message, Common.MESSAGE_TYPE_ALERT);
                            //    }
                            //    App.MasterDetailVM.RemoveAllPages();
                            //});
                        }
                        if (senderGrid.Expand)
                        {
                            senderGrid.Expand = false;
                            //rightContent.FontFamily = "FontAwesome";
                            //rightContent.Text = FontAwesome.FAAngleDown;
                        }
                        else
                        {
                            senderGrid.Expand = true;
                            //rightContent.FontFamily = "FontAwesome";
                           // rightContent.Text = FontAwesome.FAAngleUp;

                        }
                        senderGrid.AssosiatedContent.IsVisible = senderGrid.Expand;
                    }
                }
                catch (Exception ex)
                {
                    //EventLogger.HandleException(ex);
                }
            }
            ObservableCollection<AccordionSource> FillData()
                {
                    var vResult = new ObservableCollection<AccordionSource>();
                    var accordianObject = PreparedObject();
                    foreach (var item in accordianObject)
                    {
                        Frame frame = new Frame
                        {
                            CornerRadius = 6,
                            Margin = 10,
                            BackgroundColor = Color.LightGray
                        };

                        Grid gd = new Grid();
                        gd.Margin = new Thickness(10);
                        // gd.BackgroundColor = Color.FromHex("#01446b");
                        if (item.ChildItemList.Count > 0)
                        {
                            foreach (var child in item.ChildItemList)
                            {
                                gd.RowDefinitions.Add(new RowDefinition { Height = 20 });
                                //gd.RowSpacing = 1;
                                gd.ColumnSpacing = 1;
                                // gd.Margin = new Thickness(2, 0, 0, 0);
                            }
                            if (item.ChildItemList.Any(q => q.BadgeCount > 0))
                            {
                                gd.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
                                gd.ColumnDefinitions.Add(new ColumnDefinition { Width = 20 });
                            }
                            int rowCount = 0;
                            foreach (var actual in item.ChildItemList)
                            {

                                Label lbl = new Label();
                                lbl.AutomationId = actual.Title + "_Dashboard_AutomationId";
                                lbl.Text = actual.Title;
                                lbl.VerticalTextAlignment = TextAlignment.Center;
                                lbl.StyleId = actual.Id;

                                lbl.FontSize = 14;
                                lbl.Margin = new Thickness(3, 0, 0, 0);
                                lbl.TextColor = Color.FromHex("#444444");
                                TapGestureRecognizer tapped = new TapGestureRecognizer();
                                tapped.Tapped += Tapped_Tapped;
                                lbl.GestureRecognizers.Add(tapped);
                                Grid.SetRow(lbl, rowCount);
                                if (actual.BadgeCount > 0)
                                {
                                    /*BoxView bx = new BoxView();
                                    bx.HeightRequest = 5;
                                    bx.WidthRequest = 5;

                                    bx.BackgroundColor = Color.White;
                                    Grid.SetColumn(bx, 1);
                                    Grid.SetRow(bx, rowCount);

                                    gd.Children.Add(bx);*/
                                    //RoundBorderStackLayout rd = new RoundBorderStackLayout();
                                    //rd.Margin = new Thickness(0, 0, 5, 0);
                                    //rd.BackgroundColor = Color.FromHex("#686868");
                                    //rd.VerticalOptions = LayoutOptions.CenterAndExpand;
                                    //rd.CornerRadius = 40;
                                    //rd.HeightRequest = 80;
                                    //rd.WidthRequest = 120;
                                    //Label bubblecount = new Label();
                                    //bubblecount.AutomationId = actual.Title + "_BubbleCount_Dashboard_AutomationId";
                                    //bubblecount.HeightRequest = 20;
                                    //bubblecount.WidthRequest = 30;
                                    //bubblecount.FontSize = 14;
                                    //bubblecount.Margin = new Thickness(0, 5, 0, 0);
                                    //bubblecount.Text = actual.BadgeCountLabel;
                                    //bubblecount.TextColor = Color.White;
                                    //bubblecount.VerticalTextAlignment = TextAlignment.Center;
                                    //bubblecount.HorizontalTextAlignment = TextAlignment.Center;
                                    //bubblecount.HorizontalOptions = LayoutOptions.Center;
                                    //bubblecount.VerticalOptions = LayoutOptions.Center;
                                    //rd.Children.Add(bubblecount);
                                    //Grid.SetColumn(rd, 1);
                                    //Grid.SetRow(rd, rowCount);
                                    //gd.Children.Add(rd);
                                }
                                gd.Children.Add(lbl);
                                rowCount++;
                            }
                            frame.Content = gd;
                            vResult.Add(new AccordionSource
                            {
                                IsLogout = item.IsLogout,
                                IsProfile = item.IsProfile,
                                HeaderText = item.Section,
                                HeaderTextColor = Color.Black,
                                HeaderBackGroundColor = Color.White,
                                ContentItems = frame
                            });
                        }
                        else
                        {
                            frame.Content = gd;
                            vResult.Add(new AccordionSource
                            {
                                IsLogout = item.IsLogout,
                                IsProfile = item.IsProfile,
                                HeaderText = item.Section,
                                HeaderTextColor = Color.Black,
                                HeaderBackGroundColor = Color.White,
                                ContentItems = frame,
                            });
                        }
                    }
                    return vResult;
                }
                void Tapped_Tapped(object sender, EventArgs e)
                {
                    var lbl = sender as Label;
                    var selectedTitle = string.Empty;
                    if (lbl != null)
                        selectedTitle = lbl.StyleId;
                        
                    //Call funcation to handle the page navigation after click on any dashboard tile or left navigation panel item
                    HandlePageNavigation(selectedTitle);
                }
                void HandlePageNavigation(string selectedTitle, bool isFromDashboard = false)
                {
                App.Current.MainPage = new ListPageCommon(selectedTitle);
                };
                List<LeftNavigationData> PreparedObject()
                {
                    var Items = new List<LeftNavigationData>();
                    var UserTypeID = 2;//App.UserSession.CurrentUserInfo.UserTypeID;
                    LeftNavigationData navigationData = new LeftNavigationData();
                    if (UserTypeID == 2)
                    {
                        navigationData.Section = "Dashboard";//CultureUtility.GetResxNameByValue(Headers.REQUISITIONS);
                        //navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Manage Submissions", Id = "submissions-approval", BadgeCount = 0, BadgeCountLabel = "" });

                        //BubbleCount Logic still pending
                        //if (Counts.requisitionApprovalCount > 0 || Counts.sowRequisitionApprovalCount > 0)
                        //{
                        //    if (Counts.requisitionApprovalCount > 0)
                        //    {
                        //        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.APPROVE_STAFF_AUG_REQUISITION), Id = "approve-requisition-list", BadgeCount = Counts.requisitionApprovalCount, BadgeCountLabel = Counts.requisitionApprovalCount > 100 ? "99+" : Counts.requisitionApprovalCount.ToString() });
                        //    }
                        //    if (Counts.sowRequisitionApprovalCount > 0)
                        //    {
                        //        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.APPROVE_SOW_REQUISITIONS), Id = "approve_sow_requisitions", BadgeCount = Counts.sowRequisitionApprovalCount, BadgeCountLabel = Counts.sowRequisitionApprovalCount > 100 ? "99+" : Counts.sowRequisitionApprovalCount.ToString() });
                        //    }
                        //}

                        Items.Add(navigationData);
                        //if (App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions.AllowEngagement == true && Counts.sowEngagementApprovalCount > 0)
                        //{
                        //    navigationData = new LeftNavigationData();
                        //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.ENGAGEMENTS);
                        //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.APPROVE_ENGAGEMENTS), Id = "Approve-Engagements", BadgeCount = Counts.sowEngagementApprovalCount, BadgeCountLabel = Counts.sowEngagementApprovalCount > 100 ? "99+" : Counts.sowEngagementApprovalCount.ToString() });
                        //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.MANAGE_ENGAGEMENTS), Id = "View-Egagements", BadgeCount = Counts.numberOfPendingEngagementsReview, BadgeCountLabel = Counts.numberOfPendingEngagementsReview > 100 ? "99+" : Counts.numberOfPendingEngagementsReview.ToString() });
                        //    Items.Add(navigationData);
                        //}
                        //else if (App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions.AllowEngagement == true)
                        //{
                        //    navigationData = new LeftNavigationData();
                        //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.ENGAGEMENTS);
                        //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.MANAGE_ENGAGEMENTS), Id = "View-Egagements", BadgeCount = Counts.numberOfPendingEngagementsReview, BadgeCountLabel = Counts.numberOfPendingEngagementsReview > 100 ? "99+" : Counts.numberOfPendingEngagementsReview.ToString() });
                        //    Items.Add(navigationData);
                        //}
                    }
                    //else if (UserTypeID == (int)UserType.Vendor_UserType && App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions.AllowRequisitions == true)
                    //{
                    //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.REQUISITIONS);
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.VIEW_OPEN_REQUISITIONS), Id = "view-open-requisition-list", BadgeCount = Counts.requisitionApprovalCount, BadgeCountLabel = Counts.requisitionApprovalCount > 100 ? "99+" : Counts.requisitionApprovalCount.ToString() });
                    //    Items.Add(navigationData);
                    //}

                    if (UserTypeID != 2)
                    {
                        //if (App.UserSession != null && App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions != null && App.UserSession.CurrentUserInfo.UserPermissions.ShowTimesheetSectionForSP != null && App.UserSession.CurrentUserInfo.UserPermissions.ShowTimesheetSectionForSP == true)
                        //{
                        navigationData = new LeftNavigationData();
                        navigationData.Section = "Timesheet";
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Timesheet", Id = "view-timesheets" });
                        Items.Add(navigationData);
                        // }
                    }
                    else
                    {
                        navigationData = new LeftNavigationData();
                        navigationData.Section = "Timesheet";
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "View Timesheet", Id = "view-timesheets" });
                    }

                    if (UserTypeID == 2)
                    {
                        //BubbleCount Logic Comes here
                        //if (Counts.timeSheetApprovalCount > 0)
                        //{
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Approve Timesheet", Id = "approve-timesheets", BadgeCount = 0, BadgeCountLabel = "" });
                        //}
                    }
                    //if (App.UserSession != null && App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions != null && App.UserSession.CurrentUserInfo.UserPermissions.AllowToAddTimesheet != null && App.UserSession.CurrentUserInfo.UserPermissions.AllowToAddTimesheet == true)
                    //{
                    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Create Timesheet", Id = "create-timesheet", BadgeCount = 0, BadgeCountLabel = "" });
                    //}
                    //if (UserTypeID != (int)UserType.Vendor_UserType)
                    //Items.Add(navigationData);

                    //if (App.UserSession != null && App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions != null && App.UserSession.CurrentUserInfo.UserPermissions.IsClientExpenseModuleEnabled)
                    //{
                    //navigationData = new LeftNavigationData();

                    //navigationData.Section = CultureUtility.GetResxNameByValue(Headers.EXPENSES);
                    //navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.VIEW_EXPENSE_REPORTS), Id = "view-expense-reports" });
                    //bool isAdded = false;
                    //if (App.UserSession != null && App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.UserPermissions != null && App.UserSession.CurrentUserInfo.UserPermissions.IsClientExpenseModuleEnabled && App.UserSession.CurrentUserInfo.UserPermissions.AllowToAddExpense == true)
                    //{
                    //    navigationData = new LeftNavigationData();

                    //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.EXPENSES);
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.VIEW_EXPENSE_REPORTS), Id = "view-expense-reports" });
                    //    if (UserTypeID == (int)UserType.Manager_UserType)
                    //    {
                    //        //Bubble Count Logic come here
                    //        if (Counts.expenseApprovalCount > 0)
                    //        {
                    //            isAdded = true;
                    //            navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.APPROVE_EXPENSES), Id = "approve-expenses", BadgeCount = Counts.expenseApprovalCount, BadgeCountLabel = Counts.expenseApprovalCount > 100 ? "99+" : Counts.expenseApprovalCount.ToString() });
                    //        }
                    //    }
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.CREATE_EXPENSE_REPORT), Id = "add-expense-report" });
                    //}

                    if (UserTypeID == 2 && true)
                    {
                        //Bubble Count Logic come here
                        //if (Counts.expenseApprovalCount > 0)
                        //{
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Approve Expense", Id = "approve-expenses", BadgeCount = 0, BadgeCountLabel = "" });
                        //}
                    }
                    Items.Add(navigationData);


                    if (UserTypeID == 2)
                    {
                        navigationData = new LeftNavigationData();
                        navigationData.Section = "Project";
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "View Project", Id = "view-projects" });

                        //BubbleCount Logic Come here
                        //if (Counts.projectApprovalCount > 0)
                        //{
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Approve Project", Id = "manage-approvals", BadgeCount = 0, BadgeCountLabel = "" });
                        //}

                        Items.Add(navigationData);
                    }

                    if (UserTypeID != 2)
                    {
                        navigationData = new LeftNavigationData();
                        navigationData.Section = "Invoice";
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "View Invoice", Id = "view-invoices", BadgeCount = 2, BadgeCountLabel = "" });
                        Items.Add(navigationData);
                    }
                    else if (UserTypeID == 2)
                    {
                        navigationData = new LeftNavigationData();
                        navigationData.Section = "Invoice";
                        //BubbleCount Loginc come here
                        //if (Counts.invoiceApprovalCount > 0)
                        //{
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Approve Invoice", Id = "approve-invoices", BadgeCount = 2, BadgeCountLabel = "" });
                        //}

                        //if (Counts.serviceInvoiceApprovalCount > 0)
                        //{
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Approve service invoice", Id = "sow-approve-service-invoice-list", BadgeCount = 0, BadgeCountLabel = "" });
                        // }

                        //if (Counts.invoiceApprovalCount > 0 || Counts.serviceInvoiceApprovalCount > 0)
                        //{
                        Items.Add(navigationData);
                        //}
                    }

                    //if (UserTypeID == (int)UserType.Vendor_UserType)
                    //{
                    //    navigationData = new LeftNavigationData();
                    //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.PAYMENT);
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.VIEW_PAY_HISTORY), Id = "supplier-pay-history" });
                    //    Items.Add(navigationData);
                    //}
                    //else if (UserTypeID == (int)UserType.Member_UserType)
                    //{
                    //    //bubble Count Logic Come here
                    //    navigationData = new LeftNavigationData();
                    //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.PAYMENT);
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.VIEW_PAY_HISTORY), Id = "resource-pay-history" });
                    //    Items.Add(navigationData);
                    //}

                    if (UserTypeID == 2)
                    {
                        //BubbleCount Logic Come here
                        //if (Counts.adjustmentApprovalCount > 0)
                        //{
                        //    navigationData = new LeftNavigationData();
                        //    navigationData.Section = CultureUtility.GetResxNameByValue(Headers.ADJUSTMENTS);
                        //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.APPROVE_ADJUSTMENTS), Id = "Approve_Adjustments", BadgeCount = Counts.adjustmentApprovalCount, BadgeCountLabel = Counts.adjustmentApprovalCount > 100 ? "99+" : Counts.adjustmentApprovalCount.ToString() });
                        //    Items.Add(navigationData);
                        //}
                    }
                    navigationData = new LeftNavigationData();
                    navigationData.Section = "Dossair";

                    if (UserTypeID == 2)
                    {
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Information" });
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Security" });
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Contact-us" });
                        navigationData.ChildItemList.Add(new LeftNavigationChild { Title = "Setting" });
                    }
                    //else if (UserTypeID == (int)UserType.Vendor_UserType && App.UserSession.CurrentUserInfo != null && App.UserSession.CurrentUserInfo.GlobalSupplierID > 0)
                    //{
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.INFORMATION), Id = "information" });
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.REVIEW_RATINGS), Id = "review-Rating" });
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.SECURITY), Id = "security" });
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.CONTACT_US), Id = "contact-us" });
                    //}
                    //else
                    //{
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.INFORMATION), Id = "information" });
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.SECURITY), Id = "security" });
                    //    navigationData.ChildItemList.Add(new LeftNavigationChild { Title = CultureUtility.GetResxNameByValue(Headers.CONTACT_US), Id = "contact-us" });
                    //}
                    Items.Add(navigationData);
                    navigationData = new LeftNavigationData();
                    navigationData.IsProfile = true;
                    Items.Add(navigationData);
                    navigationData = new LeftNavigationData();
                    navigationData.Section = "Logout";
                    navigationData.IsLogout = true;
                    Items.Add(navigationData);
                    return Items;
                }
                #endregion
            }
        }


}
