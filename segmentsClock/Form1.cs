using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;


namespace segmentsClock
{
    public partial class Form1 : Form
    {
        private static System.Timers.Timer aTimer;
        private static DateTime starTime;

        public Form1()
        {
            InitializeComponent();
        }

        void Time()
        {
            starTime = DateTime.Now;
            DateTime time = DateTime.Now;

            Graphics g;
            g = this.CreateGraphics();
            Console.WriteLine(starTime);
            Console.WriteLine(time);

            if (starTime.Hour != time.Hour && starTime.Minute != time.Minute)
            {
                starTime = time;
                g.Clear(ColorTranslator.FromHtml("#c0c0"));

                if (time.Hour > 9)
                {
                    _firstSection(time.Hour / 10); //hours
                    _secondSection(time.Hour % 10); //hours
                }
                else
                {
                    _firstSection(); //hours
                    _secondSection(time.Hour % 10); //hours
                }

                if (time.Minute > 9)
                {
                    _thirdSection(time.Minute / 10); //minutes
                    _fourSection(time.Minute % 10); //minutes
                }
                else
                {
                    _thirdSection(); //minutes
                    _fourSection(time.Minute % 10); //minutes
                }

                __colon();
            }
            else
            {
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#c0c0c0")), 475, 105, 10, 400);
                __colon();
            }

            g.Dispose();

            Time();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = this.CreateGraphics();

            DateTime time = DateTime.Now;

            if (time.Hour > 9)
            {
                _firstSection(time.Hour / 10); //hours
                _secondSection(time.Hour % 10); //hours
            }
            else
            {
                _firstSection(); //hours
                _secondSection(time.Hour % 10); //hours
            }

            if (time.Minute > 9)
            {
                _thirdSection(time.Minute / 10); //minutes
                _fourSection(time.Minute % 10); //minutes
            }
            else
            {
                _thirdSection(); //minutes
                _fourSection(time.Minute % 10); //minutes
            }

            __colon();

            g.Dispose();
            starTime = DateTime.Now;

            g = this.CreateGraphics();
            Console.WriteLine(starTime);
            Console.WriteLine(time);

            if (starTime.Hour != time.Hour && starTime.Minute != time.Minute)
            {
                starTime = time;
                g.Clear(ColorTranslator.FromHtml("#c0c0"));

                if (time.Hour > 9)
                {
                    _firstSection(time.Hour / 10); //hours
                    _secondSection(time.Hour % 10); //hours
                }
                else
                {
                    _firstSection(); //hours
                    _secondSection(time.Hour % 10); //hours
                }

                if (time.Minute > 9)
                {
                    _thirdSection(time.Minute / 10); //minutes
                    _fourSection(time.Minute % 10); //minutes
                }
                else
                {
                    _thirdSection(); //minutes
                    _fourSection(time.Minute % 10); //minutes
                }

                __colon();
            }
            else
            {
                g.FillRectangle(new SolidBrush(ColorTranslator.FromHtml("#c0c0c0")), 475, 105, 10, 400);
                __colon();
            }

            g.Dispose();
        }

        private void _firstSection(int h = 0)
        {
            Graphics g;
            g = this.CreateGraphics();

            Brush segmentBrush = new SolidBrush(ColorTranslator.FromHtml("#bf0303"));

            const int greyPartWidth = 200;

            int greyRectanglesX = (this.Width - greyPartWidth * 5) / 2; //при 1113x525, x==55

            int segmentXStart = greyRectanglesX + 20 - 1; //75
            float segmentX = segmentXStart;
            float segmentWidth = greyPartWidth * 0.6f; //120

            int segmentYStart = panel1.Height + 20 + 20; //45 + 20
            float segmentY = segmentYStart;
            float segmentHeight = 20f; //

            float wholeSegmentWidth = greyPartWidth * .8f; //160
            float wholeSegmentHeight = 60f * 2;

            PointF[] segment1 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX += 20, segmentY - segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY - segmentHeight), //3

