using System;

namespace demo.Entitys
{
    /// <summary>
    /// 长方体的点
    /// </summary>
    public class Point 
    {
        /// <summary>
        /// 
        /// </summary>
        public Point(int w, int l, int h)
        {
            // 根据大小，限定起点的位置
            Random r = new Random(); 
            this.x = r.Next(1, 100 - w);
            this.y = r.Next(1, 100 - l);
            this.z = r.Next(1, 100 - h);
        }
        
        public Point()
        {
            
        }

        private int x;
        public int X {
            get {
                return this.x;
            }
            set {
                this.x = value;
            }
        }

        private int y;
        public int Y {
            get {
                return this.y;
            }
            set {
                this.y = value;
            }
        }

        private int z;
        public int Z {
            get {
                return this.z;
            }
            set {
                this.z = value;
            }
        }

        public override string ToString() {
            return $"({x}, {y}, {z})";
        }
    }
}