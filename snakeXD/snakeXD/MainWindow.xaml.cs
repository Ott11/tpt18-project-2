﻿using System;
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
using System.Windows.Threading;

namespace snakeXD
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const double CellSize = 30D;
        const int CellCount = 16;
        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
            DrawBoardBackground();
            InitSnake();

            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(2);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //MoveSnake(Direction.Up);
        }

        private void InitSnake()
        {
            Jens.Height = CellSize;
            Jens.Width = CellSize;
            double coord = CellCount * CellSize / 2;
            Canvas.SetTop(Jens, coord);
            Canvas.SetLeft(Jens, coord);
        }

        private void MoveSnake(Direction direction)
        {
            if (direction == Direction.Up || direction == Direction.Down)
            {
                double currentTop = Canvas.GetTop(Jens);
                double newTop = direction == Direction.Up ? currentTop - CellSize : currentTop + CellSize;
                Canvas.SetTop(Jens, newTop);
            }

            if (direction == Direction.Left || direction == Direction.Right)
            {
                double currentLeft = Canvas.GetLeft(Jens);
                double newLeft = direction == Direction.Left ? currentLeft - CellSize : currentLeft + CellSize;
                Canvas.SetLeft(Jens, newLeft);
            }
        }

        private void DrawBoardBackground()
        {
            SolidColorBrush color1 = Brushes.LightGreen;
            SolidColorBrush color2 = Brushes.LimeGreen;

            for (int row = 0; row < CellCount; row++)
            {
                SolidColorBrush color = row % 2 == 0 ? color1 : color2;
                if (row % 2 == 0)
                {

                }

                for (int col = 0; col < CellCount; col++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = CellSize;
                    r.Height = CellSize;
                    r.Fill = color;
                    Canvas.SetTop(r, row * CellSize);
                    Canvas.SetLeft(r, col * CellSize);
                    board.Children.Add(r);

                    color = color == color1 ? color2 : color1;
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            Direction direction;
            switch (e.Key)
            {
                case Key.Up:
                    direction = Direction.Up;
                    break;

                case Key.Down:
                    direction = Direction.Down;
                    break;

                case Key.Left:
                    direction = Direction.Left;
                    break;

                case Key.Right:
                    direction = Direction.Right;
                    break;

                default:
                    return;
            }
            MoveSnake(direction);
        }

        public enum Direction
        {
            Up,
            Down,
            Left,
            Right
        }
    }
}