using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathUtils
{
    public class RunninWindowAvg
    {
        private Queue<double> samples = new Queue<double>();
        public int windowSize { get; set; } = 16;
        private double sampleAccumulator;
        private double dt;
      
        public RunninWindowAvg(int avgWnd, double tollerance = 0)
        {
            windowSize = avgWnd;
            dt = tollerance;
        }

        public double Average { get; private set; }
        public int FilledIn => samples.Count;

        /// <summary>
        /// Computes a new windowed average each time a new sample arrives
        /// </summary>
        /// <param name="newSample"></param>
        public double ComputeAverage(double newSample)
        {                       
            sampleAccumulator += newSample;
            samples.Enqueue(newSample);

            if (samples.Count > windowSize)
            {
                sampleAccumulator -= samples.Dequeue();
            }

            Average = sampleAccumulator / samples.Count;

            return Average;
        }

        public void Clear()
        {
            sampleAccumulator = 0;
            samples.Clear();
        }

        public double ComputeAverage(double xShift, out object isValid)
        {
            throw new NotImplementedException();
        }
    }
}
