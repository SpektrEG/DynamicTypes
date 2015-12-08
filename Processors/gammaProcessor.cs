using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Processors
{
    class gammaProcessor
    {
        PointF field;
        public PointF Field
        {
            get { return field; }
            set { field = value; }
        }

        public gammaProcessor(PointF key)
        {
            this.field = key;
        }
        public gammaProcessor(gammaProcessor key)
        {
            this.field = key.field;
        }

        public static gammaProcessor operator + (gammaProcessor p1, gammaProcessor p2)
        {
            return new gammaProcessor(new PointF(p1.Field.X + p2.Field.X, p1.Field.Y + p2.Field.Y));
        }

        public override string ToString()
        {
            return String.Format("This is gammaProcessor object. Field: {0}", field);
        }
    }
}
