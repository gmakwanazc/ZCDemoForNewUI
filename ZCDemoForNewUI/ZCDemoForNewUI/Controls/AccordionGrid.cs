using Xamarin.Forms;

namespace ZCDemoForNewUI.Controls
{
    /// <summary>
    /// AccordionGrid class
    /// </summary>
   
    public class AccordionGrid : Grid
    {
        private bool _Expand;

        public bool Expand
        {
            get { return _Expand; }
            set { _Expand = value; }
        }
        private string _Text;

        public string Text
        {
            get { return _Text; }
            set { _Text = value; }
        }
        public bool IsLogout { get; set; }
        private View _RightContent;

        public View RightContent
        {
            get { return _RightContent; }
            set { _RightContent = value; }
        }

       
        public ContentView AssosiatedContent
        { get; set; }
        public AccordionGrid()
        {


        }

        public void DataBind()
        {
            ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            ColumnDefinitions.Add(new ColumnDefinition { Width = 20 });

            BoxView bx = new BoxView();
            bx.HeightRequest = 30;
            bx.InputTransparent = true;
            bx.BackgroundColor = Color.White;
            Children.Add(bx);

            Label l = new Label();
            l.InputTransparent = true;
            l.Text = Text;
            l.FontSize = 20;
            l.HorizontalOptions = LayoutOptions.Start;
            l.VerticalOptions = LayoutOptions.Center;
           
            l.Margin = new Thickness(10, 0, 0, 0);
            if(IsLogout)
            {
                l.TextColor = Color.FromHex("#0273AF");
            }
            else
            {
                l.TextColor = Color.FromHex("#444444");
            }
         
            l.FontAttributes = FontAttributes.Bold;
            if (RightContent == null)
                SetColumnSpan(l, 2);

            Children.Add(l);

            if (RightContent != null)
            {
                SetColumn(RightContent, 1);
                Children.Add(RightContent);
            }
        }

    }

}
