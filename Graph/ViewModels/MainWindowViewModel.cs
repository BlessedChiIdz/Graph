using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection.Metadata;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DynamicData;
using Graph.Models;
using Graph.Views;
namespace Graph.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<Canvas> Coll = new ObservableCollection<Canvas>();
        public ObservableCollection<CanvasModel> CanvMod = new ObservableCollection<CanvasModel>();
        public ObservableCollection<Line> TestCol = new ObservableCollection<Line>();
        int selectedIndex;

        public int SelectedIndex
        {
            get => selectedIndex;
            set => SetProperty(ref selectedIndex, value);
        }
        public Canvas _canv;
        public Line LineTest;
        public Line LineTESt
        {
            get => LineTest;
            set => SetProperty(ref LineTest, value);
        }
        public StLine StLine1 { get; set; }
        public Views.lomLine lomLine { get; set; }
        public ObservableCollection<Canvas> Colletion {
            get => Coll;
            set => SetProperty(ref Coll, value);
        }
        public ObservableCollection<CanvasModel> CanvasMODEL
        {
            get => CanvMod;
            set => SetProperty(ref CanvMod, value);
        }
        private UserControl _content;
        public int _selectedIndexFig = 0;
        public string _name = "";
        public string _pathF = "";
        public string _startPoint = "";
        public string _endPoint = "";
        public string _color = "";
        public int _thick = 5;
        public string _w = "";
        public string _h = "";
        public string _dots = "";
        public int _width = 5;
        public int _test = 0;
        private readonly UserControl[] _contentArray = new UserControl[] {
            new El(),
            new lomLine(),
            new Pat(),
            new Rec(),
            new StLine(),
        };
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string PathF
        {
            get => _pathF;
            set => SetProperty(ref _pathF, value);
        }
        public string StartPoint
        {
            get => _startPoint;
            set => SetProperty(ref _startPoint, value);
        }
        public string EndPoint
        {
            get => _endPoint;
            set => SetProperty(ref _endPoint, value);
        }
        public string Color
        {
            get => _color;
            set => SetProperty(ref _color, value);
        }
        public string W
        {
            get => _w;
            set => SetProperty(ref _w, value);
        }
        public string H
        {
            get => _h;
            set => SetProperty(ref _h, value);
        }
        public int Thick
        {
            get => _thick;
            set => SetProperty(ref _thick, value);
        }
        
        public int SI
        {
            get => _selectedIndexFig;

            set { SetProperty(ref _selectedIndexFig, value); Content = _contentArray[value]; } 
        }
        public UserControl Content
        {
            get => _content;
            set => SetProperty(ref _content, value);
        }
        public int Width
        {
            get => _width;
            set => SetProperty(ref _width, value);
        }
        public string Dots
        {
            get => _dots;
            set => SetProperty(ref _dots, value);
        }
        
        public void AddLine()
        {
            string start = StartPoint;
            string[] wordsSt = start.Split(new char[] { ' ' });
            int resultSt1 = Convert.ToInt32(wordsSt[0]);
            int resultSt2 = Convert.ToInt32(wordsSt[1]);
            string end = EndPoint;
            string[] wordsEnd = end.Split(new char[] { ' ' });
            int resultEnd1 = Convert.ToInt32(wordsEnd[0]);
            int resultEnd2 = Convert.ToInt32(wordsEnd[1]);
            Point Stpoint = new Point(resultSt1, resultSt2);
            Point Endpoint = new Point(resultEnd1, resultEnd2);
            
            Line newRec = new Line
            {
                StartPoint = Stpoint,
                EndPoint = Endpoint,
                Stroke = Brushes.Aqua,
                StrokeThickness = Thick,
            };
            Canvas.SetLeft(newRec, 100);
            Canvas.SetTop(newRec, 100);
            TestCol.Add(newRec);
            CanvMod.Add(new CanvasModel { Name = Name,line=newRec });
            _canv.Children.Add(newRec);
        }
        public void AddLomeLine()
        {
            string start = Dots;
            string[] wordsSt = start.Split(new char[] { ' ' });
            int[] result = new int[100];
            for (int i = 0; i < wordsSt.Length; i++)
            {
                int resultSt1 = Convert.ToInt32(wordsSt[i]);
                result[i] = resultSt1;
            }
            
            Polyline newRec = new Polyline();
            List<Point> pointList = new List<Point>();
            for (int i = 0; i < wordsSt.Length; i=i+2)
            {
                pointList.Add(new Point(result[i], result[i+1]));
            }
            
            newRec.Stroke = Brushes.Aqua;
            newRec.Points = pointList;
            newRec.StrokeThickness = Thick;
            Canvas.SetLeft(newRec, 100);
            Canvas.SetTop(newRec, 100);
            CanvMod.Add(new CanvasModel { Name = Name, pLine = newRec });
            _canv.Children.Add(newRec);
        }
        public void AddRec()
        {

            string start = StartPoint;
            string[] wordsSt = start.Split(new char[] { ' ' });
            int resultSt1 = Convert.ToInt32(wordsSt[0]);
            int resultSt2 = Convert.ToInt32(wordsSt[1]);
            int width = Convert.ToInt32(W);
            int height = Convert.ToInt32(H);

            Rectangle newRec = new Rectangle();

            newRec.Width = width;
            newRec.Height = height;
            newRec.StrokeThickness = Thick;
            newRec.Stroke = Brushes.Aqua;
            Canvas.SetLeft(newRec, resultSt1);
            Canvas.SetTop(newRec, resultSt2);
            CanvMod.Add(new CanvasModel { Name = Name, Rec = newRec });
            _canv.Children.Add(newRec);

        }
        public void AddEl()
        {

            string start = StartPoint;
            string[] wordsSt = start.Split(new char[] { ' ' });
            int resultSt1 = Convert.ToInt32(wordsSt[0]);
            int resultSt2 = Convert.ToInt32(wordsSt[1]);
            int width = Convert.ToInt32(W);
            int height = Convert.ToInt32(H);

            Ellipse newRec = new Ellipse();

            newRec.Width = width;
            newRec.Height = height;
            newRec.StrokeThickness = Thick;
            newRec.Stroke = Brushes.Aqua;
            Canvas.SetLeft(newRec, resultSt1);
            Canvas.SetTop(newRec, resultSt2);
            CanvMod.Add(new CanvasModel { Name = Name, El = newRec });
            _canv.Children.Add(newRec);

        }
        public void AddPath()
        {

            string start = StartPoint;
            string[] wordsSt = start.Split(new char[] { ' ' });
            Path newRec = new Path();
            newRec.Data = Geometry.Parse(PathF);
            newRec.Stroke = Brushes.Aqua;
            newRec.StrokeThickness = Thick;
            Canvas.SetLeft(newRec, 0);
            Canvas.SetTop(newRec, 0);
            CanvMod.Add(new CanvasModel { Name = Name, P = newRec });
            _canv.Children.Add(newRec);

        }
        public void Remove()
        {
            if(CanvasMODEL[SelectedIndex].line != null)
            {
                _canv.Children.Remove(CanvasMODEL[SelectedIndex].line);
                CanvasMODEL.RemoveAt(SelectedIndex);
            }
            else if (CanvasMODEL[SelectedIndex].pLine != null)
            {
                _canv.Children.Remove(CanvasMODEL[SelectedIndex].pLine);
                CanvasMODEL.RemoveAt(SelectedIndex);
            }
            else if (CanvasMODEL[SelectedIndex].Rec != null)
            {
                _canv.Children.Remove(CanvasMODEL[SelectedIndex].Rec);
                CanvasMODEL.RemoveAt(SelectedIndex);
            }
            else if (CanvasMODEL[SelectedIndex].El != null)
            {
                _canv.Children.Remove(CanvasMODEL[SelectedIndex].El);
                CanvasMODEL.RemoveAt(SelectedIndex);
            }
            else if (CanvasMODEL[SelectedIndex].P != null)
            {
                _canv.Children.Remove(CanvasMODEL[SelectedIndex].P);
                CanvasMODEL.RemoveAt(SelectedIndex);
            }
        }

        public MainWindowViewModel(MainWindow mw)
        {
            _canv = mw.Find<Canvas>("MyCanv");
            _content = _contentArray[0];
        }
        
    }
}
