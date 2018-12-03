using System;
using System.Collections;
using System.Collections.Generic;
using Xamarin.Forms;

namespace ZCDemoForNewUI.Controls
{
    /// <summary>
    /// Accordion class
    /// </summary>
    public class Accordion : ContentView
    {
        #region Private Variables
        List<AccordionSource> accordianDataSource;
        bool firstExpaned = false;
        #endregion

        #region Constructors
        public Accordion()
        {
            //var mMainLayout = new StackLayout();
            // Content = mMainLayout;
        }
        public Accordion(List<AccordionSource> aSource)
        {
            accordianDataSource = aSource;
        }
        #endregion

        #region Properties
        public static readonly BindableProperty DataSourceProperty = BindableProperty.Create("DataSource", typeof(IEnumerable), typeof(Accordion), null);

        public IList DataSource
        {
            get { return (IList)GetValue(DataSourceProperty); }
            set { SetValue(DataSourceProperty, value); }
        }
        public static readonly BindableProperty AccordianContentProperty = BindableProperty.Create("AccordianContent", typeof(Page), typeof(Accordion), null);

        public Page AccordianContent
        {
            get { return (Page)GetValue(AccordianContentProperty); }
            set { SetValue(AccordianContentProperty, value); }
        }
        /* public List<AccordionSource> DataSource
         {
             get { return mDataSource; }
             set { mDataSource = value; }
         }*/
        public bool FirstExpaned
        {
            get { return firstExpaned; }
            set { firstExpaned = value; }
        }
        #endregion

    }
}
