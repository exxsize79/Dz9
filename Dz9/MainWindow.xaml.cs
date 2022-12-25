using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dz9
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        // обработчик, подключаемый в XAML
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi from Button_Click");
        }
        // обработчик, подключаемый в конструкторе
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Hi from Button1_Click");
        }
        private void Control_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBlock1.Text = textBlock1.Text + "sender: " + sender.ToString() + "\n";
            textBlock1.Text = textBlock1.Text + "source: " + e.Source.ToString() + "\n\n";
        }
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton selectedRadio = (RadioButton)e.Source;
            textBlock1.Text = "Вы выбрали: " + selectedRadio.Content.ToString();
            menuSelector.AddHandler(RadioButton.CheckedEvent, new RoutedEventHandler(RadioButton_Click));
        }
    }
    public abstract class ButtonBase : ContentControl
{
        // определение событие
        public static readonly RoutedEvent ClickEvent;

        static ButtonBase()
        {
            // регистрация маршрутизированного события
            ButtonBase.ClickEvent = EventManager.RegisterRoutedEvent("Click",
                RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ButtonBase));
            //................................
        }
        // обертка над событием
        public event RoutedEventHandler Click
        {
            add
            {
                // добавление обработчика
                base.AddHandler(ButtonBase.ClickEvent, value);
            }
            remove
            {
                // удаление обработчика
                base.RemoveHandler(ButtonBase.ClickEvent, value);
            }
        }
        // остальное содержимое класса
    }

}
