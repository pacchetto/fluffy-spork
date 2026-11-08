using System;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Input;
using Avalonia.Media;

namespace MyAvaloniaApp.Views;

public partial class MainWindow : Window
{
    // Створюємо статичний Canvas
    public static Canvas Canvas1 = new Canvas();
    // Створюємо статичний прямокутник
    public static Rectangle ShowRectangle = new Rectangle();

    public MainWindow()
    {
        InitializeComponent();

        // Встановлюємо висоту Canvas
        Canvas1.Height = 500;
        // Встановлюємо ширину Canvas
        Canvas1.Width = 1000;

        Avalonia.Threading.Dispatcher.UIThread.InvokeAsync(async () =>
        {
            while (true)
            {
                await Task.Delay(100);
                
            }
        });

        // Встановлюємо ширину прямокутника
        ShowRectangle.Width = 50;
        // Встановлюємо висоту прямокутника
        ShowRectangle.Height = 50;
        // Встановлюємо колір заповнення прямокутника
        ShowRectangle.Fill = new SolidColorBrush(Colors.Red);

        // Додаємо прямокутник до Canvas
        Canvas1.Children.Add(ShowRectangle);

        // Підключення обробників подій для Canvas
        // Canvas1.PointerMoved += CanvasEventResponse;
        // Canvas1.PointerWheelChanged += CanvasEventResponse;
        // Canvas1.PointerEntered += CanvasEventResponse;
        // Canvas1.PointerExited += CanvasEventResponse;
        Canvas1.PointerPressed += CanvasEventResponse;
        Canvas1.PointerReleased += CanvasEventResponse;

        // Встановлюємо колір фону Canvas
        Canvas1.Background = new SolidColorBrush(Colors.Blue);

        // Додаємо Canvas до основної панелі
        MainPanel.Children.Add(Canvas1);
    }

    // Метод для обробки подій Canvas
    public void CanvasEventResponse(object sender, PointerEventArgs e)
    {
        // Отримуємо координати курсора відносно Canvas
        double x = e.GetPosition((Canvas)sender).X;
        double y = e.GetPosition((Canvas)sender).Y;

        double realX = x;
        double realY = y;

        // Встановлюємо положення прямокутника
        ShowRectangle.SetValue(Canvas.LeftProperty, realX - ShowRectangle.Width / 2);
        ShowRectangle.SetValue(Canvas.TopProperty, realY - ShowRectangle.Height / 2);

        // Формуємо текст з координатами курсора
        string coordinatesOfPointerRelativeToImageText = $"X: {realX} Y: {realY}";

        // Виводимо подію та координати в консоль
        Console.WriteLine(e);
        Console.WriteLine(coordinatesOfPointerRelativeToImageText);

        // Виводимо координати на екрані
        OutputTB.Text = coordinatesOfPointerRelativeToImageText;
    }
}