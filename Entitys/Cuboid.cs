
using System;
using demo.Entitys;

namespace demo
{
    public class Cuboid 
    {
        // 长
        public int length;

        // 宽
        public int width;

        // 高
        public int height;

        // 顶点
        public Point A1;
        public Point A2 = new Point();
        public Point A3 = new Point();
        public Point A4 = new Point();

        public Point B1 = new Point();
        public Point B2 = new Point();
        public Point B3 = new Point();
        public Point B4 = new Point();


        /// <summary>
        /// 
        /// </summary>
        public Cuboid() {
            Random r = new Random();
            this.length = r.Next(1, 100);
            this.width = r.Next(1, 100);
            this.height = r.Next(1, 100);
            A1 = new Point(width, length, height);
            init();
        }
        /// <summary>
        /// 根据长、宽、高 随机构建一个长方体
        /// </summary>
        /// <param name="length">长</param>
        /// <param name="width">宽</param>
        /// <param name="height">高</param>
        public Cuboid(int length, int width, int height) {
            this.length = length;
            this.width = width;
            this.height = height;
            //随机起点
            A1 = new Point(width, length, height);
            init();
        }

        /// <summary>
        /// 指定起点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Cuboid(Point point, int length, int width, int height) {
            this.length = length;
            this.width = width;
            this.height = height;
            A1 = point;
            init();
        }

        /// <summary>
        /// 指定起点
        /// </summary>
        /// <param name="point"></param>
        /// <param name="length"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        public Cuboid(Point point) {
            Random r = new Random();
            this.length = r.Next(1, 100 - point.Y);
            this.width = r.Next(1, 100 - point.X);
            this.height = r.Next(1, 100 - point.Z);
            A1 = point;
            init();
        }

        private void init() {
            //确定A2
            A2.X = A1.X + width;
            A2.Y = A1.Y;
            A2.Z = A1.Z;

            //确定A3
            A3.X = A1.X + width;
            A3.Y = A1.Y + length;
            A3.Z = A1.Z;

            //确定A4
            A4.X = A1.X;
            A4.Y = A1.Y + length;
            A4.Z = A1.Z;

            B1.X = A1.X;
            B1.Y = A1.Y;
            B1.Z = A1.Z + height;

            B2.X = A2.X;
            B2.Y = A2.Y;
            B2.Z = A2.Z + height;

            B3.X = A3.X;
            B3.Y = A3.Y;
            B3.Z = A3.Z + height;

            B4.X = A4.X;
            B4.Y = A4.Y;
            B4.Z = A4.Z + height;
        }

        /// <summary>
        /// 交集
        /// </summary>
        /// <returns></returns>
        public Cuboid Intersect(Cuboid c)
        {
            // 判断A1是否在 长方体内
            if (CheckPoint(this, c.A1)) {
                // 计算相交正方体
                // 形态一致相交部份也是一个正方体

                Console.WriteLine("c.A1是在 长方体内");
                return intersect(this, c);
            } else if (CheckPoint(c, this.A1)) {
                Console.WriteLine("this.A1否在 长方体内");
                return intersect(c, this);
            }

            // 说明A1点不在长方体内，不相交
            return null;
        }

        /// <summary>
        /// 获取相交部份的长方体
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private Cuboid intersect(Cuboid a, Cuboid b) {
            int w = a.A2.X > b.A2.X ? b.A2.X - b.A1.X : a.A2.X - a.A1.X;
            int l = a.A4.Y > b.A4.Y ? b.A4.Y - b.A1.Y : a.A4.Y - a.A1.Y;
            int h = a.B2.Z > b.B2.Z ? b.B2.Z - b.A1.Z : a.B2.Z - a.A1.Z;
            Console.WriteLine("相交的长方体：w:{0},l:{1},h:{2}", w, l, h);
            Cuboid newCub = new Cuboid(b.A1, l, w, h);

            newCub.Pring();
            return newCub;
        }

        public string Calc() {
            return $"{height} * {width} * {length} = " + (height * width * length);
        }
        /// <summary>
        /// 检查点是否存在于正方体中
        /// </summary>
        /// <param name="cuboid"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public bool CheckPoint(Cuboid cuboid, Point p) {
            if (cuboid.A1.X <= p.X 
            && p.X < cuboid.A2.X
            && cuboid.A3.Y > p.Y
            && p.Y >= cuboid.A1.Y
            && cuboid.B1.Z > p.Z
            && p.Z >= cuboid.A1.Z
            ) {
                return true;
            }
            return false;
        }
        public void Pring() {
            Console.WriteLine($"长方体的：长：{length},宽：{width},高：{height}");
            Console.WriteLine(A1.ToString());
            Console.WriteLine(A2.ToString());
            Console.WriteLine(A3.ToString());
            Console.WriteLine(A4.ToString());

            Console.WriteLine(B1.ToString());
            Console.WriteLine(B2.ToString());
            Console.WriteLine(B3.ToString());
            Console.WriteLine(B4.ToString());
        }
    }
}