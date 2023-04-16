using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Windows.Ink;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Graph.Models;
using Graph.Views;
using Newtonsoft.Json;
namespace Graph.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        public ObservableCollection<CanvasModel> CanvMod = new ObservableCollection<CanvasModel>();
        int selectedColor;
        int selectedIndex;
        private IBrush[] brush = new IBrush[] {Brushes.Black,Brushes.Blue,Brushes.Red};
       
        public int SelectedColor {
            get => selectedColor;
            set => SetProperty(ref selectedColor, value);
        }
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
        public string _rectan = "5";
        public string _dots = "";
        public int _width = 5;
        public int _test = 0;
        public string _dot = "0";
        public string _scale = "0";
        public string _skew = "0";

        private readonly UserControl[] _contentArray = new UserControl[] {
            new El(),
            new lomLine(),
            new Pat(),
            new Rec(),
            new StLine(),
            new Change(),
        };
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }
        public string Sk
        {
            get => _skew;
            set => SetProperty(ref _skew, value);
        }
        public string Sc
        {
            get => _scale;
            set => SetProperty(ref _scale, value);
        }
        public string Dot {
            get => _dot;
            set => SetProperty(ref _dot, value);
        }
        public string Rect
        {
            get => _rectan;
            set => SetProperty(ref _rectan, value);
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
        public CanvasModel Ex() {
            CanvasModel canvas = CanvasMODEL[SelectedIndex];
            return canvas;
        }
        public void SaveFile()
        {
            Line lineForSave = new Line();
            Polyline pLineForSave = new Polyline();
            Rectangle recForSave = new Rectangle();
            Ellipse elForSave = new Ellipse();
            Avalonia.Controls.Shapes.Path pForSave = new Avalonia.Controls.Shapes.Path();
            ObservableCollection<CanvasModel> ColForSave = new ObservableCollection<CanvasModel>();
            foreach(CanvasModel Mod in CanvasMODEL)
            {
                if(Mod.line != null)
                {
                    lineForSave.StartPoint = Mod.line.StartPoint;
                    lineForSave.EndPoint = Mod.line.EndPoint;
                    lineForSave.Stroke = Mod.line.Stroke;
                    lineForSave.StrokeThickness = Mod.line.StrokeThickness;
                    ColForSave.Add(new CanvasModel { Name = Mod.Name, line = lineForSave });
                }
                if (Mod.pLine != null)
                {

                }
                if (Mod.Rec != null)
                {

                }
                if (Mod.El != null)
                {

                }
                if (Mod.P != null)
                {

                }
            }







            Line test = new Line();

            test.StartPoint = CanvasMODEL[0].line.StartPoint;
            ObservableCollection<CanvasModel> testCol = new ObservableCollection<CanvasModel>();
            testCol.Add(new CanvasModel { Name = CanvasMODEL[0].Name, line = test });
            string jsonqwe = JsonConvert.SerializeObject(ColForSave, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });
            File.WriteAllText("C:\\Users\\Rik\\source\\repos\\Graph\\jnhbijothrjio.json", jsonqwe);
        }
        public void ReadFile()
        {
            using (StreamReader r = new StreamReader("C:\\Users\\Rik\\source\\repos\\Graph\\jnhbijothrjio.json"))
            {
                string json = r.ReadToEnd();
                List<CanvasModel> items = JsonConvert.DeserializeObject<List<CanvasModel>>(json);
                foreach (CanvasModel Canv in items) {
                    if (Canv.line != null) {
                        _canv.Children.Add(Canv.line);
                    }
                    if (Canv.pLine != null)
                    {
                        _canv.Children.Add(Canv.pLine);
                    }
                    if (Canv.Rec != null)
                    {
                        _canv.Children.Add(Canv.Rec);
                    }
                    if (Canv.El != null)
                    {
                        _canv.Children.Add(Canv.El);
                    }
                    if (Canv.P != null)
                    {
                        _canv.Children.Add(Canv.P);
                    }
                }
            }
            
        }
        public void WriteFile() {
            
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
                Stroke = brush[SelectedColor],
                StrokeThickness = Thick,
            };
            
            CanvMod.Add(new CanvasModel { Name = Name,line=newRec});
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
            
            newRec.Stroke = brush[SelectedColor];
            newRec.Points = pointList;
            newRec.StrokeThickness = Thick;
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
            newRec.Stroke = brush[SelectedColor];
            newRec.Fill = brush[SelectedColor];
            Canvas.SetLeft(newRec, resultSt1);
            Canvas.SetTop(newRec, resultSt2);
            CanvMod.Add(new CanvasModel { Name = Name, Rec = newRec});
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
            newRec.Stroke = brush[SelectedColor];
            Canvas.SetLeft(newRec, resultSt1);
            Canvas.SetTop(newRec, resultSt2);
            CanvMod.Add(new CanvasModel { Name = Name, El = newRec });
            _canv.Children.Add(newRec);

        }
        public void AddPath()
        {

            string start = StartPoint;
            string[] wordsSt = start.Split(new char[] { ' ' });
            Avalonia.Controls.Shapes.Path newRec = new Avalonia.Controls.Shapes.Path();
            newRec.Data = Geometry.Parse(PathF);
            newRec.Stroke = brush[SelectedColor];
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
        public void Rotate() {

                 if (CanvasMODEL[SelectedIndex].Rec != null)
                    {
                int React = Convert.ToInt32(Rect);

                Rectangle rotatedRectangle = CanvasMODEL[SelectedIndex].Rec;
                string[] wordsSt = Dot.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                RotateTransform rotateTransform1 = new RotateTransform(React);
                TranslateTransform translateTransform = new TranslateTransform(resultSt1, resultSt2);
                rotatedRectangle.RenderTransform = translateTransform;
                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].Rec);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, Rec = rotatedRectangle });
            }


                else if (CanvasMODEL[SelectedIndex].line != null)
                    {
                int React = Convert.ToInt32(Rect);

                Line rotatedFigure = CanvasMODEL[SelectedIndex].line;
                string[] wordsSt = Dot.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                RotateTransform rotateTransform1 = new RotateTransform(React);
                TranslateTransform translateTransform = new TranslateTransform(resultSt1, resultSt2);
                rotatedFigure.RenderTransform = translateTransform;
                rotatedFigure.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].line);

                _canv.Children.Add(rotatedFigure);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.Add(new CanvasModel { Name = tempName, line = rotatedFigure });

                CanvasMODEL.RemoveAt(SelectedIndex);
                 }


                else if (CanvasMODEL[SelectedIndex].pLine != null)
                {
                int React = Convert.ToInt32(Rect);
                string[] wordsSt = Dot.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Polyline rotatedFigure = CanvasMODEL[SelectedIndex].pLine;
                
                RotateTransform rotateTransform1 = new RotateTransform(React);
                TranslateTransform translateTransform = new TranslateTransform(resultSt1, resultSt2);
                rotatedFigure.RenderTransform = translateTransform;
                rotatedFigure.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].pLine);

                _canv.Children.Add(rotatedFigure);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.Add(new CanvasModel { Name = tempName, pLine = rotatedFigure });

                CanvasMODEL.RemoveAt(SelectedIndex);
                }
                else if (CanvasMODEL[SelectedIndex].El != null)
                {
                int React = Convert.ToInt32(Rect);
                string[] wordsSt = Dot.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Ellipse rotatedFigure = CanvasMODEL[SelectedIndex].El;

                RotateTransform rotateTransform1 = new RotateTransform(React);
                TranslateTransform translateTransform = new TranslateTransform(resultSt1, resultSt2);
                rotatedFigure.RenderTransform = translateTransform;
                rotatedFigure.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].El);

                _canv.Children.Add(rotatedFigure);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.Add(new CanvasModel { Name = tempName, El = rotatedFigure });

                CanvasMODEL.RemoveAt(SelectedIndex);
            }
                else if (CanvasMODEL[SelectedIndex].P != null)
                {
                int React = Convert.ToInt32(Rect);
                string[] wordsSt = Dot.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Avalonia.Controls.Shapes.Path rotatedFigure = CanvasMODEL[SelectedIndex].P;

                RotateTransform rotateTransform1 = new RotateTransform(React);
                TranslateTransform translateTransform = new TranslateTransform(resultSt1, resultSt2);
                rotatedFigure.RenderTransform = translateTransform;
                rotatedFigure.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].P);

                _canv.Children.Add(rotatedFigure);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.Add(new CanvasModel { Name = tempName, P = rotatedFigure });

                CanvasMODEL.RemoveAt(SelectedIndex);
            }
        }
        public void Scale()
        {

            if (CanvasMODEL[SelectedIndex].Rec != null)
            {
                string[] wordsSt = Sc.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Rectangle rotatedRectangle = CanvasMODEL[SelectedIndex].Rec;

                ScaleTransform rotateTransform1 = new ScaleTransform(resultSt1,resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].Rec);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, Rec = rotatedRectangle });
            }


            else if (CanvasMODEL[SelectedIndex].line != null)
            {
                string[] wordsSt = Sc.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Line rotatedRectangle = CanvasMODEL[SelectedIndex].line;

                ScaleTransform rotateTransform1 = new ScaleTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].line);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, line = rotatedRectangle });
            }


            else if (CanvasMODEL[SelectedIndex].pLine != null)
            {
                string[] wordsSt = Sc.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Polyline rotatedRectangle = CanvasMODEL[SelectedIndex].pLine;

                ScaleTransform rotateTransform1 = new ScaleTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].pLine);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, pLine = rotatedRectangle });
            }
            else if (CanvasMODEL[SelectedIndex].El != null)
            {
                string[] wordsSt = Sc.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Ellipse rotatedRectangle = CanvasMODEL[SelectedIndex].El;

                ScaleTransform rotateTransform1 = new ScaleTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].El);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, El = rotatedRectangle });
            }
            else if (CanvasMODEL[SelectedIndex].P != null)
            {
                string[] wordsSt = Sc.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Avalonia.Controls.Shapes.Path rotatedRectangle = CanvasMODEL[SelectedIndex].P;

                ScaleTransform rotateTransform1 = new ScaleTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].P);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, P = rotatedRectangle });
            }
        }
        public void Skew()
        {
            if (CanvasMODEL[SelectedIndex].Rec != null)
            {
                string[] wordsSt = Sk.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Rectangle rotatedRectangle = CanvasMODEL[SelectedIndex].Rec;

                SkewTransform rotateTransform1 = new SkewTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].Rec);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, Rec = rotatedRectangle });
            }


            else if (CanvasMODEL[SelectedIndex].line != null)
            {
                string[] wordsSt = Sk.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Line rotatedRectangle = CanvasMODEL[SelectedIndex].line;

                SkewTransform rotateTransform1 = new SkewTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].line);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, line = rotatedRectangle });
            }


            else if (CanvasMODEL[SelectedIndex].pLine != null)
            {
                string[] wordsSt = Sk.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Polyline rotatedRectangle = CanvasMODEL[SelectedIndex].pLine;

                SkewTransform rotateTransform1 = new SkewTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].pLine);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, pLine = rotatedRectangle });
            }
            else if (CanvasMODEL[SelectedIndex].El != null)
            {
                string[] wordsSt = Sk.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Ellipse rotatedRectangle = CanvasMODEL[SelectedIndex].El;

                SkewTransform rotateTransform1 = new SkewTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].El);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, El = rotatedRectangle });
            }
            else if (CanvasMODEL[SelectedIndex].P != null)
            {
                string[] wordsSt = Sk.Split(new char[] { ' ' });
                int resultSt1 = Convert.ToInt32(wordsSt[0]);
                int resultSt2 = Convert.ToInt32(wordsSt[1]);
                Avalonia.Controls.Shapes.Path rotatedRectangle = CanvasMODEL[SelectedIndex].P;

                SkewTransform rotateTransform1 = new SkewTransform(resultSt1, resultSt2);

                rotatedRectangle.RenderTransform = rotateTransform1;

                _canv.Children.Remove(CanvasMODEL[SelectedIndex].P);

                _canv.Children.Add(rotatedRectangle);

                string tempName = CanvMod[selectedIndex].Name;

                CanvasMODEL.RemoveAt(SelectedIndex);

                CanvasMODEL.Add(new CanvasModel { Name = tempName, P = rotatedRectangle });
            }
        }
        public MainWindowViewModel(MainWindow mw)
        {
            _canv = mw.Find<Canvas>("MyCanv");
            _content = _contentArray[0];
            
    }
        
    }
}