                new PointF(segmentX += 20, segmentY), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment2 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment3 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment4 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight + wholeSegmentHeight), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 2 + wholeSegmentHeight), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight + wholeSegmentHeight), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart;
            PointF[] segment5 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment6 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart;
            segmentX = segmentXStart;
            PointF[] segment7 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight * 2 + segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight * 2 + segmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1
            };
            /*
            g.FillPolygon(segmentBrush, segment1);
            g.DrawLines(new Pen(Color.Black, 1f), segment1);

            g.FillPolygon(segmentBrush, segment2);
            g.DrawLines(new Pen(Color.Black, 1f), segment2);

            g.FillPolygon(segmentBrush, segment3);
            g.DrawLines(new Pen(Color.Black, 1f), segment3);

            g.FillPolygon(segmentBrush, segment4);
            g.DrawLines(new Pen(Color.Black, 1f), segment4);

            g.FillPolygon(segmentBrush, segment5);
            g.DrawLines(new Pen(Color.Black, 1f), segment5);

            g.FillPolygon(segmentBrush, segment6);
            g.DrawLines(new Pen(Color.Black, 1f), segment6);

            g.FillPolygon(segmentBrush, segment7);
            g.DrawLines(new Pen(Color.Black, 1f), segment7);
            */

            switch (h)
            {
                case 0:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;

                case 1:

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;

                case 2:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                default:

                    break;
            }
        }

        private void _secondSection(int h)
        {
            Graphics g;
            g = this.CreateGraphics();

            Brush segmentBrush = new SolidBrush(ColorTranslator.FromHtml("#bf0303"));

            const int greyPartWidth = 200;

            int greyRectanglesX = (this.Width - greyPartWidth * 5) / 2; //при 1113x525, x==55

            int segmentXStart = 285; //75
            float segmentX = segmentXStart;
            float segmentWidth = greyPartWidth * 0.6f; //120

            int segmentYStart = panel1.Height + 20 + 20; //45 + 20
            float segmentY = segmentYStart;
            float segmentHeight = 20f; //

            float wholeSegmentWidth = greyPartWidth * .8f; //160
            float wholeSegmentHeight = 60f * 2;

            PointF[] segment1 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX += 20, segmentY - segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY - segmentHeight), //3

                new PointF(segmentX += 20, segmentY), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment2 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment3 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment4 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight + wholeSegmentHeight), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 2 + wholeSegmentHeight), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight + wholeSegmentHeight), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart;
            PointF[] segment5 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment6 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart;
            segmentX = segmentXStart;
            PointF[] segment7 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight * 2 + segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight * 2 + segmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1
            };

            switch (h)
            {
                case 0:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;

                case 1:

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;

                case 2:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 3:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 4:
                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;
                case 5:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 6:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 7:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;
                case 8:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 9:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                default:

                    break;
            }
        }

        private void __colon()
        {
            Graphics g;
            g = this.CreateGraphics();

            Brush segmentBrush = new SolidBrush(ColorTranslator.FromHtml("#bf0303"));

            const int greyPartWidth = 200;

            int greyRectanglesX = (this.Width - greyPartWidth * 5) / 2; //при 1113x525, x==55

            int segmentXStart = 515; //75
            float segmentX = segmentXStart;
            float segmentWidth = greyPartWidth * 0.6f; //120


            float segmentY = 115;
            float segmentHeight = 20f; //

            float wholeSegmentHeight = 60f * 2;

            PointF[] segment1 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 3), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight / 2 + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 3), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };
            g.FillPolygon(segmentBrush, segment1);


            segmentX = segmentXStart;
            segmentY = segmentY + 140;
            PointF[] segment2 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 3), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight / 2 + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 3), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };
            g.FillPolygon(segmentBrush, segment2);


            g.DrawLines(new Pen(Color.Black, 1f), segment1);
            g.DrawLines(new Pen(Color.Black, 1f), segment2);
            //
        }

        private void _thirdSection(int m = 0)
        {
            Graphics g;
            g = this.CreateGraphics();

            Brush segmentBrush = new SolidBrush(ColorTranslator.FromHtml("#bf0303"));

            const int greyPartWidth = 200;

            int greyRectanglesX = (this.Width - greyPartWidth * 5) / 2; //при 1113x525, x==55

            int segmentXStart = 585; //75
            float segmentX = segmentXStart;
            float segmentWidth = greyPartWidth * 0.6f; //120

            int segmentYStart = panel1.Height + 20 + 20; //45 + 20
            float segmentY = segmentYStart;
            float segmentHeight = 20f; //

            float wholeSegmentWidth = greyPartWidth * .8f; //160
            float wholeSegmentHeight = 60f * 2;

            PointF[] segment1 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX += 20, segmentY - segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY - segmentHeight), //3

                new PointF(segmentX += 20, segmentY), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment2 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment3 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment4 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight + wholeSegmentHeight), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 2 + wholeSegmentHeight), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight + wholeSegmentHeight), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart;
            PointF[] segment5 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment6 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart;
            segmentX = segmentXStart;
            PointF[] segment7 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight * 2 + segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight * 2 + segmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1
            };

            switch (m)
            {
                case 0:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;

                case 1:

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;

                case 2:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 3:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 4:
                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;
                case 5:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                default:

                    break;
            }
        }

        private void _fourSection(int m)
        {
            Graphics g;
            g = this.CreateGraphics();

            Brush segmentBrush = new SolidBrush(ColorTranslator.FromHtml("#bf0303"));

            const int greyPartWidth = 200;

            int greyRectanglesX = (this.Width - greyPartWidth * 5) / 2; //при 1113x525, x==55

            int segmentXStart = 795; //75
            float segmentX = segmentXStart;
            float segmentWidth = greyPartWidth * 0.6f; //120

            int segmentYStart = panel1.Height + 20 + 20; //45 + 20
            float segmentY = segmentYStart;
            float segmentHeight = 20f; //

            float wholeSegmentWidth = greyPartWidth * .8f; //160
            float wholeSegmentHeight = 60f * 2;

            PointF[] segment1 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX += 20, segmentY - segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY - segmentHeight), //3

                new PointF(segmentX += 20, segmentY), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment2 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment3 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentX = segmentXStart;
            PointF[] segment4 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight + wholeSegmentHeight), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 2 + wholeSegmentHeight), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight + wholeSegmentHeight), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart;
            PointF[] segment5 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight + segmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart + wholeSegmentHeight + segmentHeight;
            segmentX = segmentXStart + wholeSegmentWidth;
            PointF[] segment6 = new PointF[7]
            {
                new PointF(segmentX, segmentY), //1

                new PointF(segmentX -= 20, segmentY + segmentHeight), //2
                new PointF(segmentX, segmentY + segmentHeight * 6), //3

                new PointF(segmentX += 20, segmentY + segmentHeight + wholeSegmentHeight), //4

                new PointF(segmentX += 20, segmentY + segmentHeight * 6), //5
                new PointF(segmentX, segmentY + segmentHeight), //6

                new PointF(segmentX -= 20, segmentY), //1
            };

            segmentY = segmentYStart;
            segmentX = segmentXStart;
            PointF[] segment7 = new PointF[7]
            {
                new PointF(segmentX, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1

                new PointF(segmentX += 20, segmentY + wholeSegmentHeight * 2 + segmentHeight), //2
                new PointF(segmentX += segmentWidth, segmentY + wholeSegmentHeight * 2 + segmentHeight), //3

                new PointF(segmentX += 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //4

                new PointF(segmentX -= 20, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //5
                new PointF(segmentX -= segmentWidth, segmentY + segmentHeight * 3 + wholeSegmentHeight * 2), //6

                new PointF(segmentX -= 20, segmentY + segmentHeight * 2 + wholeSegmentHeight * 2), //1
            };

            switch (m)
            {
                case 0:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;

                case 1:

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;

                case 2:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 3:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 4:
                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;
                case 5:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 6:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 7:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);
                    break;
                case 8:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment5);
                    g.DrawLines(new Pen(Color.Black, 1f), segment5);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                case 9:
                    g.FillPolygon(segmentBrush, segment1);
                    g.DrawLines(new Pen(Color.Black, 1f), segment1);

                    g.FillPolygon(segmentBrush, segment2);
                    g.DrawLines(new Pen(Color.Black, 1f), segment2);

                    g.FillPolygon(segmentBrush, segment3);
                    g.DrawLines(new Pen(Color.Black, 1f), segment3);

                    g.FillPolygon(segmentBrush, segment4);
                    g.DrawLines(new Pen(Color.Black, 1f), segment4);

                    g.FillPolygon(segmentBrush, segment6);
                    g.DrawLines(new Pen(Color.Black, 1f), segment6);

                    g.FillPolygon(segmentBrush, segment7);
                    g.DrawLines(new Pen(Color.Black, 1f), segment7);
                    break;
                default:

                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            aTimer = new System.Timers.Timer();
            aTimer.Interval = 2000;

            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            aTimer.AutoReset = true;

            // Start the timer
            aTimer.Enabled = true;
        }

        private static void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
        }
    }
}