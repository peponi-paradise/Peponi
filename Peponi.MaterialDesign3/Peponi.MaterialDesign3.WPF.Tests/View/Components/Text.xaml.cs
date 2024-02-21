using System.Windows;
using System.Windows.Controls;

namespace Peponi.MaterialDesign3.WPF.Tests.View.Components
{
    /// <summary>
    /// Text.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Text : UserControl
    {
        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(nameof(LabelText), typeof(string), typeof(Text), new PropertyMetadata(PropertyChanged));

        public string LabelText
        {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public static readonly DependencyProperty TextBlockTextProperty = DependencyProperty.Register(nameof(TextBlockText), typeof(string), typeof(Text), new PropertyMetadata(PropertyChanged));

        public string TextBlockText
        {
            get => (string)GetValue(TextBlockTextProperty);
            set => SetValue(TextBlockTextProperty, value);
        }

        public new static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(nameof(FontSize), typeof(double), typeof(Text), new PropertyMetadata(PropertyChanged));

        public new double FontSize
        {
            get => (double)GetValue(FontSizeProperty);
            set => SetValue(FontSizeProperty, value);
        }

        public static readonly DependencyProperty LineHeightProperty = DependencyProperty.Register(nameof(LineHeight), typeof(double), typeof(Text), new PropertyMetadata(PropertyChanged));

        public double LineHeight
        {
            get => (double)GetValue(LineHeightProperty);
            set => SetValue(LineHeightProperty, value);
        }

        public new static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(nameof(FontWeight), typeof(FontWeight), typeof(Text), new PropertyMetadata(PropertyChanged));

        public new FontWeight FontWeight
        {
            get => (FontWeight)GetValue(FontWeightProperty);
            set => SetValue(FontWeightProperty, value);
        }

        public Text()
        {
            InitializeComponent();
        }

        private static void PropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as Text;
            if (control != null)
            {
                switch (e.Property.Name)
                {
                    case nameof(LabelText):
                        control._label.Content = control.LabelText;
                        break;

                    case nameof(TextBlockText):
                        control._textBlock.Text = control.TextBlockText;
                        break;

                    case nameof(FontSize):
                        control._textBlock.FontSize = control.FontSize;
                        break;

                    case nameof(LineHeight):
                        control._textBlock.LineHeight = control.LineHeight;
                        break;

                    case nameof(FontWeight):
                        control._textBlock.FontWeight = control.FontWeight;
                        break;
                }
            }
        }
    }
}