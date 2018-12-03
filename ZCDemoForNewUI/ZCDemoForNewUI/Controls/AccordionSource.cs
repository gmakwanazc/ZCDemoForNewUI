using Xamarin.Forms;

namespace ZCDemoForNewUI.Controls
{
    /// <summary>
    /// AccordionSource class
    /// </summary>
    public class AccordionSource
    {
        #region Private Members
        private View contentItems;
        #endregion

        #region Properties
        public bool IsLogout { get; set; }
        public bool IsProfile { get; set; }
        public string HeaderText { get; set; }
        public Color HeaderTextColor { get; set; }
        public Color HeaderBackGroundColor { get; set; }

        public View ContentItems
        {
            get { return contentItems; }
            set
            {
                contentItems = value;
                if (contentItems != null)
                    contentItems.BackgroundColor = Color.FromHex("#F8F8F8");
            }
        }
        #endregion
    }
}
