using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicsTypes
{
    class Point2D
    {
        public double x;
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        private double y;
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        double R
        {
            get { return Math.Sqrt(X * X + Y * Y); }
        }

        public Point2D() { }
        public Point2D(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        // Операции приведения ==========
        public static implicit operator Point3D(Point2D p)
        {
            return new Point3D(p.X, p.Y, 0.0);
        }
        public static implicit operator int(Point2D p)
        {
            return -(int)p.R;
        }
        //public static implicit operator Point2D(double key)
        //{
        //    return new Point2D(key);
        //}
        //public static implicit operator Point2D(int key)
        //{
        //    return new Point2D(key);
        //}
        public static implicit operator double[](Point2D p)
        {
            return new double[] { p.X, p.Y };
        }
    }
}
