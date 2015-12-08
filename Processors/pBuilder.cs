using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Processors
{
    public class pBuilder
    {
        const int nTypesOfProcessors = 5;
        static Random rnd = new Random();

        public static dynamic getProcessors()
        {
            dynamic val = null;
            switch(rnd.Next(0, nTypesOfProcessors))
            {
                case 0:
                    val = new PointF((float)(Math.PI*rnd.NextDouble()), (float)(Math.PI*rnd.NextDouble()));
                    break;
                case 1:
                    val = new alfaProcessor(rnd.Next());
                    break;
                case 2:
                    val = new gammaProcessor(new PointF(
                                (float)(Math.PI * rnd.NextDouble()),
                                (float)(Math.PI * rnd.NextDouble())
                        ));
                    break;
                case 3:
                    val = new betaProcessor(rnd.Next());
                    break;
                case 4:
                    val = rnd.Next();
                    break;
            }
            return val;
        }
    }
}
