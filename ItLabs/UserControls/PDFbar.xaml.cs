using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ItLabs.UserControls
{
    public partial class PDFbar : UserControl
    {
        public PDFbar()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(PDFbar), new PropertyMetadata(null));

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        public static readonly DependencyProperty IconSourceProperty =
            DependencyProperty.Register("IconSource", typeof(ImageSource), typeof(PDFbar), new PropertyMetadata(null));

        public ImageSource IconSource
        {
            get { return (ImageSource)GetValue(IconSourceProperty); }
            set { SetValue(IconSourceProperty, value); }
        }

        public static readonly DependencyProperty ButtonContentProperty =
            DependencyProperty.Register("ButtonContent", typeof(string), typeof(PDFbar), new PropertyMetadata(string.Empty));

        public string ButtonContent
        {
            get { return (string)GetValue(ButtonContentProperty); }
            set { SetValue(ButtonContentProperty, value); }
        }

        public static readonly DependencyProperty ColumnProperty =
            DependencyProperty.Register("Column", typeof(int), typeof(PDFbar), new PropertyMetadata(0));

        public int Column
        {
            get { return (int)GetValue(ColumnProperty); }
            set { SetValue(ColumnProperty, value); }
        }

        public static readonly DependencyProperty ViewPdfCommandProperty =
             DependencyProperty.Register("ViewPdfCommand", typeof(ICommand), typeof(PDFbar), new PropertyMetadata(null));

        public ICommand ViewPdfCommand
        {
            get { return (ICommand)GetValue(ViewPdfCommandProperty); }
            set { SetValue(ViewPdfCommandProperty, value); }
        }

    }
}
